import Purchase from "../../interfaces/purchase";
import { StyledLink } from "../common/StyledLink/StyledLink"

interface Props {
    purchases: Purchase[];
}

export const PurchaseList = ( {purchases}: Props) => (
    <div>
        <p>Kupowane: </p>
        <ul>
            {purchases.map((purchase: Purchase) => (
            <li key = {purchase.id}>
                <StyledLink to={`/purchases/${purchase.id}`}>{ purchase.cloth.name }: { purchase.price }zł</StyledLink>
            </li>
            ))}
        </ul>
    </div>        
)