namespace Articles
{
    using System;

    public class StartUp
    {
        private static readonly GoogleBooksApiConsumer GoogleApiConsumer = new GoogleBooksApiConsumer();

        internal static void Main()
        {
            // I recommended -> Pattern: "the 39 clues", Results: 15 :)
            // Or you can choose your favourite book!
            Console.Write("Enter a search pattern (for example: 'the 39 clues'): ");
            string searchPattern = Console.ReadLine();

            Console.Write("Number of results to take: ");
            int articlesCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAll books:\n");
            var result = GoogleApiConsumer.GetVolumes(searchPattern, articlesCount);

            foreach (var item in result.Items)
            {
                PrintResult("Title: ", item.VolumeInfo.Title, ConsoleColor.Yellow);
                PrintResult("\nAuthor: ", string.Join(", ", item.VolumeInfo.Authors), ConsoleColor.Yellow);
                PrintResult("\nPublisher: ", item.VolumeInfo.Publisher, ConsoleColor.Yellow);
                PrintResult("\nPublished date: ", item.VolumeInfo.PublishedDate, ConsoleColor.Yellow);
                PrintResult("\nDescription: ", item.VolumeInfo.Description, ConsoleColor.Yellow);
                Console.WriteLine(new string('=', 70));
            }
        }

        private static void PrintResult(string sectionName, string data, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(sectionName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
