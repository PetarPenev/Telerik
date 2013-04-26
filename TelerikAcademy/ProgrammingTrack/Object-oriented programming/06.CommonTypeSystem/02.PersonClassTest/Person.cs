using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonClassTest
{
    // Task 4
    public class Person
    {
        // Fields and properties
        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private int? age;

        public int? Age
        {
            get { return age; }
            private set {
                if (age < 0)
                    throw new ArgumentException("Age of the person must be a positive integer.");
                age = value;
            }
        }

        // Constructor that does not necessarily require age
        public Person(string name, int? age = null)
        {
            if (String.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("The name of the person cannot be an empty string.");
            this.Name = name;
            this.Age = age;
        }

        // Overriding ToString
        public override string ToString()
        {
            return String.Format("Name: {0} Age: {1}", this.Name, this.Age == null ? "Unspecified" : this.Age.ToString());
        }
    }
}
