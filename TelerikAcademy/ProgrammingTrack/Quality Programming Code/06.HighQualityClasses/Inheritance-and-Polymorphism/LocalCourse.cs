//-----------------------------------------------------------------------
// <copyright file="LocalCourse.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     A class that is conducted in-house.
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        ///     The name of the lab where the course is conducted.
        /// </summary>
        private string lab;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        public LocalCourse(string name) : base(name, null, null)
        {
            this.Lab = null;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        public LocalCourse(string name, string teacherName) : base(name, teacherName, null)
        {
            this.Lab = null;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <param name="students">The students enrolled in the class.</param>
        public LocalCourse(string name, string teacherName, IList<string> students) : base(name, teacherName, students)
        {
            this.Lab = null;
        }

        /// <summary>
        ///     Gets or sets the name of the lab.
        /// </summary>
        public string Lab
        {
            get
            {
                if (this.lab != null)
                {
                    return string.Copy(this.lab);
                }

                return null;
            }

            set
            {
                this.lab = value;
            }
        }

        /// <summary>
        ///     Overriding the ToString method for the abstract class <see cref="Course"/>.
        /// </summary>
        /// <returns>The string representation of the <see cref="LocalCourse"/> instance.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
                result.Append(" }");
            }
           
            return result.ToString();
        }
    }
}
