using System;

namespace Conway.Helpers
{

    public static class ConwayBoardProgression
    {

        public static void ProgressBoard(ConwayBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            // Create a new board
            var progressionBoard = new ConwayBoard(board.Rows, board.Columns);

            board.IterateBoard((row, column) => 
            {
                byte cellIsAlive = CalculateCellIsAlive(board, row, column);
                progressionBoard[row, column] = cellIsAlive;
            });

            // Progress the board to the next stage
            board.SetNextStage(progressionBoard);
        }

        public static byte CalculateCellIsAlive(ConwayBoard board, int rowIndex, int columnIndex)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            if (rowIndex < 0 || rowIndex > board.Rows - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            }

            if (columnIndex < 0 || columnIndex > board.Columns - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex));
            }

            // Calculate the boundries of the index
            int rowStartIndex = Math.Max(rowIndex - 1, 0);
            int columnStartIndex = Math.Max(columnIndex - 1, 0);
            int rowEndIndex = Math.Min(board.Rows - 1, rowIndex + 1);
            int columnEndIndex = Math.Min(board.Columns - 1, columnIndex + 1);

            int numberOfLiveNeighbours = 0;
            byte currentValue = board[rowIndex, columnIndex];

            for (var iNeighbourRowIndex = rowStartIndex; iNeighbourRowIndex <= rowEndIndex; iNeighbourRowIndex++)
            {
                for (var iNeighbourColumnIndex = columnStartIndex; iNeighbourColumnIndex <= columnEndIndex; iNeighbourColumnIndex++)
                {
                    if (iNeighbourRowIndex != rowIndex || iNeighbourColumnIndex != columnIndex)
                    {
                        if (board[iNeighbourRowIndex, iNeighbourColumnIndex] == 1)
                        {
                            numberOfLiveNeighbours += 1;
                        }
                    }
                }
            }

            if (currentValue == 1 && (numberOfLiveNeighbours == 2 || numberOfLiveNeighbours == 3))
            {
                return 1;
            }
            else if (currentValue == 0 && numberOfLiveNeighbours == 3)
            {
                return 1;
            }

            return 0;
        }

    }

}