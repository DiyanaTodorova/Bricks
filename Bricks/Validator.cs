using System;


namespace Bricks
{
    public class Validator
    {
        public static void ValidateDimentions(int width, int height)
        {
            if (width >= 100)
            {
                throw new ArgumentException("Width must be less than 100!");
            }

            if (height >= 100)
            {
                throw new ArgumentException("Height must be less than 100!");
            }
        }

        public static void ValidateBricksSize(int[,] bricks)
        {
            int values = (bricks.GetLength(0) * bricks.GetLength(1)) / 2;

            for (int i = 1; i <= values; i++)
            {
                int counter = 0;
                for (int row = 0; row < bricks.GetLength(0); row++)
                {
                    for (int col = 0; col < bricks.GetLength(1); col++)
                    {
                        if (i == bricks[row, col])
                        {
                            counter++;
                        }
                    }
                }

                if (counter != 2)
                {
                    throw new Exception("Brick size must be 2x1!");
                }
            }
        }
    }
}
