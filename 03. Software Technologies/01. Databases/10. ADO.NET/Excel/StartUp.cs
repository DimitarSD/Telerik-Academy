namespace Excel
{
    using System;
    using System.Data.OleDb;

    public class StartUp
    {
        private const string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;" + 
                                                 "Data Source = ..\\..\\exam.xlsx;" + 
                                                 "Extended Properties = \"Excel 12.0 Xml;HDR=YES\";";
        public static void Main()
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                GetDataFromExcelFile(dbConnection);

                AddNewRowToExcelFile(dbConnection, "Ivaylo Petkov", 240);
            }
        }

        private static void GetDataFromExcelFile(OleDbConnection dbConnection)
        {
            string xslCommand = "SELECT * FROM [Sheet1$]";

            OleDbCommand command = new OleDbCommand(xslCommand, dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("Name -> Score");
                Console.WriteLine(new string('-', 25));
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("{0} -> {1}", name, score);
                }

                Console.WriteLine(new string('-', 25));
            }
        }

        private static void AddNewRowToExcelFile(OleDbConnection dbConnection, string name, double score)
        {
            string sqlCommand = string.Format("INSERT INTO [Sheet1$] (Name, Score) VALUES ('{0}', '{1}')", name, score);

            OleDbCommand command = new OleDbCommand(sqlCommand, dbConnection);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Row inserted successfully.");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("Excel Error occured: " + exception);
            }
        }
    }
}
