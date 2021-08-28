import Purchase from '../../interfaces/purchase';
import { useParams } from 'react-router-dom'
import { useState, useEffect } from 'react';
import axios from 'axios';
import { Service } from '../../interfaces/service-status';

type Params = {
    id: string
}

export const PurchaseDetails = () => {
    const { id } = useParams<Params>()

    const [ purchase, setPurchase ] = useState({} as Service<Purchase>)

    useEffect( () => { 
        const p = axios.get(`http://localhost:5000/api/purchases/${id}`)
            .then( response => setPurchase( () => {
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
        { purchase.status === 'loading' && <div>Loading</div> }
        { purchase.status === 'loaded' &&
            <h1>{ purchase.payload.cloth.name }</h1>
        }
        { purchase.status === 'error' && 
            <div>Error: {purchase.status}</div>
        }
    </>
)}