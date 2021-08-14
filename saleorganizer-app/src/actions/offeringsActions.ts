import { ActionCreator, Dispatch } from "redux";
import { ThunkAction } from "redux-thunk";
import axios from "axios";
import Offering from "../interfaces/offering";
import { ClothesState } from "../interfaces/states";

export enum OfferingsActionTypes {
    GET_OFFERINGS = 'GET_OFFERINGS'
}

export interface GetOfferingsAction {
    type: OfferingsActionTypes.GET_OFFERINGS,
    payload: Offering[]
}

// extend with union operator if you have more actions
export type OfferingsActions = GetOfferingsAction

export const getOfferings: ActionCreator<ThunkAction<Promise<any>, ClothesState, null, GetOfferingsAction>> = () => {
    return async (dispatch: Dispatch) => {
        try {
            const response = await axios.get('http://localhost:5000/api/offerings')
            dispatch({
                type: OfferingsActionTypes.GET_OFFERINGS,
                payload: response.data
            })
        } catch (error) {
            console.error(error);
        }
    }
}