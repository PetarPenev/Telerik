// Created a class and moved some of the code out in different methods. Also wrote some additional code
// so that the whole program can make sense.
namespace IfStatementsRefactoring
{
    using System;
    using CookingRoutine;

    public class ExecuteConditionals
    {
        public const int MinX = 0;
        public const int MaxX = 1000;

        public const int MinY = 0;
        public const int MaxY = 1000;

        public static void Main()
        {
            CookPotato();
            CheckCell(10, 11, true);
        }

        private static void CookPotato()
        {
            Potato potato = new Potato();
            Chef utiBachvarov = new Chef();

            utiBachvarov.Peel(potato);
            if (potato != null)
            {
                if (!potato.IsRotten && potato.HasBeenPeeled)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Vegetable vegetable)
        {
            Console.WriteLine("Vegetable {0} is being cooked.", vegetable);
        }

        private static void CheckCell(int x, int y, bool shouldVisitCell)
        {
            if (IsInRange(x, y) && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }

        private static bool IsInRange(int x, int y)
        {
            bool isInRange = (MinX <= x) && (x <= MaxX) && (MinY < y) && (y <= MaxY);
            return isInRange;
        }

        private static void VisitCell(int x, int y)
        {
            Console.WriteLine("Cell ({0},{1}) is visited.", x, y);
        }
    }
}
