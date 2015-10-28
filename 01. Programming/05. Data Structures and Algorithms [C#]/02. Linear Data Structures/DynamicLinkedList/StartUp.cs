namespace DynamicLinkedList
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());

            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            queue.Enqueue(7);
            queue.Enqueue(8);
        }
    }
}
