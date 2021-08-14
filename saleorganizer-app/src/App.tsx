import './App.css';
import { Header } from './components/Header/Header';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { MainPage } from './components/MainPage/MainPage'
import { OfferingList } from './components/OfferingList/OfferingList';
import { PurchaseList } from './components/PurchaseList/PurchaseList';
import { OfferingDetails } from './components/OfferingDetails/OfferingDetails';
import { PurchaseDetails } from './components/PurchaseDetails/PurchaseDetails';
import { ClothList } from './components/ClothList/ClothList';
import { ClothDetails } from './components/ClothDetails/ClothDetails';

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Header />

        <Switch>
          <Route path="/" exact={ true } component={ MainPage } />
          
          <Route exact path="/offerings" component={ OfferingList } />
          <Route path="/offerings/:id" component={ OfferingDetails } />
                
          <Route exact path="/purchases" component={ PurchaseList } />
          <Route path="/purchases/:id" component={ PurchaseDetails } />

          <Route exact path="/clothes" component={ ClothList } />
          <Route path="/clothes/:id" component={ ClothDetails } />

          <Route path="/*">
            <p>Not Found</p>
          </Route>
        </Switch>     
      </div>
    </BrowserRouter> 
  );
}

/*
--------------------------------------------------------------------------------
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
--------------------------------------------------------------------------------
*/

export default App;
