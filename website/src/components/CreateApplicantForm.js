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
    componentDidMount = () => {
        const debugMode = window.location.search.indexOf("debug")>-1;
        if (debugMode) {
            this.setState({
                Email: "s@shameen.info",
                FirstName: "S",
                LastName: "A",
                DateOfBirth: "1990-01-01"
            })
        }
    }
    onApplicantCreated = () => {
        if (this.props.onApplicantCreated) {
            this.props.onApplicantCreated(this.state.UserId)
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
        const apiBaseUrl = "http://localhost:32775";
        const url = `${apiBaseUrl}/applicant`;

        //Request body
        const formData = new FormData(event.target);
        const json = {};
        formData.forEach((value, key) => {json[key] = value});
        const requestBody = JSON.stringify(json);
        
        const onError = (err) => Promise.reject(err);
        fetch(url, {
            method: 'POST',
            body: requestBody,
            headers: new Headers({"Content-Type": "application/json", "Content-Length": requestBody.length}),
            cache: 'no-cache'
        })
        .then(response => {
            if (response.ok === false) {
                throw alert(`Sorry, something went wrong: ${response.status} ${response.statusText}`);
            }
            else {
                return response.json();
            }
        }, onError)
        .then(data => {
            console.log("Parsed data: ",data);
            this.setState({ UserId: data.userId });
            this.onApplicantCreated(data.userId);
        }, onError);
    };

    render = () => {
        return (
            <form className="CreateApplicantForm" onSubmit={this.onSubmit}>
                <h2>Enter your details to view our mortgages:</h2>
                
                <label>
                    Email:
                    <input type="email" name="Email" value={this.state.Email}
                        onChange={this.onInputChange}
                        maxLength="255"
                        required autoFocus />
                </label>
                <label>
                    First Name:
                    <input type="text" name="FirstName" 
                        value={this.state.FirstName}
                        onChange={this.onInputChange} 
                        maxLength="200"
                        required />
                </label>
                <label>
                    Last Name:
                    <input type="text" name="LastName"
                        value={this.state.LastName}
                        onChange={this.onInputChange} 
                        maxLength="200"
                        required />
                </label>
                <label>
                    Date of Birth:
                    <input type="date" name="DateOfBirth"
                        value={this.state.DateOfBirth}
                        onChange={this.onInputChange} 
                        required />
                </label>
                
                <button type="submit" className="button button-big">
                    Continue
                </button>
            </form>
        );
    }
}