using NSubstitute;
using NUnit.Framework;
using StringCalculatorTask.Interfaces;
using StringCalculatorTask.Services;
using System.Collections.Generic;

namespace StringCalculatorTest.Classes_Test_Cases
{
    public class NumbersTest
    {
        private INegativeNumbers _negativeNumbersMock;
        private NumbersService _numbers;
        [SetUp]
        public void Setup()
        {
            _negativeNumbersMock = Substitute.For<INegativeNumbers>();
            _numbers = new NumbersService(_negativeNumbersMock);
        }

        [Test]
        public void WhenStringOfArray_UsingConvertStringArrayToIntList_ResultsReturnesIntList()
        {
            // arrange
            string[] input = { "1", "2" };
            var expected = new List<int>(){ 1, 2 };

            // act 
            var results = _numbers.ConvertStringArrayToIntList(input);

            // assert
            _numbers.ConvertStringArrayToIntList(input).Returns(expected);
        }

        [Test]
        public void WhenListOfNumbersAndOneIsGreaterThanOneThousand_UsingGetNumbersLessThanOneThousand_ResultsReturnsList()
        {
            // arrange
            var input = new List<int>() { 1000, 200, 7000, 10 };
            var expected = new List<int> { 200, 10 };

            // act 
            var results = _numbers.GetNumbersLessThanOneThousand(input);

            // assert
            Assert.AreEqual(expected, results);
        }

    }
}
