import { ActionCreator, Dispatch } from "redux";
import { ThunkAction } from "redux-thunk";
import axios from "axios";
import Purchase from "../interfaces/purchase";
import { PurchasesState } from "../interfaces/states";

export enum PurchasesActionTypes {
    GET_PURCHASES = 'GET_PURCHASES'
}

export interface GetPurchasesAction {
    type: PurchasesActionTypes.GET_PURCHASES,
    payload: Purchase[]
}

// extend with union operator if you have more actions
export type PurchasesActions = GetPurchasesAction

export const getPurchases: ActionCreator<ThunkAction<Promise<any>, PurchasesState, null, GetPurchasesAction>> = () => {
    return async (dispatch: Dispatch) => {
        try {
            const response = await axios.get('http://localhost:5000/api/purchases')
            dispatch({
                type: PurchasesActionTypes.GET_PURCHASES,
                payload: response.data
            })
        } catch (error) {
            console.error(error);
        }
    }
}