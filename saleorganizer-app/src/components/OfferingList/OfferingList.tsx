import { StyledLink } from "../common/StyledLink/StyledLink";
import Offering from "../../interfaces/offering";
import { AppState } from "../../interfaces/states";
import { connect } from "react-redux";
import { getOfferings } from "../../actions/offeringsActions";
import { useEffect } from "react";

interface Props {
    offerings: Offering[];
    getOfferings: any
}

const OfferingList = ({ offerings, getOfferings }: Props) => {
    useEffect( () => {
        getOfferings()
    }, [])

    return(
    <>
        <StyledLink to="/offerings"><p>Sprzedawane: </p></StyledLink>
        <ul>
            {offerings && 
                offerings.map( (offering: any) => (
                <li key = {offering.id}>
                    <StyledLink to={`/offerings/${ offering.id }`}>{offering.cloth.name}: {offering.price}zł</StyledLink>
                </li>
            ) )}  
        </ul>
    </>
)}

const mapStateToProps = (store: AppState) => {
    return {
        offerings: store.offeringsState.data
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        getOfferings: () => dispatch(getOfferings())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(OfferingList)