import Purchase from "../../interfaces/purchase";

interface Props {
    purchases: Purchase[];
}

export const PurchaseList = ({purchases}: Props) => (
    <div className="HomeDashBoard">
        <ul>
            {purchases.map((purchase: any) => (
            <li key = {purchase.id}>
                {purchase.cloth.name}: {purchase.price}zł
            </li>
            ))}  
        </ul>
    </div>
)