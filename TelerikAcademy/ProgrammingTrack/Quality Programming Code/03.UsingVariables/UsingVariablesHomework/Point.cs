namespace UsingVariablesHomework
{
    using System;

    // Decided to fix the naming of the class and its fields because initially it did not make sense. Clearly, we are not talking
    // about a figure here because a figure does not change its height and width after it is rotated. We are rather 
    // looking at a point that is being rotated in a 2-dimensional space.
    public class Point
    {
        private double firstCoordinate;

        private double secondCoordinate;
        
        public Point(double width, double height)
        {
            this.FirstCoordinate = width;
            this.SecondCoordinate = height;
        }

        // Created properties so that better encapsulation in the class is achieved.
        public double FirstCoordinate
        {
            get { return this.firstCoordinate; }
            set { this.firstCoordinate = value; }
        }

        public double SecondCoordinate
        {
            get { return this.secondCoordinate; }
            set { this.secondCoordinate = value; }
        }

        public static Point GetRotatedPosition(Point previousPoint, double angleOfRotation)
        {
            // Implemented more clear logic - meaning less calculation and
            // nested functions - in this method for better understanding.
            double cosOfRotatingAngle = Math.Cos(angleOfRotation);
            double sinOfRotatingAngle = Math.Sin(angleOfRotation);

            // Math.Abs is unnecessary and therefore we remove it in order to improve performance.
            double widthAfterRotation = cosOfRotatingAngle * previousPoint.FirstCoordinate + sinOfRotatingAngle * previousPoint.SecondCoordinate;
            double heightAfterRotation = cosOfRotatingAngle * previousPoint.SecondCoordinate + sinOfRotatingAngle * previousPoint.FirstCoordinate;

            Point pointAfterRotation = new Point(widthAfterRotation, heightAfterRotation);
            return pointAfterRotation;
        }
    }    
}
