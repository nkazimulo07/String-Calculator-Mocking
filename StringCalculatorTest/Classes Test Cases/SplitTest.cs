﻿using NUnit.Framework;
using StringCalculatorTask.Services;
using System.Collections.Generic;

namespace StringCalculatorTest.Classes_Test_Cases
{
    public class SplitTest
    {
        private SplitService _split;

        [SetUp]
        public void Setup()
        {
            _split = new SplitService();
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingDelimeter_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "1,2";
            var delimiters = new List<string> { ",", "\n" };
            string[] expected = { "1", "2" };

            // act 
            var results = _split.SplitNumbers(delimiters, input);

            // assert
            Assert.AreEqual(expected, results);
        }
    }
}
