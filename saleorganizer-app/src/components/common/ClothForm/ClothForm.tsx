import axios from "axios";
import { FormEvent, useEffect, useState } from "react";
import { Redirect } from "react-router";
import Cloth from "../../../interfaces/cloth";

interface Props {
    cloth?: Cloth
}

export const ClothForm = ( { cloth }: Props ) => {
    const redirectUrl = cloth?.id === undefined ? "/clothes" : `/clothes/${cloth?.id}`
    const [ posted, setPosted ] = useState(false)

    useEffect( () => {
        posted && console.log("Request succeeded")
    }, [posted])

    const submitHandler = async(ev: FormEvent) => {
        ev.preventDefault()

        const clothName = document.querySelector('#clothTitle') as HTMLInputElement
        const clothDesc = document.querySelector('#clothDescription') as HTMLInputElement
        const clothInfo = document.querySelector('#storageInfo') as HTMLInputElement
        const detailed = document.querySelector('#detailedStorageInfo') as HTMLInputElement
        
        const body = {
            id: cloth?.id,
            name: clothName.value,
            description: clothDesc.value,
            status: cloth?.status ?? 2,
            storageInfo: clothInfo.value,
            detailedStorageInfo: detailed.value
        } as Cloth

        const serviceUrl = cloth === undefined ? 'http://localhost:5000/api/clothes' : `http://localhost:5000/api/clothes/${cloth?.id}`

        axios({
            method: cloth === undefined ? "post" : "put",
            url: serviceUrl,
            data: body
        })
        .then( response => {
            if(response.status === 200) {
                setPosted(true)
            }
        })
        .catch( error => {
            console.log(error)
        })
    }

    const redirect = () => <Redirect to={redirectUrl} />

    return (
        <>
            { posted && redirect() }
            <form onSubmit={submitHandler}>
                <label htmlFor="clothTitle">Nazwa ubranka: </label>
                <input type="text" id="clothTitle" placeholder={cloth?.name && 'Nazwa ubranka'} defaultValue={cloth?.name} />

                <label htmlFor="clothDescription">Opis: </label>
                <input type="text" id="clothDescription" placeholder={cloth?.description && 'Opis ubranka'}
                    defaultValue={cloth?.description} />

                <label htmlFor="storageInfo">Miejsce przechowywania: </label>
                <input type="text" id="storageInfo" placeholder={cloth?.storageInfo && 'Napisz, gdzie trzymasz ubranko'}
                    defaultValue={cloth?.storageInfo} />

                <label htmlFor="detailedStorageInfo">Miejsce przechowywania - wiecej info: </label>
                <input type="text" id="detailedStorageInfo" placeholder={cloth?.detailedStorageInfo && 'Napisz, gdzie trzymasz ubranko'}
                    defaultValue={cloth?.detailedStorageInfo} />

                <input type="submit" value="Potwierdź" />
            </form>
        </>
)}