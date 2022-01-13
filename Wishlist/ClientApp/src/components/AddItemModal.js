import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import './AddItemModal.css';

export default class AddItemModal extends Component {
    constructor(props, context) {
        super(props, context);

        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.handleAdd = this.handleAdd.bind(this);

        this.state = {
            show: false,
        };
    }

    handleClose() {
        this.setState({ show: false });
    }

    handleShow() {
        this.setState({ show: true });
    }

    async handleAdd() {
        await fetch('/api/items', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                name: this.refs.name.value,
                description: this.refs.description.value
            })
        }).then(response => response.json())
    }
    
    render() {
        return (
            <div>

                <li className="item flex-item" onClick={this.handleShow}>
                    <i className="fa fa-plus" href="#"></i>
                </li>
                
                <Modal show={this.state.show} onHide={this.handleClose} centered>
                    <Modal.Header closeButton>
                        <Modal.Title>New item</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                            <Form.Group controlId="formGroupName">
                                <Form.Label>Name<i style={{ color: "red" }}>*</i></Form.Label>
                                <Form.Control name="name" ref="name" required />
                            </Form.Group>
                            <Form.Group controlId="formGroupDescription">
                                <Form.Label>Description</Form.Label>
                                <Form.Control name="description" ref="description" as="textarea"/>
                            </Form.Group>
                            <div className="buttons">
                                <Button type="submit" onClick={this.handleAdd} style={{ margin: "5px", backgroundColor: 'indigo', border: 'none' }}>
                                    Submit </Button>
                                <Button onClick={this.handleClose} style={{ backgroundColor: 'indigo', border: 'none' }}>Cancel</Button>
                            </div>
                        </Form>
                    </Modal.Body>
                </Modal>
            </div>
        );
    }
}