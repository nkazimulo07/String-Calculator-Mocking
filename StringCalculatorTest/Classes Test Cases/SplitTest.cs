using NUnit.Framework;
using StringCalculatorTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTest.Classes_Test_Cases
{
    public class SplitTest
    {
        private Split _split;

        [SetUp]
        public void Setup()
        {
            _split = new Split();
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingDelimeter_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "1,2";
            var delimiters = new List<string> { ",", "\n" };
            string[] expected = {"1","2"};

            // act 
            var results = _split.SplitNumbers(delimiters, input);

            // assert
            Assert.AreEqual(expected, results);
        }
    }
}
