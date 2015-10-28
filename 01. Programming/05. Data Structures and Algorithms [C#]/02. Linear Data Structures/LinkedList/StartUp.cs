namespace LinkedList
{
    using System;

    public class StartUp
    {
        private const string NumberOfElementsMessage = "Number of the elements is {0}";

        public static void Main()
        {
            var numbers = new LinkedList<int>();
            numbers.AddFirst(1);
            numbers.AddFirst(2);
            numbers.AddFirst(3);
            numbers.AddFirst(4);
            numbers.AddLast(5);
            numbers.AddLast(6);
            numbers.AddLast(7);

            int numberOfElements = numbers.Count;
            Console.WriteLine(NumberOfElementsMessage, numberOfElements);

            numbers.Print();
        }        
    }
}
