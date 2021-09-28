import Cloth from "./cloth";
import Offering from "./offering";
import Purchase from "./purchase";
import User from "./user";

interface State<T> {
    data: T | null,
    error: any | null
}

export interface ClothesState extends State<Cloth[]> { }
export interface OfferingsState extends State<Offering[]> { }
export interface PurchasesState extends State<Purchase[]> { }
export interface UserState extends State<User> {
    isLoggedIn: boolean
}

export interface AppState {
    clothesState: ClothesState,
    offeringsState: OfferingsState,
    purchasesState: PurchasesState,
    userState: UserState
}