import { ThunkAction } from "redux-thunk";
import { UserState } from "../interfaces/states";
import User from "../interfaces/user";
import { ActionCreator, Dispatch } from "redux";
import axios from "axios";
import UserForm from "../interfaces/userForm";

export enum UserActionTypes {
    GET_USER = 'GET_USER',
    LOGIN = 'LOGIN',
    REGISTER = 'REGISTER'
}

export interface GetUserAction {
    type: UserActionTypes.GET_USER,
    payload: User | null,
    error: any | null
}

export interface LoginAction {
    type: UserActionTypes.LOGIN,
    payload: User | null,
    error: any | null
}

export interface RegisterAction {
    type: UserActionTypes.REGISTER,
    payload: User | null,
    error: any | null
}

export type UserActions = GetUserAction |
    LoginAction |
    RegisterAction

export const getUser: ActionCreator<ThunkAction<Promise<any>, UserState, null, GetUserAction>> = () => {
    return async (dispatch: Dispatch) => {
        try {
            const response = await axios.get('http://localhost:5000/api/account')

            if(response.status !== 200) {
                throw new Error(response.statusText)
            }
            
            dispatch({
                type: UserActionTypes.GET_USER,
                payload: response.data as User,
                error: null
            })
        } catch (error) {
            console.error(error);
            dispatch({
                type: UserActionTypes.GET_USER,
                payload: null,
                error: error
            })
        }
    }
}

export const login: ActionCreator<ThunkAction<Promise<any>, UserState, null, LoginAction>> = (user: UserForm) => {
    return async (dispatch: Dispatch) => {
        try {
            const response = await axios.post<User>('http://localhost:5000/api/account/login', user)

            if(response.status !== 200) {
                throw new Error(response.statusText)
            }

            dispatch({
                type: UserActionTypes.LOGIN,
                payload: response.data as User,
                error: null
            })
        } catch (error) {
            console.error(error);
            dispatch({
                type: UserActionTypes.GET_USER,
                payload: null,
                error: error
            })
        }
    }
}

export const register: ActionCreator<ThunkAction<Promise<any>, UserState, null, RegisterAction>> = (user: UserForm) => {
    return async (dispatch: Dispatch) => {
        try {
            const response = await axios.post<User>('http://localhost:5000/api/account/register', user)

            if(response.status !== 200) {
                throw new Error(response.statusText)
            }
            
            dispatch({
                type: UserActionTypes.REGISTER,
                payload: response.data as User,
                error: null
            })
        } catch (error) {
            console.error(error);
            dispatch({
                type: UserActionTypes.GET_USER,
                payload: null,
                error: error
            })
        }
    }
}