using System;
using Xunit;

namespace StringSorter.Tests
{
    public class StringParserTests
    {
        [Fact]
        public void ParseString_WhenNullPassed_ShouldReturnEmptyString()
        {
            var result = StringParser.ParseString(null);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ParseString_WhenBlankPassed_ShouldReturnEmptyString()
        {
            var result = StringParser.ParseString("");

            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("aA", "aa")]
        [InlineData("A", "a")]
        public void ParseString_WhenUpperCasePassed_ShouldReturnLowerCase(string inputValue, string testValue)
        {
            var result = StringParser.ParseString(inputValue);

            Assert.Equal(testValue, result);
        }

        [Theory]
        [InlineData("1", "")]
        [InlineData("%", "")]
        [InlineData("\n", "")]
        public void ParseString_WhenNonAlphaPassed_ShouldRemoveNonAlphaString(string inputValue, string testValue)
        {
            var result = StringParser.ParseString(inputValue);

            Assert.Equal(testValue, result);
        }

        [Theory]
        [InlineData("\naA", "aa")]
        [InlineData("@b*C", "bc")]
        [InlineData("c C", "cc")]
        public void ParseString_WhenStringPassed_ShouldLowerCaseAndRemoveNonAlpha(string inputValue, string testValue)
        {
            var result = StringParser.ParseString(inputValue);

            Assert.Equal(testValue, result);
        }

    }
}
