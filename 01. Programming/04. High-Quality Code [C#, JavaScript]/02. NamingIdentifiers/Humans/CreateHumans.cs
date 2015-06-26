namespace Humans
{
    using System;

    public class CreateHumans
    {
        public static Person CreatePerson(int age)
        {
            Person firstPerson = new Person();

            firstPerson.Age = age;

            if (age % 2 == 0)
            {
                firstPerson.Name = "Ivaylo";
                firstPerson.Sex = Sex.Male;
            }
            else
            {
                firstPerson.Name = "Albena";
                firstPerson.Sex = Sex.Female;
            }

            return firstPerson;
        }

        public static void Main()
        {
            Person person = CreatePerson(23);
            Console.WriteLine("Person name: {0}", person.Name);
            Console.WriteLine("Person sex: {0}", person.Sex);
            Console.WriteLine("Person age: {0}", person.Age);
        }
    }
}
