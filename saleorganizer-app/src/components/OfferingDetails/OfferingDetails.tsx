import Offering from '../../interfaces/offering';
import { useParams } from 'react-router-dom'

interface Props {
    offering: Offering
}

type Params = {
    id: string
}

export const OfferingDetails = ({ offering }: Props) => {
    const { id } = useParams<Params>()
    
    return (
    <>
        <h1>{ id }</h1>
    </>
)}

// <h1>{offering.cloth.name}</h1>
//         <h5>{`${offering.offeringDate} - ${offering.tradeType}`}</h5>