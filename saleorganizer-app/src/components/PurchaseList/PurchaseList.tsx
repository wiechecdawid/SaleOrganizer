import { useEffect } from "react";
import { connect } from "react-redux";
import { getPurchases } from "../../actions/purchasesActions";
import Purchase from "../../interfaces/purchase";
import { AppState } from "../../interfaces/states";
import { StyledLink } from "../common/StyledLink/StyledLink"

interface Props {
    purchases: Purchase[],
    getPurchases: any
}

const PurchaseList = ( { purchases, getPurchases }: Props) => {
    useEffect( () => {
        getPurchases()
    }, [])
    
    return (
    <div>
        <StyledLink to="/purchases"><p>Kupowane: </p></StyledLink>
        <ul>
            {purchases &&
                purchases.map((purchase: Purchase) => (
                <li key = {purchase.id}>
                    <StyledLink to={`/purchases/${purchase.id}`}>{ purchase.cloth.name }: { purchase.price }zł</StyledLink>
                </li>
            ))}
        </ul>
    </div>        
)}

const mapStateToProps = (store: AppState) => {
    return {
        purchases: store.purchasesState.data
    }
}

const mapDispatchToProps = (dispatch: any) => {
    return {
        getPurchases: () => dispatch(getPurchases())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(PurchaseList)