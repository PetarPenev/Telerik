using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // 3 Task
    public static class EuclidianDistance
    {
        static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            // Here we are using direct calculation instead of Math.Pow because it computes faster.
            return Math.Sqrt((firstPoint.X-secondPoint.X)*(firstPoint.X-secondPoint.X)+(firstPoint.Y-secondPoint.Y)*(firstPoint.Y-secondPoint.Y)+(firstPoint.Z-secondPoint.Z)*(firstPoint.Z-secondPoint.Z));
        }
    }
}
