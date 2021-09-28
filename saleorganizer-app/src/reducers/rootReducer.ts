import { combineReducers } from "redux";
import { AppState } from "../interfaces/states";
import { clothesReducer } from "./clothesReducer";
import { offeringsReducer } from "./offeringsReducer";
import { purchasesReducer } from "./purchasesReducer";
import { userReducer } from "./userReducer";

export const rootReducer = combineReducers<AppState>({
    clothesState: clothesReducer,
    offeringsState: offeringsReducer,
    userState: userReducer,
    purchasesState: purchasesReducer,
})