import Cloth from '../../interfaces/cloth'
import { useParams } from 'react-router-dom'

interface Props {
    cloth: Cloth
}

type Params = {
    id: string
}

export const ClothDetails = ({ cloth }: Props) => {
    const { id } = useParams<Params>();

    return (
    <>
        <h1> { id } </h1>
    </>
)}