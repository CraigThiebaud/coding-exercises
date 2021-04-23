import React, { Component, useState } from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import ImagePagination from 'react-image-pagination';



export class RoverImages extends Component { 
    static displayName = RoverImages.name;

    constructor(props) {
        super(props);
        this.state = { images: [], loading: true, startDate: new Date() };
        this.setSelectedDate = this.setSelectedDate.bind(this);
        this.submit = this.submit.bind(this);
        this.setPages = this.setPages.bind(this);
    };

    setSelectedDate(date) {
        this.setState({
            startDate: date
        })
    }

    async submit() {
        var x = this.state.startDate.toDateString();
        const response = await fetch(`roverimage?date=${x}`);
        const data = await response.json();
        this.setState({ images: data, loading: false });
    }

    render() {
        return (
            <div>
                <div className="App">
                    <header className="App-header">
                        <ImagePagination
                            pages={ this.setPages(this.state.images) }
                            dotDisplay={true}
                        />
                    </header>
                </div>
                <div>
                    <div>
                        <DatePicker
                            selected={this.state.startDate}
                            onChange={this.setSelectedDate}
                            name="startDate"
                            dateFormat="MM/dd/yyyy"
                        />
                        <button className="btn btn-primary" onClick={ this.submit }>Get Images</button>
                    </div>
                </div>
            </div>
        );
    }

    setPages(images) {
        var pages = [];
        images.forEach(x => pages.push({ src: x }))
        return pages;
    }
}
