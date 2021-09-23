import styled from 'styled-components';

const Button = styled.button`
    background-color: #e90436;
`
interface Props {
    content: string,
    onClick?: () => any
}

export const DeleteButton = ( { content, onClick }: Props) => <Button onClick={onClick}>{ content }</Button>