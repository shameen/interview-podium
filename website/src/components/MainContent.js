import React from "react";
import "./MainContent.css";
import CreateApplicantForm from "./CreateApplicantForm"
import MortgageProductsPage from "./MortgageProducts";

export default class MainContent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userId: null
        }
    }
    isLoggedIn = () => this.state && typeof this.state.userId === "number" && this.state.userId > 0;
    loggedInMessage = () => this.isLoggedIn()
        ? "Your application reference: "+this.state.userId
        : "";

    onApplicantCreated = (userId) => {
        this.setState({userId: userId});
    }
    
    render = () => {
        return (
            <div className="MainContent">
                <div className="text-right">{this.loggedInMessage()}</div>

                {this.isLoggedIn()
                  ? <MortgageProductsPage
                        applicantId={this.state.userId}></MortgageProductsPage>
                  : <CreateApplicantForm
                        onApplicantCreated={this.onApplicantCreated}></CreateApplicantForm>
                }
            </div>
        );
    }
}