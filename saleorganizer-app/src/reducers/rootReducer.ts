import { combineReducers } from "redux";
import { AppState } from "../interfaces/states";
import { clothesReducer } from "./clothesReducer";
import { offeringsReducer } from "./offeringsReducer"
import { purchasesReducer } from "./purchasesReducer";

export const rootReducer = combineReducers<AppState>({
    clothesState: clothesReducer,
    offeringsState: offeringsReducer,
    purchasesState: purchasesReducer
})