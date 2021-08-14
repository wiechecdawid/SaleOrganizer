import { fetchRequest, fetchSuccess, fetchFailure } from "./fetchActions";
import axios from "axios";

const fetchClothes = () => {
    return async (dispatch: any) => {
        dispatch(fetchRequest)
        axios.get('http://localhost:5000/api/clothes')
            .then(response => {
                const clothes = response.data
                dispatch(fetchSuccess(clothes))
            })
            .catch(error => {
                const errorMessage = error.message
                dispatch(fetchFailure(errorMessage))
            })
    }
}

export default fetchClothes