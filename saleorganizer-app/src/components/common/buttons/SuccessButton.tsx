import styled from 'styled-components';

const Button = styled.button`
    background-color: #23b660;
`
interface Props {
    content: string,
    onClick?: () => void
}

export const SuccessButton = ( { content, onClick }: Props) => <Button onClick={onClick}>{ content }</Button>