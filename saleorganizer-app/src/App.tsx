import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header } from './Header/Header';

function App() {
  const [clothes, setClothes] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/clothes').then(response => {
      console.log(response);
      setClothes(response.data);
    })
  }, [])

  return (
    <div className="App">
      <Header />
      <ul>
          {clothes.map((cloth: any) => (
            <li key = {cloth.id}>
              {cloth.name}
            </li>
          ))}  
        </ul>
    </div>
  );
}

export default App;
