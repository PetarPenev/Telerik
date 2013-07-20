//-----------------------------------------------------------------------
// <copyright file="Student.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    ///     A class representing a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="firstName">The first name of the student.</param>
        /// <param name="lastName">The last name of the student.</param>
        /// <param name="birthDate">The birth date of the student.</param>
        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        /// <summary>
        ///     Gets the first name of the student. Cannot be modified outside of the class.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        ///     Gets the last name of the student. Cannot be modified outside of the class.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        ///     Gets the birth date of the student. Cannot be modified outside of the class.
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        ///     Checks whether the student is older than another student.
        /// </summary>
        /// <param name="other"><typeparamref name="Student"/>The other student.</param>
        /// <returns><typeparamref name="System.Bool"/> indicating whether the student is older.</returns>
        public bool IsOlderThan(Student other)
        {
            bool isOlder = false;

            int checkIfOlder = DateTime.Compare(this.BirthDate, other.BirthDate);
            if (checkIfOlder < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}
