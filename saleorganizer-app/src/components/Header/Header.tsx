import UserIcon from '../../ClothLogo/ClothLogo';
import styled from 'styled-components';

const Wrapper = styled.div`
    width: 100%;
    background-color: #d8ecf5;
    border-bottom: 2px solid;
    padding-bottom: 5px;
`

export const Header = () => (
    <Wrapper>
        <UserIcon />
        <span>Ubrankowy Menadżer</span>
    </Wrapper>
)