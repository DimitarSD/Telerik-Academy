namespace RetrieveNumberOfRowsFromDB
{
    using System;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.IO;

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
                GetNumberOfRows(dbConnection);
                Console.WriteLine(new string('=', 50));

                GetNameAndDescriptionOfCategory(dbConnection);
                Console.WriteLine(new string('=', 50));

                GetProductCategoriesAndProductsName(dbConnection);
                Console.WriteLine(new string('=', 50));

                AddNewProduct(dbConnection, "Some", 1, 1, "5x10", 15.00M, 0, 0, 0, true);
                Console.WriteLine("New product added - check the database");
                Console.WriteLine(new string('=', 50));

                GetAllImages(dbConnection);
                Console.WriteLine("Stored JPG files in folder images");
                Console.WriteLine(new string('=', 50));
            }
        }

        private static void GetNumberOfRows(SqlConnection dbConnection)
        {
            string sqlStringCommand = "SELECT COUNT(*) FROM Categories";

            SqlCommand command = new SqlCommand(sqlStringCommand, dbConnection);
            int numberOfRows = (int)command.ExecuteScalar();
            Console.WriteLine("Rows count: {0}", numberOfRows);
        }

        private static void GetNameAndDescriptionOfCategory(SqlConnection dbConnection)
        {
            string sqlStringCommand = "SELECT CategoryName, Description FROM Categories";
            SqlCommand command = new SqlCommand(sqlStringCommand, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0} -> {1}", categoryName, description);
                }
            }
        }

        private static void GetProductCategoriesAndProductsName(SqlConnection dbConnection)
        {
            string sqlStringCommand = "SELECT c.CategoryName, p.ProductName " + 
                                            "FROM Products p " + 
	                                              "JOIN Categories c " + 
		                                          "ON p.CategoryID = c.CategoryID";

            SqlCommand command = new SqlCommand(sqlStringCommand, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Category Name -> Product Name");
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} -> {1}", categoryName, productName);
                }
            }
        }

        private static void AddNewProduct(SqlConnection dbConnection,
            string ProductName,
            int SupplierID,
            int CategoryID,
            string QuantityPerUnit,
            decimal UnitPrice,
            int UnitsInStock,
            int UnitsOnOrder,
            int ReorderLevel,
            bool Discontinued)
        {
            string sqlCommand = "INSERT INTO Products" + 
                "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @nitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

            SqlCommand insertProduct = new SqlCommand(sqlCommand, dbConnection);

            insertProduct.Parameters.AddWithValue("@productName", ProductName);
            insertProduct.Parameters.AddWithValue("@supplierID", SupplierID);
            insertProduct.Parameters.AddWithValue("@categoryID", CategoryID);
            insertProduct.Parameters.AddWithValue("@quantityPerUnit", QuantityPerUnit);
            insertProduct.Parameters.AddWithValue("@nitPrice", UnitPrice);
            insertProduct.Parameters.AddWithValue("@unitsInStock", UnitsInStock);
            insertProduct.Parameters.AddWithValue("@unitsOnOrder", UnitsOnOrder);
            insertProduct.Parameters.AddWithValue("@reorderLevel", ReorderLevel);
            insertProduct.Parameters.AddWithValue("@discontinued", Discontinued);

            insertProduct.ExecuteNonQuery();
        }

        private static void GetAllImages(SqlConnection dbConnection)
        {
            string sqlCommand = "SELECT CategoryName, Picture FROM Categories";

            SqlCommand command = new SqlCommand(sqlCommand, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Category Name -> Product Name");
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    categoryName = categoryName.Replace('/', '_');
                    byte[] fileContent = (byte[])reader["Picture"];
                    string fileName = string.Format(@"..\..\images\{0}.jpg", categoryName);
                    WriteBinaryFile(fileName, fileContent);
                }
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }
    }
}
