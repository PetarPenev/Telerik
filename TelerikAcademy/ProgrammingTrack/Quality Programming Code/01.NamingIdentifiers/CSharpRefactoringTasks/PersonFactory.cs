namespace Tasks
{
    using System;

    // Not necessary to put the enum into a seperate file as it is being used only by 
    // the class PersonFactory.
    public enum Gender
    {
        Male, Female
    }

    public class PersonFactory
    {
        /// <summary>
        /// Class Person represents a human being. It is private
        /// so that the only way to instantiate it is through the factory.
        /// </summary>
        private class Person
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }

        public void CreatePerson(int age)
        {
            Person newPerson = new Person();
            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "John";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "Jane";
                newPerson.Gender = Gender.Female;
            }
        }
    }
}