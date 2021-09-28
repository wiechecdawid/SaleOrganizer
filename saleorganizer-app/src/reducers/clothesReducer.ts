import { Reducer } from "redux";
import { ClothesActions, ClothesActionTypes } from "../actions/clothesActions";
import { ClothesState } from "../interfaces/states";

const initialClothesState: ClothesState = {
    data: [],
    error: null
}

export const clothesReducer: Reducer<ClothesState, ClothesActions> = (state = initialClothesState, action) => {
    switch(action.type) {
        case ClothesActionTypes.GET_CLOTHES: {
            return {
                ...state,
                data: action.payload,
                error: action.error                
            }
        }
        default: return state
    }
}