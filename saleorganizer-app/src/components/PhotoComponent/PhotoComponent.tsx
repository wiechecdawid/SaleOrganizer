import { useState, useEffect } from 'react'
import styled from 'styled-components'

const PhotoWrapper = styled.div`
`

const Image = styled.img`
    border-radius: 10%;
    overflow: hidden;  
`

interface Props {
    url: string
}

const PhotoComponent = ( { url }: Props ) => (
        <PhotoWrapper>
            <Image src={url} alt="Photo" />
        </PhotoWrapper>
)

export default PhotoComponent