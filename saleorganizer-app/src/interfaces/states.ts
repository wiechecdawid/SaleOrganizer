import Cloth from "./cloth";
import Offering from "./offering";
import Purchase from "./purchase"

interface State<T> {
    data: T
}

export interface ClothesState extends State<Cloth[]> { }
export interface OfferingsState extends State<Offering[]> { }
export interface PurchasesState extends State<Purchase[]> { }

export interface AppState {
    clothesState: ClothesState,
    offeringsState: OfferingsState,
    purchasesState: PurchasesState
}