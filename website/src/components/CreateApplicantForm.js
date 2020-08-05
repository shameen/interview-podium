import React from 'react';
import "./_forms.css"

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
    server = {
        createApplicant: (formElement) => {
            const url = `${window.ApiBaseUrl}/applicant`;

            //Request body
            const formData = new FormData(formElement);
            const json = {};
            formData.forEach((value, key) => {json[key] = value});
            const requestBody = JSON.stringify(json);
            
            const onError = (err) => Promise.reject(err);
            return fetch(url, {
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
                this.events.onApplicantCreated(data.userId);
            }, onError);
        }
    }
    events = {
        /** Propagate event to parent */
        onApplicantCreated: () => {
            if (this.props.onApplicantCreated) {
                this.props.onApplicantCreated(this.state.UserId)
            }
        },
        onFormInputChange: (event) => {
            const target = event.target;
            this.setState({
                [target.name]: target.value
            });
        },
        onFormSubmit: (event) => {
            event.preventDefault();

            //validation
            let errors = [];
            if (this.state.Email.length === 0) errors.push("Please enter an Email");
            if (this.state.FirstName.length === 0) errors.push("Please enter a First Name");
            if (this.state.LastName.length === 0) errors.push("Please enter a Last Name");
            if (this.state.DateOfBirth === null) errors.push("Please enter a Date of Birth");
            if (errors.length) {
                alert("We think you missed something: \n"+errors.join("\n"));
                return;
            }

            this.server.createApplicant(event.target);
        }
    }

    render = () => {
        return (
            <form className="CreateApplicantForm form" onSubmit={this.events.onFormSubmit}>
                <h2>Enter your details to view our mortgages:</h2>
                
                <label>
                    Email:
                    <input type="email" name="Email" value={this.state.Email}
                        onChange={this.events.onFormInputChange}
                        maxLength="255"
                        required autoFocus />
                </label>
                <label>
                    First Name:
                    <input type="text" name="FirstName" 
                        value={this.state.FirstName}
                        onChange={this.events.onFormInputChange} 
                        maxLength="200"
                        required />
                </label>
                <label>
                    Last Name:
                    <input type="text" name="LastName"
                        value={this.state.LastName}
                        onChange={this.events.onFormInputChange} 
                        maxLength="200"
                        required />
                </label>
                <label>
                    Date of Birth:
                    <input type="date" name="DateOfBirth"
                        value={this.state.DateOfBirth}
                        onChange={this.events.onFormInputChange} 
                        required />
                </label>
                
                <button type="submit" className="button button-big">
                    Continue
                </button>
            </form>
        );
    }
}