using System;
using Xunit;

namespace Conway.Tests
{

    public class ConwayBoardProgressionTests
    {

        [Fact]
        public void ProgressBoard_WhenNullPassed_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Helpers.ConwayBoardProgression.ProgressBoard(null));
        }

        [Fact]
        public void CalculateCellIsAlive_WhenGivenNullBoard_ShouldThrowArgumentNullException()
        {

            Assert.Throws<ArgumentNullException>(() => Helpers.ConwayBoardProgression.CalculateCellIsAlive(null, 1, 1));

        } 

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        public void CalculateCellIsAlive_WhenGivenIndexOutOfBounds_ShouldThrowArgumentOutOfBoundsException(int row, int column)
        {
            var board = new ConwayBoard(1, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, row, column));
        } 


        [Theory, ClassData(typeof(ConwayBoardProgressionBoundryClassData))]
        public void CalculateCellIsAlive_WhenGivenBoundsIndex_ShouldReturnExpectedResult(byte[,] input, int row, int column, byte expected)
        {
            var board = new ConwayBoard(input);

            var result = Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, row, column);

            Assert.Equal(expected, result);
        }   

        [Theory, ClassData(typeof(ConwayBoardProgression1OrLessData))]
        public void CalculateCellIsAlive_WhenGiven1OrLessLiveNeighbour_CellShouldDie(byte[,] input)
        {

            var board = new ConwayBoard(input);

            var result = Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, 0, 0);

            Assert.Equal(0, result);
        }


        [Theory, ClassData(typeof(ConwayBoardProgression4OrMoreData))]
        public void CalculateCellIsAlive_WhenGiven4OrMoreLiveNeighbour_CellShouldDie(byte[,] input, int row, int column)
        {
            var board = new ConwayBoard(input);

            var result = Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, row, column);

            Assert.Equal(0, result);
        }

        [Theory, ClassData(typeof(ConwayBoardProgression2Or3Data))]
        public void CalculateCellIsAlive_WhenCellIsAliveAndGiven2Or3LiveNeighbours_CellShouldLive(byte[,] input, int row, int column)
        {
            var board = new ConwayBoard(input);

            var result = Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, row, column);

            Assert.Equal(1, result);
        }

        [Theory, ClassData(typeof(ConwayBoardProgressionDeadCellToLiveData))]
        public void CalculateCellIsAlive_WhenCellIsDeadAndGiven3LiveNeighbours_CellShouldLive(byte[,] input, int row, int column)
        {
            var board = new ConwayBoard(input);

            var result = Helpers.ConwayBoardProgression.CalculateCellIsAlive(board, row, column);

            Assert.Equal(1, result);
        }

        [Fact]
        public void ProgressBoard_WhenGivenBlinkerLineInput_ShouldProgressToNextStage()
        {
            var input = new byte[5, 5]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };           

            var expectedResult = new byte[5, 5]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            };

            var board = new ConwayBoard(input);

            Helpers.ConwayBoardProgression.ProgressBoard(board);

            Assert.Equal(expectedResult, board.BoardLayout);
        }
        

    }

}