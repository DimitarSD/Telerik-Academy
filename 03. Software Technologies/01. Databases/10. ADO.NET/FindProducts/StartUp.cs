namespace FindProducts
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            SqlConnection dbConnection = new SqlConnection(
                "Server=.; " +
                "Database=NORTHWND;" +
                "Integrated Security=true");

            dbConnection.Open();

            using (dbConnection)
            {
                Console.Write("Please enter text to search product:");
                string input = Console.ReadLine();
                Console.WriteLine("Products that contain \"{0}\":", input);
                SearchAllProductsThatContainString(dbConnection, input);
            }
        }

        private static void SearchAllProductsThatContainString(SqlConnection dbConnection, string input)
        {
            string escapedInput = EscapeInputString(input);

            string sqlStringCommand = string.Format("SELECT ProductName FROM Products WHERE ProductName LIKE '%{0}%'", escapedInput);

            SqlCommand allProducts = new SqlCommand(sqlStringCommand, dbConnection);
            SqlDataReader reader = allProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0}", productName);
                }
            }
        }

        private static string EscapeInputString(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'')
                {
                    input = input.Substring(0, i) + "'" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '_')
                {
                    input = input.Substring(0, i) + "/" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '%')
                {
                    input = input.Substring(0, i) + "\\" + input.Substring(i, input.Length - i);
                    i++;
                }

                if (input[i] == '&')
                {
                    input = input.Substring(0, i) + "\\" + input.Substring(i, input.Length - i);
                    i++;
                }
            }
            return input;
        }
    }
}
