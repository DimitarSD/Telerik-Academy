namespace RefactorExamSolutions
{
    using System;

    public class Printing
    {
        public static void Main()
        {
            string numberOfStudentAsString = Console.ReadLine();
            long numberOfStudents = long.Parse(numberOfStudentAsString);

            string numberOfPaperSheetsAsString = Console.ReadLine();
            long numberOfPaperSheets = long.Parse(numberOfPaperSheetsAsString);

            string priceOfOneRealmAsString = Console.ReadLine();
            decimal priceOfOneRealm = decimal.Parse(priceOfOneRealmAsString);

            decimal price = numberOfStudents * numberOfPaperSheets;
            decimal numberOfRealmBoxes = price / 500;
            decimal sumToBePaid = numberOfRealmBoxes * priceOfOneRealm;

            Console.WriteLine("{0:F2}", sumToBePaid);
        }
    }
}
