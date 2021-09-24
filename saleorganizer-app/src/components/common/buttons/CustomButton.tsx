import styled from 'styled-components';

const Button = styled.button`
    background-color: #0408e9;
    color: white; 
`
interface Props {
    content: string,
    onClick?: () => any
}

export const CustomButton = ( { content, onClick }: Props) => <Button onClick={onClick}>{ content }</Button>