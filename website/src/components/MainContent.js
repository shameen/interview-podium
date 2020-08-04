import React from "react";
import "./MainContent.css";
import CreateApplicantForm from "./CreateApplicantForm"

export default class MainContent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userId: null
        }

        this.isLoggedIn = this.state.userId != null && this.state.userId > 0;
        this.loggedInMessage = this.isLoggedIn ? "Logged in as "+this.state.userId : "Not logged in";
    }
    
    render = () => {
        return (
            <div className="MainContent">
                <div className="text-right">{this.loggedInMessage}</div>

                {this.isLoggedIn
                  ? null
                  : <CreateApplicantForm></CreateApplicantForm>
                }
            </div>
        );
    }
}