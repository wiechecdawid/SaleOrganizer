import axios from "axios"
import { ChangeEventHandler, FormEventHandler, useState } from "react"
import { Redirect } from "react-router"
import styled from "styled-components"
import { getToken } from "../../../helpers/tokenHelpers"

interface Props {
    clothId: number
}

const Form = styled.form`
    width: 20vw;
    padding: 10px;
    display: block;
    margin: 20px auto;
    border: 2px solid black;
`

export const PhotoInput = ( { clothId }: Props ) => {
    const [ photo, setPhoto ] = useState({} as File)
    const [ error, setError ] = useState('')

    const types = ["image/png", "image/jpeg"]

    const addPhotoHandler: ChangeEventHandler<HTMLInputElement> = (ev) => {
        const selected = ev.target.files?.[0]
        console.log(selected)

        if(selected && types.includes(selected.type)) {
            setPhoto(selected)
            setError('')
            return
        }

        setError('Incorrect file format')
    }

    const submitHandler: FormEventHandler<HTMLFormElement> = (ev: React.FormEvent) => {
        ev.preventDefault()
        if(photo && error === '') {
            const formData = new FormData()
            formData.append('file', photo)

            const token = getToken()
            const authorization = `Bearer ${token}`

            axios({
                method: "post",
                url: `http://localhost:5000/api/photo?clothId=${clothId}`,
                headers: {
                    "Content-Type": "multipart/form-data",
                    "Authorization": authorization
                },
                data: formData
            }).then( () => {
                window.location.reload()
            })
            .catch(error => {
                console.log(error)
            })
        }
    }

    return(
        <Form onSubmit={submitHandler}>
            <h5>Add Photo</h5>
            <input id="add-photo" type="file" accept="image/*" onChange={addPhotoHandler}/>
            <input type="submit" value="Dodaj" />
        </Form>
    )
}