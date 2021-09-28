import { Reducer } from "redux"
import { UserActions, UserActionTypes } from "../actions/userActions"
import { UserState } from "../interfaces/states"

const initialUserState: UserState = {
    data: null,
    error: null,
    isLoggedIn: false
}

export const userReducer: Reducer<UserState, UserActions> = (state = initialUserState, action) => {
    switch(action.type) {
        case UserActionTypes.GET_USER: 
        case UserActionTypes.REGISTER:
        case UserActionTypes.LOGIN: {
            return {
                ...state,
                data: action.payload,
                isLoggedIn: true,
                error: action.error
            }
        }
        default: return state
    }
}