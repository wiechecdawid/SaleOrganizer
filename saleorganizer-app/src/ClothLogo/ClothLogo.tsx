//import React from 'react' Since react 17 no longer needed
import { Link } from 'react-router-dom'
import logo from '../assets/garderobe.png'

const clothLogo = () => (
    <Link to="/">
        <img src={logo} alt="Logo" width="50px" />
    </Link>
)

export default clothLogo