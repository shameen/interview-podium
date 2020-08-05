import React from "react";
import "./_forms.css";

export default class MortgageProductForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            PropertyValue: 0,
            DepositAmount: 0,
            mortgageProducts: []
        }
    }

    loanToValueRatio = () => this.state
        ? (this.state.PropertyValue - this.state.DepositAmount) / this.state.PropertyValue
        : 0;

    server = {
        searchMortgageProducts: () => {
            const url = `${window.ApiBaseUrl}/MortgageProduct/${this.props.applicantId}`;

            //Request body
            const requestBody = JSON.stringify({
                PropertyValue: this.state.PropertyValue,
                DepositAmount: this.state.DepositAmount
            });
            const onError = (err) => Promise.reject(err);
            return fetch(url, {
                method: 'POST',
                cache: 'no-cache',
                body: requestBody,
                headers: new Headers({"Content-Type": "application/json", "Content-Length": requestBody.length}),
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
                this.setState({ mortgageProducts: data });
                this.events.onFetchMortgageProductsCompleted(data.userId);
            }, onError);
        }
    }
    events = {
        /** Propagate to parent */
        onFetchMortgageProductsCompleted: () => {
            if (typeof this.props.onMortgageProductDataChanged === "function") {
                this.props.onMortgageProductDataChanged(this.state.mortgageProducts)
            }
        },
        onFormInputChange: (event) => {
            const target = event.target;
            let value = event.value;
            if (target.value.length && target.type === "number")
                value = parseFloat(target.value)
            this.setState({
                [target.name]: value
            });
        },
        onFormSubmit: (event) => {
            event.preventDefault();
            this.server.searchMortgageProducts();
        }
    }

    render = () => {
        return (
            <form className="form" onSubmit={this.events.onFormSubmit}>
                <label>
                    Property Value
                    <input type="number" name="PropertyValue" step="0.01" min="0"
                        value={this.state.PropertyValue}
                        onChange={this.events.onFormInputChange}
                        required />
                </label>
                <label>
                    Deposit Amount
                    <input type="number" name="DepositAmount" step="0.01" min="0"
                        onChange={this.events.onFormInputChange}
                        value={this.state.DepositAmount}
                        required />
                </label>

                <button className="button button-big">Go</button>
                {typeof this.loanToValueRatio() === "number" && !isNaN(this.loanToValueRatio())
                    ? <em>(Loan-to-Value ratio: {this.loanToValueRatio().toFixed(2)})</em>
                    : "" }
                
            </form>
        );
    }
}