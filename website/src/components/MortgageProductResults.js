import React from "react";
import "./MortgageProductResults.css";

export default class MortgageProductResults extends React.Component {
    render = () => {
        var tableRows = this.props.mortgageProductData.map(mp => (
            <tr key={mp.id}>
                <td>{mp.lender.name}</td>
                <td>{mp.interestRate}%</td>
                <td>{["Unknown", "Fixed", "Variable"][mp.interestRateType]}</td>
                <td>&lt;{mp.maximumLoanToValue*100}%</td>
            </tr>
            ));
        return (
            <div className="MortgageProductResults">
                {
                    this.props.mortgageProductData.length === 0
                        ? <em>(No Results.)<br />
                            <small>Note: Users under 18 years of age, and Loan-to-value ratios of over 0.9 will always have no results.</small>
                        </em>
                        : <table className="table">
                            <thead>
                                <tr>
                                <th>Lender</th>
                                <th>Interest Rate</th>
                                <th>Fixed/Variable</th>
                                <th>Loan-to-value</th>
                                </tr>
                            </thead>
                            <tbody>{tableRows}</tbody>
                        </table>
                }
            </div>
        );
    }
}