import Cloth from '../../interfaces/cloth'
import { Redirect, useParams } from 'react-router-dom'
import { Service } from '../../interfaces/service-status';
import { useEffect, useState } from 'react';
import axios from 'axios';
import PhotoComponent from '../common/PhotoComponent/PhotoComponent';
import styled from 'styled-components';
import { PhotoInput } from '../common/photo/PhotoInput';
import { SuccessButton } from '../common/buttons/SuccessButton';
import { DeleteButton } from '../common/buttons/DeleteButton';

const DetailsWrapper = styled.div`
`

type Params = {
    id: string
}

export const ClothDetails = () => {
    const { id } = useParams<Params>();

    const [ cloth, setCloth ] = useState({} as Service<Cloth>)
    const [ isAddPthoroPressed, setAddPhotoPressed ] = useState(false)
    const [ isDeleted, setDeleted ] = useState(false)

    const handlePhotoChange = () => {
        setAddPhotoPressed(!isAddPthoroPressed)
    }

    useEffect( () => { 
        const p = axios.get(`http://localhost:5000/api/clothes/${id}`)
            .then( response => setCloth( () => {
                return {
                    status: 'loaded',
                    payload: { ...response.data }
                }
            }))
            .catch( error => {
                console.log(error)
            })
    }, [])

    useEffect( () => {
        console.log("Photo change button pressed")
    }, [ handlePhotoChange ])

    useEffect( () => {
        console.log(`Cloth ${id} deleted`)
    }, [isDeleted])

    const deleteHandler = () => {
        axios({
            method: "delete",
            url: `http://localhost:5000/api/clothes/${id}`
        }).then( response => {
            if(response.status === 200)
                setDeleted(true)
        })
    }

    const redirect = () => <Redirect to="/clothes" />

    return (
        <>
            { isDeleted && redirect() }
            { cloth.status === 'loading' && <div>Loading</div> }
            { cloth.status === 'loaded' &&
                <>
                    <h1>{ cloth.payload.name }</h1>
                    {
                        cloth.payload.photo &&
                        <>
                            <PhotoComponent url={cloth.payload.photo.url} />
                        </>
                    }
                    <SuccessButton onClick={handlePhotoChange} content={cloth.payload.photo ? "Zmień zdjęcie" : "Dodaj zdjęcie"} />
                    {
                        isAddPthoroPressed &&
                        <PhotoInput clothId={cloth.payload.id} />
                    }
                    <p>{ cloth.payload.description }</p>
                    <h3>Przechowanie</h3>
                    <p>{ cloth.payload.storageInfo }</p>
                    <p>{ cloth.payload.detailedStorageInfo }</p>
                    <DeleteButton content="Usuń" onClick={deleteHandler} />
                </>
            }
            { cloth.status === 'error' && 
                <div>Error: {cloth.status}</div>
            }
        </>
    )
}