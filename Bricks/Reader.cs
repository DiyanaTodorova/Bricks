using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bricks
{
    public class Reader
    {
        public static int[] ReadDimentions()
        {
            int[] dimentions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return dimentions;
        }

        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] inputMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    inputMatrix[row, col] = int.Parse(line[col]);
                }
            }

            return inputMatrix;
        }
    }
}
