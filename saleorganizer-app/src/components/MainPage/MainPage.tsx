import axios from 'axios';
import { useEffect, useState } from 'react';
import styled from 'styled-components'
import Cloth from '../../interfaces/cloth';
import Offering from '../../interfaces/offering';
import Purchase from '../../interfaces/purchase'
import { ClothList } from '../ClothList/ClothList';
import { OfferingList } from '../OfferingList/OfferingList';
import { PurchaseList } from '../PurchaseList/PurchaseList';

const Wrapper = styled.div`
    margin: 20px auto;
    padding: 5px;
    background-color: #c8caca;
    & ul {
        list-style-type: none;
    }

    & li {
        display: flex;
        justify-content: center;
    }
`
export const MainPage = () => {
    const [clothes, setClothes] = useState<Cloth[]>([]);
    const [offerings, setOfferings] = useState<Offering[]>([])
    const [purchases, setPurchases] = useState<Purchase[]>([])
  
    useEffect( () => {
        axios.get<Cloth[]>('http://localhost:5000/api/clothes').then(response => {
        console.log(response);
        setClothes(response.data);
        })
        axios.get<Offering[]>('http://localhost:5000/api/offerings').then(response => {
        console.log(response)
        setOfferings(response.data)
        })
        axios.get<Purchase[]>('http://localhost:5000/api/purchases').then(response => {
        console.log(response)
        setPurchases(response.data)
        })
    }, [])
    
    return (  
        <Wrapper>
            {
                offerings &&
                <OfferingList offerings = { offerings } />
            }
            {
                purchases &&
                <PurchaseList purchases = { purchases } />
            }
            {
                clothes &&
                <ClothList clothes = { clothes } />
            }
        </Wrapper>
    )
}