namespace _06.ReadExcelFile
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

            // I am using [Лист1$] because my Excel is configured in Bulgarian. Please change to [Sheet1$] or the appropriate name
            // if necessary.
            OleDbCommand command = new OleDbCommand("SELECT * FROM [sheet$]", excelConnection);
            OleDbDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " -> " + reader[1]);
                }
            }

            excelConnection.Close();
        }
    }
}
