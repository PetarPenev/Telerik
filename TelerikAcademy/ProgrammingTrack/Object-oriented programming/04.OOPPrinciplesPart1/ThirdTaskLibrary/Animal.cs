using System;


namespace ThirdTaskLibrary
{
    public abstract class Animal: ISound
    {
        //Fields and properties
        private uint age;

        public uint Age
        {
            get { return age; }
            private set {
                if (age > 120)
                    throw new ArgumentException("There is no such animal! Age is too high a value.");
                age = value;
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("The name of the animal cannot be null or empty.");
                name = value; 
            }
        }

        private char sex;

        public char Sex
        {
            get { return sex; }
            set {
                if ((value != 'm') && (value != 'f'))
                    throw new ArgumentException("Sex can be only male or female.");
                sex = value;
            }
        }

        public virtual void MakeSound(){}

        // A protected constructor
        protected Animal(string name, char sex, uint age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }
}
