import styled from 'styled-components'
import ClothList from '../ClothList/ClothList';
import OfferingList from '../OfferingList/OfferingList';
import PurchaseList from '../PurchaseList/PurchaseList';

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
export const MainPage = () => (  
    <Wrapper>
        <OfferingList />
        <PurchaseList />
        <ClothList />
    </Wrapper>
)