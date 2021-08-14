import Offering from "../interfaces/offering";
import { State } from '../interfaces/state'

const initialClothesState = () => {
    return {
        status: 'idle',
        data: [],
        error: ''
    } as State<Offering>
}

export const fetchOfferingsReducer = (state = initialClothesState, action: any) => {
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