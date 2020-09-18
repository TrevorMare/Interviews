using System;
using System.Collections.Generic;
using Xunit;

namespace Conway.Tests
{
    public class ConwayBoardTests
    {
       
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(-1, 2)]
        [InlineData(2, -1)]
        public void ctor_WhenGivenLessOrEqualTo0RowsOrColumns_ShouldThrowArgumentOutOfRangeException(int numberOfRows, int numberOfColumns)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ConwayBoard(numberOfRows, numberOfColumns));
        }

        [Fact]
        public void ctor_WhenGivenNullAsInitial_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ConwayBoard(null));
        }

        [Theory, ClassData(typeof(ConwayBoardErrorClassData))]
        public void ctor_WhenGivenOutOfBoundsAsInitial_ShouldThrowArgumentOutOfRangeException(byte[,] inputValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ConwayBoard(inputValue));
        }

        [Fact]
        public void ctor_WhenGivenTwoSizes_ShouldInitialiseWith0Values()
        {
            var numberOfRows = 10;
            var numberOfColumns = 10;

            var sut = new ConwayBoard(numberOfRows, numberOfColumns);

            for (int iRow = 0; iRow < numberOfRows; iRow++)
            {
                for (int iColumn = 0; iColumn < numberOfColumns; iColumn++)
                {
                    Assert.Equal(0, sut[iRow, iColumn]);
                }
            }
        }

        [Fact]
        public void ctor_WhenGivenInitialValue_ShouldEqualInputValue()
        {
            var input = new byte[2, 2]
            {
                {1, 1}, {0, 1}
            };

            var sut = new ConwayBoard(input);

            Assert.Equal(input, sut.BoardLayout);
        }

        [Fact]
        public void Reset_WhenResetCalledOnBoard_ShouldResetValuesTo0()
        {
            var input = new byte[2, 2]
            {
                {1, 1}, {0, 1}
            };

            var expectedResult = new byte[2, 2]
            {
                {0, 0}, {0, 0}
            };

            var sut = new ConwayBoard(input);

            sut.Reset();

            Assert.Equal(expectedResult, sut.BoardLayout);
        }

        [Fact]
        public void ToString_WhenGivenInitialValue_ShouldPrintExpectedResult()
        {
            var input = new byte[2, 2]
            {
                {1, 1}, 
                {0, 1}
            };
            string expectedResult = "[x] [x]\r\n[ ] [x]\r\n";

            var sut = new ConwayBoard(input);

            Assert.Equal(expectedResult, sut.ToString());
        }

        [Fact]
        public void ToString_WhenValuesSet_ShouldPrintExpectedResult()
        {
            var sut = new ConwayBoard(2, 2);
            sut[0, 0] = 1;
            sut[0, 1] = 1;
            sut[1, 0] = 0;
            sut[1, 1] = 1;

            string expectedResult = "[x] [x]\r\n[ ] [x]\r\n";

            Assert.Equal(expectedResult, sut.ToString());
        }

        [Fact]
        public void IterateBoard_WhenGivenSize_ShouldIterateAllCells()
        {
            var sut = new ConwayBoard(2, 2);
            var expectedResult = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(1, 1)
            };
            var actualResult = new List<Tuple<int, int>>();

            sut.IterateBoard((row, column) => 
            {
                actualResult.Add(new Tuple<int, int>(row, column));
            });

            Assert.Equal(expectedResult, actualResult);
        }



    }
}
