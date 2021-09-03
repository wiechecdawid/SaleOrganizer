import Cloth from '../../interfaces/cloth'
import { useParams } from 'react-router-dom'
import { Service } from '../../interfaces/service-status';
import { useEffect, useState } from 'react';
import axios from 'axios';
import PhotoComponent from '../PhotoComponent/PhotoComponent';
import styled from 'styled-components';

const DetailsWrapper = styled.div`
`

type Params = {
    id: string
}

export const ClothDetails = () => {
    const { id } = useParams<Params>();

    const [ cloth, setCloth ] = useState({} as Service<Cloth>)

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
                <p>{ cloth.payload.description }</p>
            </>
        }
        { cloth.status === 'error' && 
            <div>Error: {cloth.status}</div>
        }
    </>
)}