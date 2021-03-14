import Cloth from "../Interfaces/Cloth";
import { ClothList } from '../features/ClothList/ClothList'
import Offering from "../Interfaces/Offering";
import Purchase from "../Interfaces/Purchase";
import { OfferingList } from '../features/OfferingList/OfferingList';
import { PurchaseList } from '../features/PurchaseList/PurchaseList';

interface Props {
    clothes: Cloth[];
    offerings: Offering[],
    purchases: Purchase[]
}

export const HomeDashboard = ({clothes, offerings, purchases}: Props) => (
    <div className="HomeDashboard">
        <p>Sprzedankowe rzeczy:</p>
        <OfferingList offerings={offerings} />
        <p>Kupiłam sobie takie dne coś:</p>
        <PurchaseList purchases={ purchases } />
        <p>Moje ubranka:</p>
        <ClothList clothes={clothes} />
    </div>
)