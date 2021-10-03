import { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Redirect } from 'react-router-dom';
import styled from 'styled-components';
import { getUser } from '../../actions/userActions';
import { AppState, UserState } from '../../interfaces/states';
import ClothList from '../ClothList/ClothList';
import OfferingList from '../OfferingList/OfferingList';
import PurchaseList from '../PurchaseList/PurchaseList';

const Wrapper = styled.div`
    width: 80vw;
    margin: 20px auto;
    padding: 15px 0px;
    background-color: #eff3f5;
    & ul {
        list-style-type: none;
    }

    & li {
        display: flex;
        justify-content: center;
    }
`

interface Props{
    userState: UserState,
    getUser: any
}

export const MainPage = ({ userState, getUser }: Props) => {
    useEffect( () => {
        getUser()
    }, [])

    return ( userState.data !== null || userState.error !== null ) ? (
        userState?.data ? (   
        <Wrapper>
            <OfferingList />
            <PurchaseList />
            <ClothList />
        </Wrapper>
    ) : (
        <Redirect to={{
            pathname: "/account/login",
            state: { redirectUrl: "/" }
        }} />
    )) : (
        <div>Loading</div>
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

export default connect(mapStateToProps, mapDispatchToProps)(MainPage);