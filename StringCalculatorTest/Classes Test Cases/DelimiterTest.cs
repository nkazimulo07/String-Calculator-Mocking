using NSubstitute;
using NUnit.Framework;
using StringCalculatorTask.Interfaces;
using StringCalculatorTask.Services;
using System.Collections.Generic;

namespace StringCalculatorTest.Classes_Test_Cases
{
    public class DelimiterTest
    {
        private DelimiterService _delimiters;

        [SetUp]
        public void Setup()
        {
            //  _delimiters = Substitute.For<IDelimiter>();
            _delimiters = new DelimiterService();
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingDelimeter_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "//[*][%][:][;]\n";
            var expected = new List<string> { ",", "\n", "*", "%", ":", ";" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingGetMultipleDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "[*][%][:][;]";
            string[] expected = { "*", "%", ":", ";" };

            // act 
            var results = _delimiters.GetMultipleDelimiters(input);

            // assert
            Assert.AreEqual(expected, results); 
        }
    }
}
