using System;


namespace ThirdTaskLibrary
{
    public class Dog:Animal
    {
        public Dog(string name, char sex, uint age)
            : base(name, sex, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau!");
        }
    }
}
