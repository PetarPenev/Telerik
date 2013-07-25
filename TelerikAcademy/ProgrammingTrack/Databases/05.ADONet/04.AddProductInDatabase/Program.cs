//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

namespace _04.AddProductInDatabase
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static int AddProduct(SqlConnection connection, string productName, int supplierId, int categoryId, string quantity, decimal price, int stockCount,
            int itemsOnOrderCount, int reorederLevel, bool isDiscontinued)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Products VALUES(@productName, @supplierID, @categoryID, @quantity, @unitPrice, @unitsStock, @unitsOrder, @reorderLevel, @discontinued)",
                connection);

            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@supplierID", supplierId);
            command.Parameters.AddWithValue("@categoryID", categoryId);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@unitPrice", price);
            command.Parameters.AddWithValue("@unitsStock", stockCount);
            command.Parameters.AddWithValue("@unitsOrder", itemsOnOrderCount);
            command.Parameters.AddWithValue("@reorderLevel", reorederLevel);
            command.Parameters.AddWithValue("@discontinued", isDiscontinued);

            int numberOfInsertions = command.ExecuteNonQuery();
            if (numberOfInsertions != 1)
            {
                throw new ArgumentException("More than one row was inserted - code needs debugging.");
            }

            SqlCommand cmdSelectIdentity =
            new SqlCommand("SELECT @@Identity", connection);
            int insertedRecordId =
                (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        public static void Main()
        {
            SqlConnection northwindConnection = new SqlConnection(Properties.Settings.Default.DBConnectionString);
            northwindConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Products VALUES(@productName, @categoryID, @quantity, @unitPrice, @unitsStock, @unitsOrder, @reorderLevel, @disconinued",
                northwindConnection);

            try
            {
                int idOfInsertedProduct = AddProduct(northwindConnection, "blueberries", 1, 1, "20 kg", 10.56m, 20, 0, 10, false);
                Console.WriteLine("The id of the inserted product is {0}.", idOfInsertedProduct);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            northwindConnection.Close();
        }
    }
}