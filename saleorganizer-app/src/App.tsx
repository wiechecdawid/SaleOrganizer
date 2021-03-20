import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import Cloth from './Interfaces/Cloth';
import Offering from './Interfaces/Offering';
import Purchase from './Interfaces/Purchase';
import { Header } from './Header/Header';
import { HomeDashboard } from './HomeDashboard/HomeDashboard'

function App() {
  const [clothes, setClothes] = useState<Cloth[]>([]);
  const [offerings, setOfferings] = useState<Offering[]>([])
  const [purchases, setPurchases] = useState<Purchase[]>([])

  useEffect(() => {
    axios.get<Cloth[]>('http://localhost:5000/api/clothes').then(response => {
      console.log(response);
      setClothes(response.data);
    })
    axios.get<Offering[]>('http://localhost:5000/api/offerings').then(response => {
      console.log(response)
      setOfferings(response.data)
    })
    axios.get<Purchase[]>('http://localhost:5000/api/purchases').then(response => {
      console.log(response)
      setPurchases(response.data)
    })
  }, [])

  return (
    <div className="App">
      <Header />
      <HomeDashboard clothes={ clothes } offerings={ offerings } purchases={ purchases } cloth={ clothes[0] } offering={ offerings[0] } purchase={ purchases[0] } />
      
    </div>
  );
}

export default App;
