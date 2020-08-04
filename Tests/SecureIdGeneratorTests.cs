using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodiumInterview.MortgageApi.Logic;

namespace PodiumInterview.Tests
{
    [TestClass]
    public class SecureIdGeneratorTests
    {
        /// <remarks>System under test</remarks>
        private readonly SecureIdGenerator _sut;

        public SecureIdGeneratorTests()
        {
            _sut = new SecureIdGenerator();
        }

        [TestMethod]
        public void SecureIdGenerator_GetRandomLong_WhenRunMultipleTimes_ReturnsDifferentResults()
        {
            long randomNumber1 = _sut.GetRandomLong();
            long randomNumber2 = _sut.GetRandomLong();

            Assert.AreNotEqual(randomNumber1, randomNumber2);
        }
    }
}
