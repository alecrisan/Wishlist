import React, { Component } from 'react';
import AddItemModal from './AddItemModal';
import Spinner from 'react-bootstrap/Spinner';
import Button from 'react-bootstrap/Button';
import authService from './api-authorization/AuthorizeService';
import './Home.css';
import EditItemModal from './EditItemModal';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
        items: [],
        loading: true,
        isAuthenticated: false,
        role: null
      };

        this.handleDelete = this.handleDelete.bind(this);
}

componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
    this.populateItemsData();
}

componentWillUnmount() {
    authService.unsubscribe(this._subscription);
}

async populateState() {
  const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
  this.setState({
      isAuthenticated,
      role: user && user.role
  });
}

async populateItemsData() {
   const token = await authService.getAccessToken();
  const response = await fetch("/api/wishlists", {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}`,
    'Content-type': 'application/json' }
});
  const data = await response.json();
  this.setState({ items: data.items, loading: false});
}

async handleDelete(idDeleted) {
  var items = this.state.items.filter(item => item.id !== idDeleted)

  this.setState({ items: items });

  await fetch("/api/items/" + idDeleted, {
      method: 'DELETE'
  }).then(response => response.json())
      .catch((error => {
          console.log(error);
      }));
}

  render () {
    let _this = this;
    return (
      <div>
        <h1 className="title">My Wishlist</h1>
        {
          this.state.loading ?  
          this.state.isAuthenticated ?
          <div style={{ display: 'flex', justifyContent: 'center', marginRight: '180px' }}>
          <Spinner animation="border" role="status">
              <span className="sr-only"></span>
          </Spinner>
          </div>
          :
          <div>You must be logged in to view your wishlist.</div>
          : 
          <div>
            { this.state.items && this.state.items.length !== 0 ? <h1><i></i></h1> : <h3>No available items</h3>}
            <ul className="container flex">          
              {this.state.items && this.state.items.map(function (elem, index) {
                  return <li key={index} className="item flex-item">
                            {elem.name}
                            <div >
                              <Button onClick={() => _this.handleDelete(elem.id)} className="delete"><i className="fa fa-trash-o"/></Button>
                              <EditItemModal item={elem}/>
                            </div>  
                        </li>;
              })}
              <AddItemModal/>
            </ul>
          </div>           
        }           
      </div>     
    );
  }
}
