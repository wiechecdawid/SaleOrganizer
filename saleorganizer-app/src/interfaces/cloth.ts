import Photo from './photo'

export default interface Cloth {
    id: number,
    name: string,
    description: string,
    status: number,
    photo: Photo,
    storageInfo: string,
    detailedStorageInfo: string
}