using Bricks.Models;
using System;
using System.Linq;
using System.Text;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] dimentions = Reader.ReadDimentions();

             int rows = dimentions[0];
             int cols = dimentions[1];

             Validator.ValidateDimentions(rows, cols);

             int[,] inputMatrix = Reader.ReadMatrix(rows, cols);

             Validator.ValidateBricksSize(inputMatrix);

            Wall wall = new Wall(inputMatrix);

            wall.GenerateSecondLayer();

            Console.WriteLine(wall.SecondLayerToString());

            
           

            
            
           

        }
        





    }

    
}
