using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class PathStorage
    {
        // 4 Task - Create a static class that can read paths from a file and load path from a file.

        // The entries in the file must be in the format "(x,y,z)" each on seperate line. Txt files are used for testing.
        public static Path GetPath(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
                throw new ArgumentException("File name must contain characters.");
            if (!File.Exists(filePath))
                throw new ArgumentException("File does not exist.");
            Path path = new Path();
            using (StreamReader reader = new StreamReader(filePath, Encoding.Default))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Trim('(', ')');
                    string[] arr = line.Split(',');
                    path.AddPoint(new Point3D(double.Parse(arr[0]),double.Parse(arr[1]),double.Parse(arr[2])));
                    line = reader.ReadLine();
                }
            }
            return path;
        }

        public static void SetPath(string filePath, Path path)
        {
            using (StreamWriter writer = new StreamWriter(filePath,false,Encoding.Default))
            {
                for (int i=0;i<path.Points.Count;i++)
                {
                    string line = String.Format("({0},{1},{2})",path.Points[i].X,path.Points[i].Y,path.Points[i].Z);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
