using System;


namespace Library
{
    public struct Point3D
    {
        // 1 Task - Create a structure Point3D

        // Fields
        private double x;

        private double y;

        private double z;

        // Properties
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        // Constructor
        public Point3D(double first,double second,double third) 
        {
            x=first;
            y=second;
            z=third;
        }

        // Overriding ToString
        public override string ToString()
        {
            return string.Format("({0},{1},{2})", x, y, z);
        }

        // 2 Task - create a static read-only field for the point (0,0,0).
        private static readonly Point3D center = new Point3D(0, 0, 0);

        public static Point3D Center
        {
            get { return Point3D.center; }
        }
    }

}
