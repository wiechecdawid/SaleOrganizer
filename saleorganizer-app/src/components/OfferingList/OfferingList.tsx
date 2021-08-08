import { StyledLink } from "../common/StyledLink/StyledLink";
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
                <StyledLink to={`/offerings/${ offering.id }`}>{offering.cloth.name}: {offering.price}zł</StyledLink>
            </li>
            ) )}  
        </ul>
    </>
)