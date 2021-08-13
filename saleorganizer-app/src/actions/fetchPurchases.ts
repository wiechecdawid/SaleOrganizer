import { fetchRequest, fetchSuccess, fetchFailure } from "./fetchActions";
import axios from "axios";

const fetchPurchases = () => {
    return (dispatch: any) => {
        dispatch(fetchRequest)
        axios.get('http://localhost:5000/api/clothes')
            .then(response => {
                const purchases = response.data
                dispatch(fetchSuccess(purchases))
            })
            .catch(error => {
                const errorMessage = error.message
                dispatch(fetchFailure(errorMessage))
            })
    }
}

export default fetchPurchases