import React from "react";

export default class MortgageProductForm extends React.Component {
    render = () => {
        var tableRows = this.props.mortgageProductData.map(mp => (
            <tr key={mp.id}>
                <td>{mp.lender.name}</td>
                <td>{mp.interestRate}%</td>
                <td>{["Unknown", "Fixed", "Variable"][mp.InterestRateType]}</td>
                <td>&lt;{mp.maximumLoanToValue}%</td>
            </tr>
            ));
        return (
            <div>
                {
                    this.props.mortgageProductData.length === 0
                        ? <em style={{"color":"#888"}}>(No Results)</em>
                        : <table>
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