using System;
using Xunit;

namespace StringSorter.Tests
{

    public class SorterTests
    {

        [Theory]
        [ClassData(typeof(SorterClassData))]
        public void SorterTests_WhenNullInput_ShouldReturnNullString(Interfaces.ISortingAlgorithm sut)
        {
            string testValue = null;
            string expectedResult = string.Empty;
             
            // Act 
            var result = sut.ApplySort(testValue);
            
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [ClassData(typeof(SorterClassData))]
        public void SorterTests_WhenInputNotNull_ShouldReturnSortedString(Interfaces.ISortingAlgorithm sut)
        {
            // Arrange
            string testValue = "contrarytopopularbeliefthepinkunicornflieseast";
            string expectedResult = "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy";
             // Act 
            var result = sut.ApplySort(testValue);
            
            // Assert
            Assert.True(expectedResult == result, $"Test failed for sorting algorithm {sut.SortingName}\r\n Expected: {expectedResult}\r\n Actual: {result} ");
        }



    }

}