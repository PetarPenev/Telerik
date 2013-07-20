// Moved the classes in separate files, created some methods, removed the unnecessary Cook method outside of the class
// and arranged the methods and calls accordingly.
namespace CookingRoutine
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        public void Peel(Vegetable vegetable)
        {
            vegetable.HasBeenPeeled = true;
            Console.WriteLine("Vegetable {0} has been peeled.", vegetable);
        }

        public void Cut(Vegetable vegetable)
        {
            Console.WriteLine("The {0} has been cut.", vegetable);
        }       

        private Bowl GetBowl()
        {   
            return new Bowl(); 
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }           
    }
}
