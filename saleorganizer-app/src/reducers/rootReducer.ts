import { combineReducers } from 'redux'
import { fetchClothesReducer } from './fetchClothesReducer'
import { fetchOfferingsReducer } from './fetchOfferingsReducer'
import { fetchPurchasesReducer } from './fetchPurchasesReducer'

export const rootReducer = combineReducers({
    clothes: fetchClothesReducer,
    offerings: fetchOfferingsReducer,
    purchases: fetchPurchasesReducer
})