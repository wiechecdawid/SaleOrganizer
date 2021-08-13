import redux from 'redux'
import { fetchClothesReducer } from './fetchClothesReducer'
import { fetchOfferingsReducer } from './fetchOfferingsReducer'
import { fetchPurchasesReducer } from './fetchPurchasesReducer'

const combineReducers = redux.combineReducers

export const rootReducer = combineReducers({
    clothes: fetchClothesReducer,
    offerings: fetchOfferingsReducer,
    purchases: fetchPurchasesReducer
})