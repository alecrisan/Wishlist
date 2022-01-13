import React, { Component } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default class EditItemModal extends Component {
    constructor(props, context) {
        super(props, context);

        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.handleEdit = this.handleEdit.bind(this);

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

    async handleEdit() {

        await fetch('api/items', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: this.props.item.id,
                name: this.refs.name.value,
                description: this.refs.description.value 
            })
        }).then(response => response.json())
            .catch((error => {
                console.log(error);
            }));
    }
    
    render() {
        return (
            <div> 
                <Button bsstyle="primary" bssize="large" onClick={this.handleShow} style={{ backgroundColor: 'indigo' }}>
                    <i class="fa fa-edit"></i>
                </Button>
          
                <Modal show={this.state.show} onHide={this.handleClose} centered>
                    <Modal.Header closeButton>
                        <Modal.Title>Edit item</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                            <Form.Group controlId="formGroupName">
                                <Form.Label>Name<i style={{ color: "red" }}>*</i></Form.Label>
                                <Form.Control name="name" ref="name" required  defaultValue={this.props.item.name}/>
                            </Form.Group>
                            <Form.Group controlId="formGroupDescription">
                                <Form.Label>Description</Form.Label>
                                <Form.Control name="description" ref="description" as="textarea" defaultValue={this.props.item.description}/>
                            </Form.Group>
                            <div className="buttons">
                                <Button type="submit" onClick={this.handleEdit} style={{ margin: "5px", backgroundColor: 'indigo', border: 'none' }}>
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