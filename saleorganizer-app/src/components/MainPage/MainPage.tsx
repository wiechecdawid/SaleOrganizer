import styled from 'styled-components'
import ClothList from '../ClothList/ClothList';
import OfferingList from '../OfferingList/OfferingList';
import PurchaseList from '../PurchaseList/PurchaseList';

const Wrapper = styled.div`
    width: 80vw;
    margin: 20px auto;
    padding: 15px 0px;
    background-color: #eff3f5;
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