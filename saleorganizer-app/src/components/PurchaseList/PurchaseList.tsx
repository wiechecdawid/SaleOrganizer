import { Link } from "react-router-dom";
import Purchase from "../../interfaces/purchase";

interface Props {
    purchases: Purchase[];
}

export const PurchaseList = ( {purchases}: Props) => (
    <div>
        <p>Kupowane: </p>
        <ul>
            {purchases.map((purchase: Purchase) => (
            <li key = {purchase.id}>
                <Link to={`/purchases/${purchase.id}`}>{ purchase.cloth.name }: { purchase.price }zł</Link>
            </li>
            ))}
        </ul>
    </div>        
)