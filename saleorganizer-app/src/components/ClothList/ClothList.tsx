import { StyledLink } from "../common/StyledLink/StyledLink";
import { useEffect } from "react";
import Cloth from "../../interfaces/cloth";
import { Dispatch } from "redux"
import { connect } from "react-redux";
import { getClothes } from "../../actions/clothesActions";
import { AppState } from "../../interfaces/states";

interface Props {
    clothes: Cloth[],
    getClothes: any
}

const ClothList = ({ clothes, getClothes }: Props) => {
    useEffect(() => {
        getClothes()
    }, [])
    
    return (
    <>
        <p>Moje ubranka:</p>
        <ul>
            {clothes && 
                clothes.map((cloth: any) => (
                <li key = {cloth.id}>
                    <StyledLink to={`/clothes/${ cloth.id }`}>{cloth.name}</StyledLink>
                </li>
            ))}  
        </ul>
    </>
)}

const mapStateToProps = (store: AppState) => {
    return {
        clothes: store.clothesState.data
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        getClothes: () => dispatch(getClothes())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ClothList);