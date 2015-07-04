namespace RefactorLoop
{
    using System;

    public class Refactor
    {
        public static void Main()
        {
            int[] collectionOfNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            bool isFound = false;
            int expectedValue = 666;

            for (int i = 0; i < collectionOfNumbers.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(collectionOfNumbers[i]);
                    if (collectionOfNumbers[i] == expectedValue)
                    {
                        isFound = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(collectionOfNumbers[i]);
                }
            }

            // More code here
            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
