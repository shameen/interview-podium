using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodiumInterview.MortgageApi.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodiumInterview.Tests
{
    [TestClass]
    public class LoanToValueCalculatorTests
    {
        [TestMethod]
        public void LoanToValueCalculator_Given10kPaymentOn100kHome_Returns90Percent()
        {
            var expected = 0.9m;

            var actual = LoanToValueCalculator.GetLtvRatio(100000, 10000);

            Assert.AreEqual(expected, actual);
        }
    }
}
