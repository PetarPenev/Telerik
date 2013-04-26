using System;


namespace ThirdTaskLibrary
{
    public class Cat:Animal
    {
        public Cat(string name, char sex,uint age): base(name,sex,age)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Miaowww");
        }
    }
}
