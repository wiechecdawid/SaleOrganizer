import { Action } from '../interfaces/action'

const FETCH_REQUEST = 'FETCH_REQUEST'
const FETCH_SUCCESS = 'FETCH_SUCCESS'
const FETCH_FAILURE = 'FETCH_FAILURE'

export const fetchRequest = () => {
    return {
        type: FETCH_REQUEST
    } as Action
}

export const fetchSuccess = (response: any) => {
    return {
        type: FETCH_SUCCESS,
        payload: response
    } as Action
}

export const fetchFailure = (error: string) => {
    return {
        type: FETCH_FAILURE,
        payload: error
    } as Action
}