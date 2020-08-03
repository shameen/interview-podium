using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodiumInterview.MortgageApi.Logic;

namespace PodiumInterview.Tests
{
    [TestClass]
    public class IdGeneratorTests
    {
        /// <remarks>System under test</remarks>
        private readonly IdGenerator _sut;

        public IdGeneratorTests()
        {
            _sut = new IdGenerator();
        }

        [TestMethod]
        public void IdGenerator_GetRandomLong_WhenRunMultipleTimes_ReturnsDifferentResults()
        {
            long randomNumber1 = _sut.GetRandomLong();
            long randomNumber2 = _sut.GetRandomLong();

            Assert.AreNotEqual(randomNumber1, randomNumber2);
        }
    }
}
