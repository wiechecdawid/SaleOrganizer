import Cloth from '../../interfaces/cloth'
import { useParams } from 'react-router-dom'
import { Service } from '../../interfaces/service-status';
import { useEffect, useState } from 'react';
import axios from 'axios';
import PhotoComponent from '../common/PhotoComponent/PhotoComponent';
import styled from 'styled-components';
import { PhotoInput } from '../common/photo/PhotoInput';
import { SuccessButton } from '../common/buttons/SuccessButton';

const DetailsWrapper = styled.div`
`

type Params = {
    id: string
}

export const ClothDetails = () => {
    const { id } = useParams<Params>();

    const [ cloth, setCloth ] = useState({} as Service<Cloth>)
    const [ isAddPthoroPressed, setAddPhotoPressed ] = useState(false)

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

    return (
    <>
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
            </>
        }
        { cloth.status === 'error' && 
            <div>Error: {cloth.status}</div>
        }
    </>
)}