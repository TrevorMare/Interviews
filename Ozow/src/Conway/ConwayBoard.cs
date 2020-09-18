using System;
using System.Collections.Generic;

namespace Conway
{

    public class ConwayBoard
    {

        #region Members
        private readonly byte[,] _boardLayout;
        private const string OFF_PRINT = "[ ]";
        private const string ON_PRINT = "[x]";
        #endregion

        #region Properties
        public int CurrentProgression { get; private set; }
        public byte[,] BoardLayout => _boardLayout;
        public int Rows => this._boardLayout.GetLength(0);
        public int Columns => this._boardLayout.GetLength(1);
        #endregion

        #region ctor
        public ConwayBoard(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(numberOfRows)} must be greater than 0");
            }
            if (numberOfColumns <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(numberOfColumns)} must be greater than 0");
            }

            this._boardLayout = new byte[numberOfRows, numberOfColumns];
            
        }

        internal void SetNextStage(ConwayBoard board)
        {
            board.IterateBoard((row, column) => 
            {
                this._boardLayout[row, column] = board[row, column];
            });

        }

        public ConwayBoard(byte[,] initialLayout)
        {
            if (initialLayout == null)
            {
                throw new ArgumentNullException(nameof(initialLayout));
            }

            if (initialLayout.GetLength(0) <= 0)
            {
                throw new ArgumentOutOfRangeException($"Number of rows must be greater than 0");
            }

            if (initialLayout.GetLength(1) <= 0)
            {
                throw new ArgumentOutOfRangeException($"Number of columns must be greater than 0");
            }

            this._boardLayout = initialLayout;
        }

        #endregion

        #region Properties
        public byte this[int row, int column]
        {
            get { return (byte)this.BoardLayout.GetValue(row, column); }
            set { this.BoardLayout.SetValue(value, row, column); }
        }
        #endregion

        #region Methods
        public void Reset()
        {
            this.IterateBoard((row, column) => 
            {
                this[row, column] = 0;
            });
            CurrentProgression = 0;
        }

        public void IterateBoard(Action<int, int> iterationAction)
        {
            for (var iRow = 0; iRow < this.Rows; iRow++)
            {
                for (var iColumn = 0; iColumn < this.Columns; iColumn++)
                {
                    iterationAction(iRow, iColumn);
                }
            }
            CurrentProgression++;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            var sbOutputBuilder = new System.Text.StringBuilder();

            for (var iRow = 0; iRow < this.Rows; iRow++)
            {
                var rowOutput = new List<string>();
                for (var iColumn = 0; iColumn < this.Columns; iColumn++)
                {
                    string value = this[iRow, iColumn] == 1 ? ON_PRINT : OFF_PRINT;
                    rowOutput.Add(value);
                }
                sbOutputBuilder.AppendLine(string.Join(" ", rowOutput));
            }
            return sbOutputBuilder.ToString();
        }
        #endregion

    }
}