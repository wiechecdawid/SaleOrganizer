import Purchase from '../../Interfaces/Purchase';

interface Props {
    purchase: Purchase
}

export const PurchaseDetails = ({ purchase }: Props) => (
    <div className="offeringDetails">
        <h1>{purchase.cloth.name}</h1>
        <h5>{`${purchase.purchaseDate} - ${purchase.tradeType}`}</h5>
    </div>
)