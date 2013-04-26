using System;

namespace SecondTaskLibrary
{
    public abstract class Human
    {
        // Fields and properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            private set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("The first name canno be null or empty.");
                firstName = value; 
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("The last name canno be null or empty.");
                lastName = value; 
            }
        }

        // The protected constructor
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
}
