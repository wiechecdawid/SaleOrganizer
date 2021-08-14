import Purchase from "../interfaces/purchase";
import { State } from '../interfaces/state'

const initialClothesState = () => {
    return {
        status: 'idle',
        data: [],
        error: ''
    } as State<Purchase>
}

export const fetchPurchasesReducer = (state = initialClothesState, action: any) => {
    switch(action.type){
        case 'FETCH_REQUEST':
            return {
                ...state,
                status: 'pending'
            }
        case 'FETCH_SUCCESS':
            return {
                ...state,
                status: 'succeeded'
            }
        case 'FETCH_FAILED':
            return {
                ...state,
                status: 'failed'
            }
        default: return state
    }
}