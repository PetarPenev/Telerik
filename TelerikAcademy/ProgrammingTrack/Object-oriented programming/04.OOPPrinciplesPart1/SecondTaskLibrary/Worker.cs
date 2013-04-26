using System;


namespace SecondTaskLibrary
{
    public class Worker:Human
    {
        // Fields and properties
        private decimal weekSalary;

        public decimal WeekSalary
        {
            get { return weekSalary; }
            private set {
                if (value <= 0)
                    throw new ArgumentException("The salary of the worker must be positive.");
                weekSalary = value; 
            }
        }

        private uint workHoursPerDay;

        public uint WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            private set {
                if (value == 0)
                    throw new ArgumentException("This is not a worker but a slacker. Work hours must be a positive integer!");
                else if (value > 12)
                    throw new ArgumentException("This is illegal - the worker cannot work for more than 12 hours a day.");
                workHoursPerDay = value; 
            }
        }

        // Getting the amount of money per hour
        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public Worker(string firstName, string lastName, decimal salary, uint workHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        // Methods for changing work hours and salary
        public void ChangeWorkHours(uint newHours)
        {
            this.WorkHoursPerDay = newHours;
        }

        public void ChangeSalary(decimal newSalary)
        {
            this.WeekSalary = newSalary;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " Work hours per day: " + this.WorkHoursPerDay + " Weekly salary:" + this.WeekSalary + Environment.NewLine + "Money per hour:" + String.Format("{0:C3}", this.MoneyPerHour());
        }
        
    }
}
