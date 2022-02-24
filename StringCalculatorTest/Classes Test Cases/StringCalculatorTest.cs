using NSubstitute;
using NUnit.Framework;
using StringCalculatorTask;
using StringCalculatorTask.Interfaces;
using System.Collections.Generic;

namespace StringCalculatorTest
{
    public class Tests
    {
        private StringCalculatorService _stringCalculator;
        private ICalculation calculatorMock;
        private IDelimiter _delimiterMock;
        private ISplit _splitMock;
        private INumbers _numbersMock;

        [SetUp]
        public void Setup()
        {
            calculatorMock = Substitute.For<ICalculation>();
            _delimiterMock = Substitute.For<IDelimiter>();
            _splitMock = Substitute.For<ISplit>();
            _numbersMock = Substitute.For<INumbers>();
            _stringCalculator = new StringCalculatorService(calculatorMock, _delimiterMock, _splitMock, _numbersMock);
        }

        [Test]
        public void WhenPassingEmptyString_UsingPerfomCalculation_ResultsReturnsZero()
        {
            // arrange
            const int expected = 0;
            const string input = "";
            
            // act 
            var results = _stringCalculator.PerformCalculation(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithOneNumber_UsingPerfomCalculation_ResultsReturnsSum()
        {
            // arrange
            const int expected = 1;
            const string input = "1";
            var expected1 = new List<string> { ",", "\n" };
            string[] expected2 = { "1" };
            var expected3 = new List<int>() { 1};

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenArrayOfIntegers_UsingPerformCalculationd_ResultsReturnsSum()
        {
            // arrange
            const string input = "1,2";
            const int expected = 3;
            var expected1 = new List<string> { ",", "\n" };
            string[] expected2 = { "1", "2" };
            var expected3 = new List<int>() { 1, 2 };

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithANewDelimiter_UsingPerformCalculation_ResultsReturnsSum()
        {
            // arrange
            const string input = "//;\n1;2";
            const int expected = 3;
            var expected1 = new List<string> { ",", "\n",";" };
            string[] expected2 = { "1", "2" };
            var expected3 = new List<int>() { 1, 2 };

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenUsingSquareBracketAsADelimiter_UsingPerformCalculation_ResultsReturnsSum()
        {
            // arrange
            const string input = "//[\n1[2[10";
            const int expected = 13;
            var expected1 = new List<string> { ",", "\n", "[" };
            string[] expected2 = { "1", "2", "10" };
            var expected3 = new List<int>() { 1, 2, 10 };

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithDelimiterOfAnyLength_UsingPerformCalculation_ResultsReturnsSum()
        {
            // arrange
            const string input = "//***\n1***2***3";
            const int expected = 6;

            var expected1 = new List<string> { ",", "\n", "***" };
            string[] expected2 = { "1", "2", "3" };
            var expected3 = new List<int>() { 1, 2, 3};

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenWithMultipleDelimiters_UsingPerformCalculation_ResultsReturnsSum()
        {
            // arrange
            const string input = "//[*][%]\n1*2%3";
            const int expected = 6;
            var expected1 = new List<string> { ",", "\n", "*", "%" };
            string[] expected2 = { "1", "2", "3" };
            var expected3 = new List<int>() { 1, 2, 3 };

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithNumberGreaterThanOneThousand_UsingPerfomCalculation_ResultsReturnsSum()
        {
            // arrange
            const int expected = 2;
            const string input = "1000,2";
            var expected1 = new List<string> { ",", "\n" };
            string[] expected2 = { "1000", "2"};
            var expected3 = new List<int>() { 2 };

            // act 
            _delimiterMock.GetDelimiters(input).Returns(expected1);
            _splitMock.SplitNumbers(expected1, input).Returns(expected2);
            _numbersMock.ConvertStringArrayToIntList(expected2).Returns(expected3);
            calculatorMock.Calculate(expected3).Returns(expected);
            var results = _stringCalculator.getNumbersList(input);

            // assert
            Assert.AreEqual(expected, results);

        }
    }
}