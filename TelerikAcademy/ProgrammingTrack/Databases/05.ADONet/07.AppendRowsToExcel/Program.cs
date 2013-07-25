namespace _07.AppendRowsToExcel
{
    using System;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            // The excel file is in the project directory. If not working properly, please check the path.
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\scores.xlsx; Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

            OleDbConnection excelConnection = new OleDbConnection(connectionString);
            excelConnection.Open();

            OleDbCommand command = new OleDbCommand("INSERT INTO [sheet$] (name, score) VALUES(\"Kostadin Hazurov\", 23)", excelConnection);
            int numberOfInsertedRows = command.ExecuteNonQuery();
            Console.WriteLine("The number of inserted rows is {0}.", numberOfInsertedRows);

            excelConnection.Close();
        }
    }
}