import Offering from '../../Interfaces/Offering';

interface Props {
    offering: Offering
}

export const OfferingDetails = ({ offering }: Props) => (
    <div className="offeringDetails">
        <h1>{offering.cloth.name}</h1>
        <h5>{`${offering.offeringDate} - ${offering.tradeType}`}</h5>
    </div>
)