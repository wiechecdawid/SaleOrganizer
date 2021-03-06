import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

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
      <header className="App-header">
        <ul>
          {clothes.map((cloth: any) => (
            <li key = {cloth.id}>
              {cloth.name}
            </li>
          ))}  
        </ul>
      </header>
    </div>
  );
}

export default App;
