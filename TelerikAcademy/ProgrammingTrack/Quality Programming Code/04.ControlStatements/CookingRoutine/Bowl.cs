namespace CookingRoutine
{
    using System;
    using System.Collections.Generic;

    public class Bowl
    {
        private List<Vegetable> vegetables;

        public void Add(Vegetable vegetable)
        {
            this.vegetables.Add(vegetable);
            Console.WriteLine("Vegetable {0} added to the bowl.", vegetable);
        }
    }
}
