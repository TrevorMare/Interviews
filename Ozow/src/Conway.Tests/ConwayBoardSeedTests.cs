using System;
using Xunit;

namespace Conway.Tests
{

    public class ConwayBoardSeedTests
    {

        /*
            Testing on randoms are exluded as we should not test this
        */

        [Fact]
        public void RandomSeedConwayBoard_WhenNullBoardPassed_ShouldThrowArgumentNullException()
        {
           Assert.Throws<ArgumentNullException>(() => Conway.Helpers.ConwayBoardSeed.RandomSeedConwayBoard(null)); 
        }

        [Fact]
        public void RandomSeedConwayBoard_WhenBoardPassed_ShouldSeedExpectedNumberOfCells()
        {
            
            var board = new ConwayBoard(2, 2);

            var numberOfCellsSeeded = Conway.Helpers.ConwayBoardSeed.RandomSeedConwayBoard(board); 

            Assert.Equal(4, numberOfCellsSeeded);
        }

    }

}