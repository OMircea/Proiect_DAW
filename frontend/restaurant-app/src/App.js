import React from 'react';
import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Restaurant} from './Restaurant';
import {Client} from './Client';
import {Waiter} from './Waiter';
import {ClientRestaurant} from './ClientRestaurant';
import {BrowserRouter, Route, Switch, NavLink} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="App container">
      <h3 className="d-flex justify-content-center m-3">
          Restaurant Frontend
      </h3>

      <nav className="navbar navbar-expand-sm bg-light navbar-dark">
        <ul className="navbar-nav">
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/home">
              Home
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/restaurant">
              Restaurant
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/client"> 
              Client
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/waiter">
              Waiter
            </NavLink>
          </li>
          <li className="nav-item- m-1">
            <NavLink className="btn btn-light btn-outline-primary" to="/clientrestaurant">
              ClientRestaurant
            </NavLink>
          </li>
        </ul>
      </nav>
      <Switch>
        <Route path='/home' component={Home}/>
        <Route path='/restaurant' component={Restaurant}/>
        <Route path='/client' component={Client}/>
        <Route path='/waiter' component={Waiter}/>
        <Route path='/clientrestaurant' component={ClientRestaurant}/>
      </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
