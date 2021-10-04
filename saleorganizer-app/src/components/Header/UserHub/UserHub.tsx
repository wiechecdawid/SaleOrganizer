import { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom';
import styled from 'styled-components';
import { getUser } from '../../../actions/userActions';
import { resetToken } from '../../../helpers/tokenHelpers';
import { AppState, UserState } from '../../../interfaces/states';
import { DeleteButton } from '../../common/buttons/DeleteButton';
import { SuccessButton } from '../../common/buttons/SuccessButton';

const Wrapper = styled.div`
    position: absolute;
    right: 10px;
`

interface Props{
    userState: UserState,
    getUser: any
}

export const UserHub = ({ userState, getUser }: Props) => {
    useEffect( () => {
        getUser()
    }, [])

    const logoutHandler = () => {
        resetToken()
        window.location.reload()
    }

    return userState?.data ? (   
        <Wrapper>
            <div>Witaj, {userState.data.userName}</div>
            <DeleteButton content="Wyloguj" onClick={logoutHandler} />
        </Wrapper>
    ) : (
        <Wrapper>
            <SuccessButton content="Login" onClick={() => {}}/>
        </Wrapper>
    )
}

const mapStateToProps = (store: AppState) => {
    return {
        userState: store.userState
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        getUser: () => dispatch(getUser())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UserHub);