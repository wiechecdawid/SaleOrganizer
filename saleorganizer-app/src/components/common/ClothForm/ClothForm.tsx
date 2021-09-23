import axios from "axios";
import { FormEvent } from "react";
import { Redirect } from "react-router";
import Cloth from "../../../interfaces/cloth";

type FormType = 'edit' | 'add'

interface Props {
    type: FormType,
    cloth?: Cloth
}

export const ClothForm = ( { type='add', cloth }: Props ) => {
    const submitHandler = async(ev: FormEvent) => {
        ev.preventDefault()

        const clothName = document.querySelector('#clothTitle') as HTMLInputElement
        const clothDesc = document.querySelector('#clothDescription') as HTMLInputElement
        const clothInfo = document.querySelector('#storageInfo') as HTMLInputElement
        const detailed = document.querySelector('#detailedStorageInfo') as HTMLInputElement
        
        const body = {
            id: cloth?.id,
            name: clothName.value,
            description: clothDesc.value,
            status: cloth?.status ?? 2,
            storageInfo: clothInfo.value,
            detailedStorageInfo: detailed.value
        } as Cloth

        const serviceUrl = 'http://localhost:5000/api/clothes'

        if(type==='add') {
            console.log(body)
            await axios({
                    method: "post",
                    url: serviceUrl,
                    data: body
                }).catch( error => {
                    console.log(error)
                })
            return <Redirect to="/clothes" />
        }
    }

    return (
        <form onSubmit={submitHandler}>
            <label htmlFor="clothTitle">Nazwa ubranka: </label>
            <input type="text" id="clothTitle" placeholder={cloth?.name && 'Nazwa ubranka'} value={cloth?.name} />

            <label htmlFor="clothDescription">Opis: </label>
            <input type="text" id="clothDescription" placeholder={cloth?.description && 'Opis ubranka'}
                value={cloth?.description} />

            <label htmlFor="storageInfo">Miejsce przechowywania: </label>
            <input type="text" id="storageInfo" placeholder={cloth?.storageInfo && 'Napisz, gdzie trzymasz ubranko'}
                value={cloth?.storageInfo} />

            <label htmlFor="detailedStorageInfo">Miejsce przechowywania: </label>
            <input type="text" id="detailedStorageInfo" placeholder={cloth?.detailedStorageInfo && 'Napisz, gdzie trzymasz ubranko'}
                value={cloth?.detailedStorageInfo} />

            <input type="submit" value="Potwierdź" />
        </form>
)}