using NSubstitute;
using NUnit.Framework;
using StringCalculatorTask.Interfaces;
using StringCalculatorTask.Services;
using System;
using System.Collections.Generic;

namespace StringCalculatorITest.Classes_Test_Case
{
    public class NegativeNumbersTest
    {
        private NegativeNumbersService _negativeNumbers;
        private IErrorHandling _errorHandlingMock;

        [SetUp]
        public void Setup()
        {
            _errorHandlingMock = Substitute.For<IErrorHandling>();
            _negativeNumbers = new NegativeNumbersService(_errorHandlingMock);
        }

        [Test]
        public void WhenStringWithNegativeNumber_UsingCheckNegativeNumbers_ResultsReturnsException()
        {
            // arrange
            var input = new List<int> { 1, 2, -3 };

            //act
            _errorHandlingMock.When(x => x.ThrowException(Arg.Any<string>())).Do(x => throw new Exception("negatives not allowed: -3"));
            var results = Assert.Throws<System.Exception>(() => _negativeNumbers.CheckNegativeNumbers(input));

            //assert
            Assert.AreEqual("negatives not allowed: -3", results.Message);
        }
        [Test]
        public void WhenStringWithNegativeNumbers_UsingCheckNegativeNumbers_ResultsReturnsException()
        {
            // arrange
            var input = new List<int> { -1, -2, -3 };

            //act
            _errorHandlingMock.When(x => x.ThrowException(Arg.Any<string>())).Do(x => throw new Exception("negatives not allowed: -1 -2 -3"));
            var results = Assert.Throws<System.Exception>(() => _negativeNumbers.CheckNegativeNumbers(input));

            //assert
            Assert.AreEqual("negatives not allowed: -1 -2 -3", results.Message);
        }
    }
}
