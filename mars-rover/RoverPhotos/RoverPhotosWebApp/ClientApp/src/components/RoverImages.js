import React, { Component, useState } from 'react';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { Button } from 'reactstrap';



export class RoverImages extends Component { 
    static displayName = RoverImages.name;

    constructor(props) {
        super(props);
        this.state = { images: [], loading: true };
    };

    static Date = () => {
        const [date, setDate] = useState(new Date());
        return (
            <DatePicker selected={date} onChange={newDate => setDate(newDate)} />
        );
    };

    render() {
        return (
            <div>
                <div>
                    {this.Date}
                </div>
                <div style={{ paddingTop: 5 }}>
                    <Button onClick={ this.getImagesByDate() }>Submit</Button>
                </div>
            </div>
        );
    }

    async getImagesByDate() {

    }
}
