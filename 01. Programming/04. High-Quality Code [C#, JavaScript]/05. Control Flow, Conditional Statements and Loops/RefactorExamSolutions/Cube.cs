namespace RefactorExamSolutions
{
    using System;

    public class Cube
    {
        public static void Main()
        {
            string sizeAsString = Console.ReadLine();
            int size = int.Parse(sizeAsString);

            Console.Write(new string(' ', (2 * size - 1) - size));
            Console.WriteLine(new string(':', (2 * size - 1) - size + 1));

            Console.Write(new string(' ', (2 * size - 1) - size - 1));
            Console.Write(':');
            Console.Write(new string('/', size - 2));
            Console.WriteLine(new string(':', 2));

            for (int i = 2, m = size - 1; i < size - 1; i++, m--)
            {
                Console.Write(new string(' ', (2 * size - 1) - size - i));
                Console.Write(':');
                Console.Write(new string('/', size - 2));
                Console.Write(':');
                Console.Write(new string('X', size - m));
                Console.Write(':');
                Console.WriteLine();
            }

            Console.Write(new string(':', size));
            Console.Write(new string('X', size - 2));
            Console.WriteLine(new string(':', 1));

            for (int i = size - 1, j = 3; j < size; i--, j++)
            {
                Console.Write(':');
                Console.Write(new string(' ', size - 2));
                Console.Write(':');
                Console.Write(new string('X', size - j));
                Console.Write(':');
                Console.WriteLine();
            }

            Console.Write(':');
            Console.Write(new string(' ', size - 2));
            Console.WriteLine(":" + ":");
            Console.WriteLine(new string(':', size));
        }
    }
}
