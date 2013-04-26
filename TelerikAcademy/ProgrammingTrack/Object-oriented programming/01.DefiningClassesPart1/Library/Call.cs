using System;

namespace Library
{
    // 8 Task
    public class Call
    {
        // Fields
        private string date;

        private string time;

        private string dialedNumber;

        private decimal duration;


        // Properties
        public string Date
        {
            get { return date; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Date field cannot be empty!");
                }
                date = value; 
            }
        }

       

        public string Time
        {
            get { return time; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Time field cannot be empty!");
                }
                time = value; 
            }
        }


        public string DialedNumber
        {
            get { return dialedNumber; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The DialedNumber field cannot be empty!");
                }
                dialedNumber = value;
            }
        }


        public decimal Duration
        {
            get { return duration; }
            set {
                if (value < 0)
                    throw new ArgumentException("The Duration field cannot be negative.");
                duration = value; 
            }
        }

        // Constructor

        public Call(string date, string time, string dialedNumber, decimal duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        // Override ToString
        public override string ToString()
        {
            return string.Format("Date:{0}, time:{1}, number dialed:{2}, duration:{3} seconds",this.date,this.time,this.dialedNumber, this.duration);
        }
    }
}
