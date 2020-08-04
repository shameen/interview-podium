import React from 'react';
import "./CreateApplicantForm.css"

export default class CreateApplicantForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            UserId: 0,
            Email: "",
            FirstName: "",
            LastName: "",
            DateOfBirth: undefined
        }
    }
    onInputChange = (event) => {
        const target = event.target;
        this.setState({
            [target.name]: target.value
        });
    }
    onSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.target);
        const apiBaseUrl = "http://localhost:32769";
        const url = `${apiBaseUrl}/applicant`;
        
        fetch(url, {
            method: 'POST',
            body: data,
        });
    };
    render = () => {
        return (
            <form className="CreateApplicantForm" onSubmit={this.onSubmit}>
                <h2>Enter your details to view our mortgages:</h2>
                
                <label>
                    Email: (required)
                    <input type="email" name="Email" value={this.state.Email}
                        onChange={this.onInputChange}
                        required autoFocus />
                </label>
                <label>
                    First Name:
                    <input type="text" name="FirstName" 
                        value={this.state.FirstName}
                        onChange={this.onInputChange} />
                </label>
                <label>
                    Last Name:
                    <input type="text" name="LastName"
                        value={this.state.LastName}
                        onChange={this.onInputChange} />
                </label>
                <label>
                    Date of Birth:
                    <input type="date" name="DateOfBirth"
                        value={this.state.DateOfBirth}
                        onChange={this.onInputChange} />
                </label>
                
                <button type="submit" className="button button-big">
                    Continue
                </button>
            </form>
        );
    }
}