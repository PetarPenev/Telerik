using System;


namespace ThirdTaskLibrary
{
    public class Tomcat:Cat
    {
        public Tomcat(string name, char sex, uint age)
            : base(name, sex, age)
        {
            // Tomcats can only be male.
            if (sex == 'f')
                throw new ArgumentException("Tomcats cannot be female.");
        }

        public override void MakeSound()
        {
            Console.WriteLine("Tomcat miaowuuuu!");
        }
    }
}
