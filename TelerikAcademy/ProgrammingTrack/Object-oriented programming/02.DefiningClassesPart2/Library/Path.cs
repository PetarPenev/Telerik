using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Path
    {
        // 4 Task - Create a class path for holding a sequence of points.
        private List<Point3D> points;

        public List<Point3D> Points
        {
            get { return points; }
            private set { points = value; }
        }

        public Point3D this[int index]
        {
            get {
                if ((index < 0) || (index >= this.Points.Count))
                    throw new ArgumentOutOfRangeException("Index of Point3D list out of range");
                return points[index];
            }
        }

        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public void AddPoint(Point3D point)
        {
            Points.Add(point);
        }
    }
}
