using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarsSudokuValidator
{
    public static class SudokuValidator
    {
        public static bool ValidateSolution(int[][] board)
        {
            bool result = true;
            bool[] validationResults = new bool[3];
            validationResults[0] = HorizontalLinesValidator(board);
            validationResults[1] = VerticalLinesValidator(board);
            validationResults[2] = SudokuRangeValidator(board);
            for (int i = 0; i < validationResults.Length; i++)
            {
                if (validationResults[i] == false)
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool HorizontalLinesValidator(int[][] board)
        {
            bool result = true;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].Sum() != 45)
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool VerticalLinesValidator(int[][] board)
        {
            int[][] transpBoard = new int[9][];
            for (int i = 0; i < transpBoard.Length; i++)
            {
                transpBoard[i] = new int[9];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = board.Length - 1; j >= 0; j--)
                {
                    transpBoard[i][j] = board[j][i];
                }
            }
            return HorizontalLinesValidator(transpBoard);
        }

        public static bool SudokuRangeValidator(int[][] board)
        {
            int[][] rangedBoard = new int[9][];
            rangedBoard[0] = RangeDivisor(board, 0, 3, 0, 3);
            rangedBoard[1] = RangeDivisor(board, 0, 3, 3, 3);
            rangedBoard[2] = RangeDivisor(board, 0, 3, 6, 3);
            rangedBoard[3] = RangeDivisor(board, 3, 3, 0, 3);
            rangedBoard[4] = RangeDivisor(board, 3, 3, 3, 3);
            rangedBoard[5] = RangeDivisor(board, 3, 3, 6, 3);
            rangedBoard[6] = RangeDivisor(board, 6, 3, 0, 3);
            rangedBoard[7] = RangeDivisor(board, 6, 3, 3, 3);
            rangedBoard[8] = RangeDivisor(board, 6, 3, 6, 3);
            return HorizontalLinesValidator(rangedBoard);
        }

        public static int[] RangeDivisor(int[][] board, int startVerIndex, int horizontalLinesCount, int startHorIndex, int verticalLinesCount)
        {
            List<int> result = new List<int>();

            for (int i = startHorIndex; i < startHorIndex + verticalLinesCount; i++)
            {
                for (int j = startVerIndex; j < startVerIndex + horizontalLinesCount; j++)
                {
                    result.Add(board[i][j]);
                }
            }

            return result.ToArray();
        }
    }
}
