namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Using adjancency list and recursively DFS
    /// </summary>
    /// <see cref="http://bgcoder.com/Contests/63/Telerik-Algo-Academy-February-2013"/>
    public class StartUp
    {
        private static readonly IDictionary<int, List<int>> AdjacencyList = new Dictionary<int, List<int>>();
        private static long[] employees;

        public static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("../../input.txt"));
            #endif

            ParseInput();
            Console.WriteLine("Total salary: " + CalculateTotalSalary());
        }

        /// <summary>
        /// Parse the input line by line. 
        /// Use dictionary to save number of employees
        /// </summary>
        private static void ParseInput()
        {
            var numberOfEmployees = int.Parse(Console.ReadLine());
            employees = new long[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                var inputLine = Console.ReadLine();
                AdjacencyList[i] = new List<int>();

                for (int j = 0; j < numberOfEmployees; j++)
                {
                    if (inputLine[j] == 'Y')
                    {
                        AdjacencyList[i].Add(j);
                    }
                }

                if (AdjacencyList[i].Count == 0)
                {
                    employees[i] = 1;
                }
            }
        }

        private static long CalculateTotalSalary()
        {
            long totalSalary = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                totalSalary += Calculate(i);
            }

            return totalSalary;
        }
        
        private static long Calculate(int employeeId)
        {
            if (employees[employeeId] != 0)
            {
                return employees[employeeId];
            }

            foreach (var employee in AdjacencyList[employeeId])
            {
                employees[employeeId] += Calculate(employee);
            }

            return employees[employeeId];
        }
    }
}
