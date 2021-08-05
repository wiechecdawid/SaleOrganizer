import Cloth from './cloth'

export default interface Offering {
    id: number,
    clothId: number,
    cloth: Cloth,
    referenceLink: string,
    price: number,
    tradeType: number,
    deliveryType: number,
    offeringDate: Date,
    orderedDate: Date,
    sendDate: Date
}