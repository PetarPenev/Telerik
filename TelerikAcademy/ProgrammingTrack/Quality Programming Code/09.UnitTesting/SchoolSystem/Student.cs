namespace SchoolSystem
{
    using System;

    public class Student
    {
        private string name;

        private uint number;

        public Student(string name, uint number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name of the student must be meaningful");
                }

                this.name = value;
            }
        }

        public uint Number
        {
            get 
            {
                return this.number;
            }

            private set 
            {
                if ((value == 0) || (value > 9999))
                {
                    throw new ArgumentOutOfRangeException("Number must be an integer value between 1 and 9999.");
                }

                this.number = value;
            }
        }

        public override string ToString()
        {
            string student = string.Format("Student: {0}, number: {1}.", this.Name, this.Number);

            return student;
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Comparison not initialized.");
            }

            Student other = obj as Student;

            if (other == null)
            {
                throw new ArgumentException("Cannot compare Student with different types.");
            }

            if (this.Number == other.Number)
            {
                if (!this.Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException("Inconsistent naming of student.");
                }

                return true;
            }

            return false;
        }
    }
}
