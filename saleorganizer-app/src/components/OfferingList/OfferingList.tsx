import { Link } from "react-router-dom";
import Offering from "../../interfaces/offering";

interface Props {
    offerings: Offering[];
}

export const OfferingList = ({offerings}: Props) => (
    <>
        <p>Sprzedawane: </p>
        <ul>
            {offerings.map( (offering: any) => (
            <li key = {offering.id}>
                <Link to={`/offerings/${ offering.id }`}>{offering.cloth.name}: {offering.price}zł</Link>
            </li>
            ) )}  
        </ul>
    </>
)