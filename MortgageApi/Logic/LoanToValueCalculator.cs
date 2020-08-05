using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Logic
{
    public static class LoanToValueCalculator
    {
        public static decimal GetLtvRatio(decimal propertyValue, decimal depositAmount)
        {
            var borrowingAmount = propertyValue - depositAmount;
            return borrowingAmount / propertyValue;
        }
    }
}
