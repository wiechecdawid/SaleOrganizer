import { Reducer } from "redux";
import { PurchasesActions, PurchasesActionTypes } from "../actions/purchasesActions";
import { PurchasesState } from "../interfaces/states";

const initialPurchasesState: PurchasesState = {
    data: []
}

export const purchasesReducer: Reducer<PurchasesState, PurchasesActions> = (state = initialPurchasesState, action) => {
    switch(action.type) {
        case PurchasesActionTypes.GET_PURCHASES: {
            return {
                ...state,
                data: action.payload
            }
        }
        default: return state
    }
}