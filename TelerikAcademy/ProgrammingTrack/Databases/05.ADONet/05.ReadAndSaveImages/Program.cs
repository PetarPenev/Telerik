//// !!! IMPORTANT !!! Please check whether the connection string specified in the task is the same as the necessary one for
//// your local machine. You can change the connection string by right-clicking on the project and selecting Properties, then Settings.

namespace _05.ReadAndSaveImages
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    //// Images will be stored in bin\debug\images directory.
    public class Program
    {
        public static void Main()
        {
            SqlConnection northwindConnection = new SqlConnection(Properties.Settings.Default.DBConnectionString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", northwindConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    // Due to the differences between the way images are stored in the default Northwind database and the regular
                    // format, we need to offset the first 78 bytes of the image data because the name of the image is saved there.
                    // If you choose to modify the code and work with other image data that does not suffer from such problems, please
                    // change headerLength from 78 to 0.
                    byte[] imageDataBeforeTruncating = (byte[])reader["Picture"];
                    int headerLength = 78;
                    int length = imageDataBeforeTruncating.Length;

                    string directoryPath = Directory.GetCurrentDirectory();
                    directoryPath += "\\Images\\";
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = directoryPath + reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
                    FileStream stream = File.OpenWrite(fileName);
                    Console.WriteLine();
                    using (stream)
                    {
                        stream.Write(imageDataBeforeTruncating, headerLength, length - headerLength);
                    }
                }
            }

            northwindConnection.Close();
        }
    }
}
