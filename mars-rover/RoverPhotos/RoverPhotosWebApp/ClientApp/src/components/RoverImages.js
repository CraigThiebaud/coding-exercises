import React, { Component } from 'react';
import { Form, Field } from 'react-final-form';

export class RoverImages extends Component {
    static displayName = RoverImages.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    async getImagesByDate() {

    }
}
