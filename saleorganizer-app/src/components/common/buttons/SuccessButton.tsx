import styled from 'styled-components';

const Button = styled.button`
    background-color: #23b660;
`
interface Props {
    content: string
}

export const SuccessButton = ( { content }: Props) => <Button>{ content }</Button>