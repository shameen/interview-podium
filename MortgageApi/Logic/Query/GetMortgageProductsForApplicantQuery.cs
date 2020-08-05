using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PodiumInterview.Database;

namespace PodiumInterview.MortgageApi.Logic.Query
{
    public class GetMortgageProductsForApplicantQuery : IQuery<ICollection<MortgageProduct>>
    {
        private readonly Applicant _applicant;
        private readonly decimal _propertyValue;
        private readonly decimal _depositAmount;

        public GetMortgageProductsForApplicantQuery(Applicant applicant, decimal propertyValue, decimal depositAmount)
        {
            _applicant = applicant;
            _propertyValue = propertyValue;
            _depositAmount = depositAmount;
        }

        public async Task<ICollection<MortgageProduct>> ExecuteAsync()
        {
            //If the applicant is under 18, no products should be returned
            var isUnderage = _applicant.DateOfBirth.AddYears(18) > DateTime.Today;
            if (isUnderage)
                return new List<MortgageProduct>();

            //If LTV is not less than 90%, no products should be returned
            var loanToValueRatio = LoanToValueCalculator.GetLtvRatio(_propertyValue,_depositAmount);
            bool isLtvTooHigh = loanToValueRatio > 0.9m;
            if (isLtvTooHigh)
                return new List<MortgageProduct>();

            using (var db = PodiumDbContextFactory.GetDbContext())
            {
                return await db.MortgageProducts
                    .Where(mp => loanToValueRatio <= mp.MaximumLoanToValue)
                    .ToListAsync();
            }
        }
    }
}
