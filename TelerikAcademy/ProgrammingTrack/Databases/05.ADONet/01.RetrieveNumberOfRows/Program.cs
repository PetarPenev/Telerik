//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

namespace _01.RetrieveNumberOfRows
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            SqlConnection northwindConnection = new SqlConnection(Properties.Settings.Default.DBConnectioString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", northwindConnection);
            int numberOfRows = (int)command.ExecuteScalar();
            Console.WriteLine("There are {0} rows in the Northwind database.", numberOfRows);
            northwindConnection.Close();
        }
    }
}