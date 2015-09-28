namespace _07.Backtracking
{
    using System;

    internal class Backtracking

    {
        private const int BoardSize = 8;

        private static readonly int[][] Board = new int[BoardSize][];

        private static void Main(string[] args)
        {
            FillBoard();
            var numberOfQeens = GetQeensSettings(0);
            Console.WriteLine(numberOfQeens);
        }

        private static int GetQeensSettings(int currentRow)
        {
            if (currentRow == BoardSize)
            {
                // If the rows have finisehd we have set the queen successfully!
                return 1;
            }

            var totalSettingCount = 0;
            //otherwize we set col by col
            for (var col = 0; col < BoardSize; col++)
            {
                // first we make shure we can set
                if (Board[currentRow][col] == 0)
                {
                    // set cells value will be row-related
                    Board[currentRow][col] = 1 + currentRow;

                    // set invalid cells
                    SetInvalidBoard(currentRow, col);

                    //recursive call
                    totalSettingCount += GetQeensSettings(currentRow + 1);

                    // we need to recover everythig to 
                    Board[currentRow][col] = 0;
                    RecoverBoard(currentRow);
                }
            }
            return totalSettingCount;
        }

        private static void SetInvalidBoard(int currentRow, int col)
        {
            // We need to set invalid vertical and diagonal positons bellow the queen row
            for (var row = currentRow + 1; row < BoardSize; row++)
            {
                //vertical positon
                if (Board[row][col] == 0)
                {
                    Board[row][col] = -(1 + currentRow);
                }

                var colGap = row - currentRow;
                //left diagona
                if (col - colGap >= 0 && Board[row][col - colGap] == 0)
                {
                    Board[row][col - colGap] = -(1 + currentRow);
                }
                //left diagonal
                if (col + colGap < BoardSize && Board[row][col + colGap] == 0)
                {
                    Board[row][col + colGap] = -(1 + currentRow);
                }
            }
        }

        private static void RecoverBoard(int currentRow)
        {
            // check if the index of the row is higer(queens) or lower(invalids) than current row
            for (var row = currentRow + 1; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    if (Board[row][col] < -currentRow || Board[row][col] > currentRow)
                    {
                        Board[row][col] = 0;
                    }
                }
            }
        }

        private static void FillBoard()
        {
            for (var row = 0; row < BoardSize; row++)
            {
                Board[row] = new int[BoardSize];
            }
        }
    }
}