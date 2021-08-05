import Cloth from '../../interfaces/cloth'

interface Props {
    cloth: Cloth
}

export const ClothDetails = ({ cloth }: Props) => (
    <div className="ClothDetails">
        <h1> { cloth.name } </h1>
        <h5> { cloth.status } </h5>
        <p> { cloth.description } </p>
    </div>
)