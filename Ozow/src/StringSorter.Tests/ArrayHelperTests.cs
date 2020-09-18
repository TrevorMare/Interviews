using System;
using StringSorter.Helpers;
using Xunit;

namespace StringSorter.Tests
{

    public class ArrayHelperTests
    {
        
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 3)]
        [InlineData(3, 0)]
        public void Swap_WhenOutOfRangeIndex_ShouldThrowIndexOutOfRangeException(int leftIndex, int rightIndex)
        {
            char[] testValue = { 'a', 'b' };
            // Act 
            Assert.Throws<IndexOutOfRangeException>(() => testValue.Swap(leftIndex, rightIndex));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void SorterTests_WhenInputCorrect_ShouldReturnSwappedValues(int leftIndex, int rightIndex)
        {
            char[] testValue = { 'a', 'b' };
            
            // Act 
            testValue.Swap(0, 1);
            
            Assert.Equal(new char[] {'b', 'a'}, testValue);

        }



    }

}