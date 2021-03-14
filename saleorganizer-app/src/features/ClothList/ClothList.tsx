import Cloth from "../../Interfaces/Cloth";

interface Props {
    clothes: Cloth[];
}

export const ClothList = ({clothes}: Props) => (
    <div className="HomeDashBoard">
        <ul>
            {clothes.map((cloth: any) => (
            <li key = {cloth.id}>
                {cloth.name}
            </li>
            ))}  
        </ul>
    </div>
)