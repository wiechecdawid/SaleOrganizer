import { useEffect, useState } from "react";
import { connect } from "react-redux";
import { Redirect, RouteComponentProps } from "react-router-dom";
import { ThunkAction } from "redux-thunk";
import { login, LoginAction } from "../../actions/userActions";
import { AppState, UserState } from "../../interfaces/states";
import UserForm from "../../interfaces/userForm";
import { CustomForm } from "../common/CustomForm/CustomForm";
import { ActionCreator } from "redux";
import { saveToken } from "../../helpers/tokenHelpers"

type PassedProps = {
    redirectUrl: string
}

interface Props {
    userState: UserState,
    login: ActionCreator<ThunkAction<Promise<any>, UserState, null, LoginAction>>,
    props?: RouteComponentProps<{location: string}, {}, {state: PassedProps}>
}

export const LoginPage = ({ userState, login, props }: Props) => {
    const [ isLogged, setLogged ] = useState(false)

    useEffect( () => {
        isLogged && saveToken(userState.data!.token)
    }, [isLogged])

    const submitHandler = async(ev: MouseEvent) => {
        ev.preventDefault()

        const email = document.getElementById("login-email") as HTMLInputElement
        const password = document.getElementById("login-password") as HTMLInputElement

        const userForm = {
            email: email?.value,
            password: password?.value
        } as UserForm

        await login(userForm)

        userState?.isLoggedIn && setLogged(true)
    }

    return (
        <>
            {
                isLogged &&
                <Redirect to={props?.location.state.state.redirectUrl || "/"} />
            }
            <CustomForm onSubmit={submitHandler}>
                <input type="text" id="login-email" placeholder="Login" />
                <input type="text" id="login-password" placeholder="Password" />
                <input type="submit" value="Zaloguj" />
            </CustomForm>
        </>
    )
}

function redirect(redirectUrl: string) {
    return <Redirect to={redirectUrl} />
}

const mapStateToProps = (store: AppState) => {
    return {
        userState: store.userState
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        login: (user: UserForm) => dispatch(login(user))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);