using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            SolveNQueens(4);
        }

        static void SolveNQueens(int N)
        {
            List<int[]> output = new List<int[]>();
            bool[,] board = new bool[N, N];

            SolveNQueens(board, 0, output);

            int count = 0;

            foreach (var result in output)
            {
                Console.WriteLine("Solution {0}", count);

                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine("Row: {0}: Column {1}", i, result[i]);
                }

                count++;
                Console.WriteLine();
            }
        }

        private static void SolveNQueens(bool[,] board, int column, List<int[]> output)
        {
            int n = board.GetLength(1);

            if (column == n)
            {
                int[] result = new int[n];

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j])
                        {
                            // i is the row and j is the column
                            result[i] = j;
                        }
                    }
                }

                output.Add(result);

                return;
            }

            for (int row = 0; row < n; row++)
            {
                if (IsValid(board, row, column))
                {
                    board[row, column] = true;

                    SolveNQueens(board, column + 1, output);

                    board[row, column] = false;
                }
            }
        }
 
        private static bool IsValid(bool[,] board, int row, int column)
        {
            int n = board.GetLength(0);

            // check row 
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[row, j])
                {
                    return false;
                }
            }

            // check column
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[i, column])
                {
                    return false;
                }
            }

            // check diagonal that goes from left top to given cell
            for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j])
                {
                    return false;
                }
            }

            for (int i = row, j = column; i < board.GetLength(0) && j < board.GetLength(1); i++, j++)
            {
                if (board[i, j])
                {
                    return false;
                }
            }

            for (int i = row, j = column; i < board.GetLength(0) && j >= 0; i++, j--)
            {
                if (board[i, j])
                {
                    return false;
                }
            }

            for (int i = row, j = column; i >= 0 && j < board.GetLength(1); i--, j++)
            {
                if (board[i, j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
