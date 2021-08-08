import { Link } from "react-router-dom";
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
                <Link to={`/clothes/${ cloth.id }`}>{cloth.name}</Link>
            </li>
            ))}  
        </ul>
    </>
)