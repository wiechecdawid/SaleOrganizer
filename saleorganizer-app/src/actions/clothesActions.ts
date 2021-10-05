import { ActionCreator, Dispatch } from "redux";
import { ThunkAction } from "redux-thunk";
import axios from "axios";
import Cloth from "../interfaces/cloth";
import { ClothesState } from "../interfaces/states";
import { getToken } from "../helpers/tokenHelpers";

export enum ClothesActionTypes {
    GET_CLOTHES = 'GET_CLOTHES'
}

export interface GetClothesAction {
    type: ClothesActionTypes.GET_CLOTHES,
    payload: Cloth[] | null,
    error: any | null
}

// extend with union operator if you have more actions
export type ClothesActions = GetClothesAction

export const getClothes: ActionCreator<ThunkAction<Promise<any>, ClothesState, null, GetClothesAction>> = () => {
    return async (dispatch: Dispatch) => {
        try {
            const token = getToken()

            const config = {
                headers: {
                    authorization: `Bearer ${token}`
                }
            }
            
            const response = await axios.get('http://localhost:5000/api/clothes', config)

            if(response.status !== 200) {
                throw new Error(response.statusText)
            }
            
            dispatch({
                type: ClothesActionTypes.GET_CLOTHES,
                payload: response.data,
                error: null
            })
        } catch (error) {
            console.error(error);
            dispatch({
                type: ClothesActionTypes.GET_CLOTHES,
                error: error,
                payload: null
            })
        }
    }
}