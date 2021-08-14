import { Reducer } from "redux";
import { OfferingsActions, OfferingsActionTypes } from "../actions/offeringsActions";
import { OfferingsState } from "../interfaces/states";

const initialOfferingsState: OfferingsState = {
    data: []
}

export const offeringsReducer: Reducer<OfferingsState, OfferingsActions> = (state = initialOfferingsState, action) => {
    switch(action.type) {
        case OfferingsActionTypes.GET_OFFERINGS: {
            return {
                ...state,
                data: action.payload
            }
        }
        default: return state
    }
}