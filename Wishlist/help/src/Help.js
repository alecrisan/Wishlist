import React, { Component } from 'react';
import Accordion from 'react-bootstrap/Accordion';
import './Help.css';

class Help extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        general: [],
        items: [],
        other: []
      };
}

componentDidMount() {
  this.populateItemsData();
}

async populateItemsData() {
  const responseGeneral = await fetch("/api/qas/0");
  const dataGeneral = await responseGeneral.json();

  const responseItems = await fetch("/api/qas/1");
  const dataItems = await responseItems.json();

  const responseOther = await fetch("/api/qas/2");
  const dataOther = await responseOther.json();

  this.setState({ general: dataGeneral, items: dataItems, other: dataOther });
}
  render() {
    return (
      <div className="help">
        <p><b>Need some help?</b></p>
        <Accordion>
          <Accordion.Item eventKey="0">
            <Accordion.Header>General</Accordion.Header>
            <Accordion.Body>
            {this.state.general.map(function (elem, index) {
                  return <Accordion>
                  <Accordion.Item eventKey="10">
                    <Accordion.Header>{elem.question}</Accordion.Header>
                    <Accordion.Body>{elem.answer}</Accordion.Body>
                  </Accordion.Item>
                  </Accordion>;
              })}
            </Accordion.Body>
          </Accordion.Item>
          <Accordion.Item eventKey="1">
            <Accordion.Header>Items</Accordion.Header>
            <Accordion.Body>
            {this.state.items.map(function (elem, index) {
                  return <Accordion>
                  <Accordion.Item eventKey="20">
                    <Accordion.Header>{elem.question}</Accordion.Header>
                    <Accordion.Body>{elem.answer}</Accordion.Body>
                  </Accordion.Item>
                  </Accordion>;
              })}
            </Accordion.Body>
          </Accordion.Item>
          <Accordion.Item eventKey="2">
            <Accordion.Header>Other</Accordion.Header>
            <Accordion.Body>
            {this.state.other.map(function (elem, index) {
                  return <Accordion>
                  <Accordion.Item eventKey="30">
                    <Accordion.Header>{elem.question}</Accordion.Header>
                    <Accordion.Body>{elem.answer}</Accordion.Body>
                  </Accordion.Item>
                  </Accordion>;
              })}
            </Accordion.Body>
          </Accordion.Item>
        </Accordion>
      </div>    
      );
  }
}

export default Help;
