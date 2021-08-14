import { Action } from "../interfaces/action";
import Cloth from "../interfaces/cloth";
import { State } from '../interfaces/state'

const initialClothesState = () => {
    return {
        status: 'idle',
        data: [],
        error: ''
    } as State<Cloth>
}

export const fetchClothesReducer = (state = initialClothesState, action: Action) => {
    switch(action.type){
        case 'FETCH_REQUEST':
            return {
                ...state,
                status: 'pending'
            }
        case 'FETCH_SUCCESS':
            return {
                status: 'succeeded',
                data: action.payload,
                error: ''
            }
        case 'FETCH_FAILED':
            return {
                status: 'failed',
                data: [],
                error: action.payload
            }
        default: return state
    }
}