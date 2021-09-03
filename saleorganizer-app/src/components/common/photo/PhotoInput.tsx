import { ChangeEventHandler } from "react"

export const PhotoInput = () => {
    const addPhotoHandler: ChangeEventHandler<HTMLInputElement> = (ev) => {
        console.log("Some file has been uploaded!")
    }
    
    return(
        <label>
            <input type="file" onChange={addPhotoHandler}/>
            Add Photo
        </label>
    )
}