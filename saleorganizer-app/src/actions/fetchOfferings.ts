import { fetchRequest, fetchSuccess, fetchFailure } from "./fetchActions";
import axios from "axios";

const fetchOfferings = () => {
    return (dispatch: any) => {
        dispatch(fetchRequest)
        axios.get('http://localhost:5000/api/clothes')
            .then(response => {
                const offerings = response.data
                dispatch(fetchSuccess(offerings))
            })
            .catch(error => {
                const errorMessage = error.message
                dispatch(fetchFailure(errorMessage))
            })
    }
}

export default fetchOfferings