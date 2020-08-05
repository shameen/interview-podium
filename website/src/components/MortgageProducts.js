import React from "react";
import MortgageProductForm from "./MortgageProductForm";
import MortgageProductResults from "./MortgageProductResults";

export default class MortgageProductsPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            mortgageProducts: []
        }
    }

    onMortgageProductDataChanged = (newData) => {
        this.setState({ mortgageProducts: newData})
    }

    render = () => {
        return (
            <div>
                <MortgageProductForm
                    applicantId={this.props.applicantId}
                    onMortgageProductDataChanged={this.onMortgageProductDataChanged}></MortgageProductForm>
                <hr />
                <MortgageProductResults
                    mortgageProductData={this.state.mortgageProducts}></MortgageProductResults>
            </div>
        );
    }
}