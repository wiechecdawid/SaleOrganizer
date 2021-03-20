import Cloth from "../Interfaces/Cloth";
import { ClothList } from '../features/ClothList/ClothList'
import Offering from "../Interfaces/Offering";
import Purchase from "../Interfaces/Purchase";
import { OfferingList } from '../features/OfferingList/OfferingList';
import { PurchaseList } from '../features/PurchaseList/PurchaseList';
import { ClothDetails } from '../features/ClothDetails/ClothDetails';
import { OfferingDetails } from '../features/OfferingDetails/OfferingDetails';
import { PurchaseDetails } from '../features/PurchaseDetails/PurchaseDetails'

interface Props {
    clothes: Cloth[];
    offerings: Offering[],
    purchases: Purchase[],
    cloth: Cloth,
    offering: Offering,
    purchase: Purchase
}

export const HomeDashboard = ({ clothes, offerings, purchases, cloth, offering, purchase }: Props) => (
    <div className="HomeDashboard">
        <p>Sprzedankowe rzeczy:</p>
        < OfferingList offerings={offerings} />
        <p>Kupiłam sobie takie dne coś:</p>
        < PurchaseList purchases={ purchases } />
        <p>Moje ubranka:</p>
        < ClothList clothes={clothes} />

        < ClothDetails cloth={ cloth } />
        < OfferingDetails offering={ offering } />
        < PurchaseDetails purchase={ purchase } />
    </div>
)