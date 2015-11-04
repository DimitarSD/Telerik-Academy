namespace PhonebookADT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Utilities.FileUtilities;

    public class StartUp
    {
        public static void Main()
        {
            var phoneTextFileContent = FileUtility.GetFileTextContent("../../phones.txt");
            var commandsTextFileContent = FileUtility.GetFileTextContent("../../commands.txt");
            var subcribers = ExtractSubscribers(phoneTextFileContent);

            Phonebook phoneBook = new Phonebook(subcribers);
            AddSubscribersToPhonebook(phoneBook);

            Console.WriteLine(phoneBook);
            Console.WriteLine(new string('-', 33) + "SEARCH RESULTS:" + new string('-', 32) + Environment.NewLine);
            ExecuteCommands(phoneBook, commandsTextFileContent);
        }

        private static IList<Subscriber> ExtractSubscribers(string text)
        {
            var splitByLine = text.Split('\n');
            var subscribers = new List<Subscriber>();

            foreach (var line in splitByLine)
            {
                var subcriber = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(a => a.Trim())
                                    .ToArray();

                subscribers.Add(new Subscriber(subcriber[0], subcriber[1], subcriber[2]));
            }

            return subscribers;
        }

        private static void AddSubscribersToPhonebook(Phonebook phoneBook)
        {
            phoneBook.AddSubscriber(new Subscriber("unknown", "varna", "321"));
            phoneBook.AddSubscribers(new List<Subscriber>()
            {
                new Subscriber("Daniela Mimi Petrova", "Karnobat", "0899 999 888"),
                new Subscriber("Mimi Loshata", "Pernik", "0888 12 34 5")
            });
        }

        private static IList<List<string>> ExtractCommands(string text)
        {
            var commandLines = text.Split(new char[] { '\n' }).ToArray();
            var commands = new List<List<string>>();

            foreach (var commandLine in commandLines)
            {
                MatchCollection matches = Regex.Matches(commandLine, "[a-zA-Z]+");

                var commandParams = matches.Cast<Match>()
                                           .Select(m => m.Value)
                                           .ToList();

                commands.Add(commandParams);
            }

            return commands;
        }

        private static void ExecuteCommands(Phonebook phonebook, string text)
        {
            var commands = ExtractCommands(text);

            foreach (var command in commands)
            {
                if (command[0] == "find")
                {
                    if (command.Count == 2)
                    {
                        PrintResult(phonebook.Find(command[1]), command[1]);
                    }
                    else if (command.Count == 3)
                    {
                        PrintResult(phonebook.Find(command[1], command[2]), command[1], command[2]);
                    }
                }
            }
        }

        private static void PrintResult(ICollection<Subscriber> subscribers, string name, string town = null)
        {
            var result = new StringBuilder();

            if (subscribers.Count > 0)
            {
                result.AppendLine(
                                  "Search: By name - \"" + name +
                                  (town != null ? "\" and Town - \"" + town + "\": " : "\": ") + Environment.NewLine);

                foreach (var subscriber in subscribers)
                {
                    result.AppendLine("   - " + string.Join("\n   - ", subscriber));
                }
            }
            else
            {
                result.AppendLine("- There is no subscriber(s) with name - \"" + name +
                                  (town != null ? "\" and Town - \"" + town + "\": " : "\""));
            }

            result.AppendLine(Environment.NewLine + new string('-', 80));
            Console.WriteLine(result.ToString());
        }
    }
}
