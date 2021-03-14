import Offering from "../../Interfaces/Offering";

interface Props {
    offerings: Offering[];
}

export const OfferingList = ({offerings}: Props) => (
    <div className="HomeDashBoard">
        <ul>
            {offerings.map((offering: any) => (
            <li key = {offering.id}>
                {offering.cloth.name}: {offering.price}zł
            </li>
            ))}  
        </ul>
    </div>
)