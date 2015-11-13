namespace BinaryPasswords
{
    using System;
    using System.Linq;

    /// <summary>
    /// Solution for problem 1 -> "Binary Passwords" from Telerik Algo Academy @ October 2012
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/132/Telerik-Algo-Academy-October-2012"/>
    public class StarUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            // The number of the '*' is actually our power
            int pow = input.Where(a => a == '*').Count();

            long baseN = 2;
            long result = 1;

            for (int i = 0; i < pow; i++)
            {
                result *= baseN;
            }

            Console.WriteLine(result);
        }
    }
}
