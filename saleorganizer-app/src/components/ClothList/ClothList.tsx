import { StyledLink } from "../common/StyledLink/StyledLink";
import { useEffect } from "react";
import Cloth from "../../interfaces/cloth";
import { connect } from "react-redux";
import { getClothes } from "../../actions/clothesActions";
import { AppState } from "../../interfaces/states";
import { SuccessButton } from "../common/buttons/SuccessButton";
import { Link } from "react-router-dom";

interface Props {
    clothes: Cloth[] | null,
    getClothes: any
}

const ClothList = ({ clothes, getClothes }: Props) => {
    useEffect(() => {
        getClothes()
    }, [])
    
    return (
    <>
        <StyledLink to="/clothes"><p>Moje ubranka:</p></StyledLink>

        <ul>
            {clothes && 
                clothes.map((cloth: any) => (
                <li key = {cloth.id}>
                    <StyledLink to={`/clothes/${ cloth.id }`}>{cloth.name}</StyledLink>
                </li>
            ))}  
        </ul>
        
        <Link to="/clothes/form">
            <SuccessButton content="Dodaj ubranko" />
        </Link>        
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