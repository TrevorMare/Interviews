using System;

namespace Conway.Helpers
{

    public static class ConwayBoardSeed
    {

        public static int RandomSeedConwayBoard(ConwayBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            board.Reset();

            var randomGenerator = new RandomGenerator();
            int numberOfCellsUpdated = 0;

            for (var iRow = 0; iRow < board.Rows; iRow++)
            {
                for (var iColumn = 0; iColumn < board.Columns; iColumn++)
                {
                    board[iRow, iColumn] = randomGenerator.GetNextRandomByte();
                    numberOfCellsUpdated++;
                }
            }

            return numberOfCellsUpdated;
        }



    }


}