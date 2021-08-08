import { StyledLink } from "../common/StyledLink/StyledLink";
import Cloth from "../../interfaces/cloth";

interface Props {
    clothes: Cloth[];
}

export const ClothList = ({clothes}: Props) => (
    <>
        <p>Moje ubranka:</p>
        <ul>
            {clothes.map((cloth: any) => (
            <li key = {cloth.id}>
                <StyledLink to={`/clothes/${ cloth.id }`}>{cloth.name}</StyledLink>
            </li>
            ))}  
        </ul>
    </>
)