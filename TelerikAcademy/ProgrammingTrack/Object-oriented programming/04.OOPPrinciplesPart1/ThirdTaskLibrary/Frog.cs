using System;


namespace ThirdTaskLibrary
{
    public class Frog:Animal
    {
        public Frog(string name, char sex, uint age)
            : base(name, sex, age)
        { 
        }

        public override void MakeSound()
        {
            Console.WriteLine("Quack!");
        }
    }
}
