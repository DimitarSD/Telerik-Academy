namespace AnimalHierarchy
{
    using System;

    class Zoo
    {
        private const int NumberOfAnimalsInZoo = 6;

        public static void Main()
        {
            Dog firstDog = new Dog();
            string isSleeping = firstDog.Sleep(true);
            Console.WriteLine("The dog is sleeping: {0}", isSleeping);
        }
    }
}
