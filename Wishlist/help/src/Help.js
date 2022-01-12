import React, { Component } from 'react';
import Accordion from 'react-bootstrap/Accordion';
import './Help.css';

class Help extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        items: []
      };
}

componentDidMount() {
  this.populateItemsData();
}

async populateItemsData() {
  // const response = await fetch("/api/items");
  // const data = await response.json();
  // this.setState({ items: data});
}
  render() {
    return (
      <div className="help">
        <p><b>Need some help?</b></p>
        <Accordion>
          <Accordion.Item eventKey="0">
            <Accordion.Header>General</Accordion.Header>
            <Accordion.Body>
              <Accordion>
                <Accordion.Item eventKey="10">
                  <Accordion.Header>How do I create a wishlist?</Accordion.Header>
                  <Accordion.Body>idk</Accordion.Body>
                </Accordion.Item>
                <Accordion.Item eventKey="11">
                  <Accordion.Header>Can I install it on my phone?</Accordion.Header>
                  <Accordion.Body>idk</Accordion.Body>
                </Accordion.Item>
              </Accordion>
            </Accordion.Body>
          </Accordion.Item>
          <Accordion.Item eventKey="1">
            <Accordion.Header>Items</Accordion.Header>
            <Accordion.Body>
            <Accordion>
                <Accordion.Item eventKey="20">
                  <Accordion.Header>How do I add an item to my wishlist?</Accordion.Header>
                  <Accordion.Body>idk</Accordion.Body>
                </Accordion.Item>
                <Accordion.Item eventKey="21">
                  <Accordion.Header>How do I delete an item?</Accordion.Header>
                  <Accordion.Body>idk</Accordion.Body>
                </Accordion.Item>
              </Accordion>
            </Accordion.Body>
          </Accordion.Item>
    </Accordion>
      </div>    
      );
  }
}

export default Help;
