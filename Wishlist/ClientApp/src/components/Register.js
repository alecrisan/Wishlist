import React, { Component } from 'react';
import { Navigate } from 'react-router-dom';
export class Register extends Component {
    static displayName = Register.name;

    constructor(props) {
        super(props);
        this.state = { redirect: "/Identity/Account/Register" };
    }

    render() {
        if (this.state.redirect) {
            return <Navigate to={this.state.redirect} />
        }
        return (
            <div>
            </div>
        );
    }
}
