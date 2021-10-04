import UserIcon from '../../ClothLogo/ClothLogo';
import styled from 'styled-components';
import UserHub from './UserHub/UserHub';

const Wrapper = styled.div`
    display: flex;
    position: relative;
    width: 100%;
    background-color: #d8ecf5;
    border-bottom: 2px solid;
    padding: 15px 0px;
`

export const Header = () => (
    <>
        <Wrapper>
            <UserIcon />
            <span>Ubrankowy Menadżer</span>
            <UserHub />
        </Wrapper>
    </>
)