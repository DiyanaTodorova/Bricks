namespace Bricks.Models
{    
    using System.Text;
   
    public class Wall
    {
        public int[,] FirstLayer { get; private set; }
        public int[,] SecondLayer { get; private set; }
        public Wall( int[,] grid)
        {                    
            this.FirstLayer = grid;
            this.SecondLayer = new int[grid.GetLength(0), grid.GetLength(1)];
        }
        public void GenerateSecondLayer() {

            int rows = this.FirstLayer.GetLength(0);
            int cols = this.FirstLayer.GetLength(1);
            
            int value = 1;

            while (true)
            {
                int currentChanges = 0; 

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        
                        if (this.SecondLayer[row, col] != 0)
                        {
                            continue;
                        }

                        bool isHorizontalBrickValid = isBrickValid(row, col, row, col + 1);
                        bool isVerticalBrickValid = isBrickValid(row, col, row + 1, col);

                        if (isHorizontalBrickValid)
                        {
                            this.SecondLayer[row, col] = value;                            
                            this.SecondLayer[row, col + 1] = value;
                            value++;
                            currentChanges++;
                        }
                        else if (isVerticalBrickValid)
                        {
                            this.SecondLayer[row, col] = value;
                            this.SecondLayer[row + 1, col] = value;
                            value++;
                            currentChanges++;
                        }
                    }

                    
                }
                if (currentChanges == 0)
                {
                    break;
                }


            }

             bool isBrickValid(int firstRow, int firstCol, int secondRow, int secondCol)
            {
                if (firstRow >= rows)
                {
                    return false;
                }
                if (secondRow >= rows)
                {
                    return false;
                }
                if (firstCol >= cols)
                {
                    return false;
                }
                if (secondCol >= cols)
                {
                    return false;
                }

                if (this.FirstLayer[firstRow, firstCol] == this.FirstLayer[secondRow, secondCol] )
                {
                    return false;
                }

                return true;

            }

            



        }
        private bool CheckSecondLayerFull ()
        {
           

            for(int row=0; row < SecondLayer.GetLength(0); row++)
            {
                for (int col = 0;  col < SecondLayer.GetLength(1); col++)
                {
                    if (SecondLayer[row, col] == 0)
                    {
                        return false;

                    }
                }

            
            }
            return true;

        } 
        public string SecondLayerToString()
        {

            bool layerFull = CheckSecondLayerFull();

            if(!layerFull)
            {
                return "-1";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string ast = new string("*");

                int rows = this.SecondLayer.GetLength(0);
                int cols = this.SecondLayer.GetLength(1);


                for (int row = 0; row < rows; row++)
                {
                    StringBuilder firstLine = new StringBuilder();
                    StringBuilder secondLine = new StringBuilder();

                    firstLine.Append("*");
                    secondLine.Append("*");

                    for (int col = 0; col < cols; col++)
                    {
                        firstLine.Append(this.SecondLayer[row, col].ToString().PadLeft(5));



                        if (row < rows - 1)
                        {
                            if (this.SecondLayer[row, col] == this.SecondLayer[row + 1, col])
                            {
                                secondLine.Append(new string('-', 6));
                            }
                            else
                            {
                                secondLine.Append(new string('*', 6));
                            }
                        }

                        if (col < cols - 1)
                        {
                            if (this.SecondLayer[row, col] == this.SecondLayer[row, col + 1])
                            {
                                firstLine.Append("-");
                            }
                            else
                            {
                                firstLine.Append("*");
                            }

                        }
                        else
                        {
                            firstLine.Append("*");
                        }



                    }
                    sb.AppendLine(firstLine.ToString());
                    if (row == rows - 1)
                    {
                        continue;
                    }
                    else
                    {
                        sb.AppendLine(secondLine.ToString());
                    }
                }

                string frame = new string('*', cols * 6 + 1);
                sb.Insert(0, (frame + " \n"));
                sb.AppendLine(frame);

                return sb.ToString();
            }
        }

        
    }
}
