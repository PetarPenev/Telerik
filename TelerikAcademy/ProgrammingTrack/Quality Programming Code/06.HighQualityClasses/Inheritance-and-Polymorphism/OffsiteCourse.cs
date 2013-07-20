//-----------------------------------------------------------------------
// <copyright file="OffsiteCourse.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     A class that is conducted in another town.
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        ///      The name of the town where the class is conducted.
        /// </summary>
        private string town;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        public OffsiteCourse(string name) : base(name, null, null)
        {
            this.Town = null;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        public OffsiteCourse(string name, string teacherName) : base(name, teacherName, null)
        {
            this.Town = null;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OffsiteCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <param name="students">The list of the enrolled students.</param>
        public OffsiteCourse(string name, string teacherName, IList<string> students) : base(name, teacherName, students)
        {
            this.Town = null;
        }

        /// <summary>
        ///  Gets or sets the name of the town.
        /// </summary>
        public string Town
        {
            get
            {
                if (this.town != null)
                {
                    return string.Copy(this.town);
                }

                return null;
            }

            set
            {
                this.town = value;
            }
        }

        /// <summary>
        ///     Overrides the ToString method of the base class <see cref="Course"/>.
        /// </summary>
        /// <returns>The string representation of the instance.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
                result.Append(" }");
            }

            return result.ToString();
        }
    }
}
