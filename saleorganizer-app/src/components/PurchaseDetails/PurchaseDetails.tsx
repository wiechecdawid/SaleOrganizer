import Purchase from '../../interfaces/purchase';
import { useParams } from 'react-router-dom'

interface Props {
    purchase: Purchase
}

type Params = {
    id: string
}

export const PurchaseDetails = ({ purchase }: Props) => {
    const { id } = useParams<Params>()

    return (
    <div className="offeringDetails">
        <h1>{ id }</h1>
    </div>
)}