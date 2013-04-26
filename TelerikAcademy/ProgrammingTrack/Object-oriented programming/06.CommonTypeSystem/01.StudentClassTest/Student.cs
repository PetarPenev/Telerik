using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentClassTest
{

    public enum Specialities
    {
        Maths, Physics, Chemistry, History, Art, Economics, Journalistics, CivilEngineering, ComputerScience, MechanicalEngineering
    }

    public enum Universities
    {
        SofiaUniversity, PlovdivUniversity, TechnicalUniversity, UACEG, UNSS
    }

    public enum Faculties
    {
        Engineering, Economics, Journalism, Physics, Maths, Chemistry
    }

    // Tasks 1,2,3
    public  class Student :ICloneable, IComparable<Student>
    {
        // Fields and properties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string middleName;

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private ulong ssn;

        public ulong Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private string permanentAddress;

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set { permanentAddress = value; }
        }

        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private byte course;

        public byte Course
        {
            get { return course; }
            set { 
                if ((value>4) || (value==0))
                    throw new ArgumentException("Course must be between 1 and 4");
                course = value;
            }
        }

        private Specialities speciality;

        public Specialities Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        private Faculties faculty;

        public Faculties Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        private Universities university;

        public Universities University
        {
            get { return university; }
            set { university = value; }
        }

        // Constructor
        public Student(string firstName, string middleName, string lastName, ulong ssn, string address, string mail,
            string phone, byte course, Specialities speciality, Faculties faculty, Universities university)
        {
            this.firstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = address;
            this.Mail = mail;
            this.Phone = phone;
            this.Course = course;
            this.Speciality = speciality;
            this.Faculty = faculty;
            this.University = university;
        }

        // Overriding methods
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Student check = (Student)obj;
            if ((System.Object)check == null)
                return false;
            return ((check.FirstName==this.FirstName) && (check.MiddleName==this.MiddleName) && (check.LastName==this.LastName)
                && (check.Ssn==this.Ssn) && (check.PermanentAddress==this.PermanentAddress) && (check.Mail==this.Mail) &&
                (check.Phone==this.Phone) && (check.Course==this.Course) && (check.Speciality==this.Speciality)
                && (check.Faculty==this.Faculty) && (check.University==this.University));
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(String.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            str.AppendLine(String.Format("Social security number: {0}", this.Ssn));
            str.AppendLine(String.Format("Address: {0}, e-mail:{1}, phone:{2}", this.PermanentAddress, this.Mail, this.Phone));
            str.AppendLine(String.Format("University: {0}, Faculty: {1}, Speciality: {2}, Course: {3}", this.University, this.Faculty, this.Speciality, this.Course));
            return str.ToString();
        }

        public override int GetHashCode()
        {
            return this.Ssn.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        // Cloning (deep copy)
        public object Clone()
        {
            Student st = new Student(String.Copy(this.FirstName), String.Copy(this.MiddleName), String.Copy(this.LastName),
            this.Ssn, String.Copy(this.PermanentAddress), String.Copy(this.Mail), String.Copy(this.Phone),
            this.Course, this.Speciality, this.Faculty, this.University);
            return st;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
                return this.FirstName.CompareTo(other.FirstName);
            else if (this.MiddleName != other.MiddleName)
                return this.MiddleName.CompareTo(other.MiddleName);
            else if (this.LastName != other.LastName)
                return this.LastName.CompareTo(other.LastName);
            else if (this.Ssn != other.Ssn)
                return this.Ssn.CompareTo(other.Ssn);
            else
                return 0;
        }
    }
}
