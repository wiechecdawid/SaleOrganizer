import { useEffect, useState, useReducer } from 'react';
import './App.css';
import axios from 'axios';
import Cloth from './interfaces/cloth';
import Offering from './interfaces/offering';
import Purchase from './interfaces/purchase';
import { Header } from './Components/Header/Header';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { MainPage } from './Components/MainPage/MainPage'
import { ClothList } from './Components/ClothList/ClothList';
import { OfferingList } from './Components/OfferingList/OfferingList';
import { PurchaseList } from './Components/PurchaseList/PurchaseList';

function App() {
  const [clothes, setClothes] = useState<Cloth[]>([]);
  const [offerings, setOfferings] = useState<Offering[]>([])
  const [purchases, setPurchases] = useState<Purchase[]>([])

  useEffect( () => {
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
    <BrowserRouter>
      <div className="App">
        <Header />

        <Switch>
          <Route path="/" exact={ true } >
            <MainPage>
              {
                offerings &&
                <OfferingList offerings = { offerings } />
              }
              {
                purchases &&
                <PurchaseList purchases = { purchases } />
              }
              {
                clothes &&
                <ClothList clothes = { clothes } />
              }
            </MainPage>
          </Route>

          <Route path="/*">
            <p>Not Found</p>
          </Route>
        </Switch>     
      </div>
    </BrowserRouter>    
  );
}

export default App;
