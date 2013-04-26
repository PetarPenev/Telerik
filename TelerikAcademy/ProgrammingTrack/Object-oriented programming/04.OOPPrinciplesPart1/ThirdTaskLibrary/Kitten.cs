using System;


namespace ThirdTaskLibrary
{
    public class Kitten:Cat
    {
        public Kitten(string name, char sex, uint age)
            : base(name, sex, age)
        {
            // Kittens can only be female
            if (sex == 'm')
                throw new ArgumentException("Kittens cannot be male!");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Kitten miaou!");
        }
    }
}
