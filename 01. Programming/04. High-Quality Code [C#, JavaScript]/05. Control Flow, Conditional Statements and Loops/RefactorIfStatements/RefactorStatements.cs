namespace RefactorIfStatements
{
    using System;

    public class RefactorStatements
    {
        public static void Cook(Potato potato)
        {
        }

        public static void VisitCell()
        {
        }

        public static void Main()
        {
            // Part 1 
            /*
                Potato potato;
                //... 
                if (potato != null)
                    if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                        Cook(potato);
             */

            Potato potato = new Potato();
            // ... 
            potato.HasBeenPeeled = true;
            potato.IsNotRotten = true;


            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsNotRotten)
                {
                    Cook(potato);
                }
            }

            // Part 2
            /*
               if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
               {
                   VisitCell();
               }
            */

            int[,] matrixOfNumbers = new int[,]
            {
                {1,2,3,4,5},
                {6,7,8,9,10},
                {11,12,13,14,15}
            };

            Random randomX = new Random();
            Random randomY = new Random();

            for (int row = 0; row < matrixOfNumbers.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOfNumbers.GetLength(1); col++)
                {
                    int currentX = randomX.Next(0, 14);
                    int currentY = randomY.Next(0, 14);

                    bool isCorrectX = currentX >= 0 && currentX <= matrixOfNumbers.GetLength(0);
                    bool isCorrectY = currentY >= 0 && currentY <= matrixOfNumbers.GetLength(1);

                    bool shouldVisitCell = true;

                    if (currentX == currentY)
                    {
                        shouldVisitCell = false;
                    }

                    if (isCorrectX && isCorrectY && shouldVisitCell)
                    {
                        VisitCell();
                    }
                }
            }
        }
    }
}
