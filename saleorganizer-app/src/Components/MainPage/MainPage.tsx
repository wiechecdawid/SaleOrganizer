import styled from 'styled-components'

const Wrapper = styled.div`
    background-color: #c8caca;
    & ul {
        list-style-type: none;
    }
`

interface Props { }

export const MainPage: React.FC<Props> = ( { children } ) => (
    <Wrapper>
        { children }
    </Wrapper>
)