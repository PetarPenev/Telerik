using System;
using System.ComponentModel;
using Library;

namespace Library
{
    // 3 Task - enumeration
    public enum BatteryType
    { 
        None=0,[Description("Li-Ion")]LiIon=1,NiMH=2,NiCd=3, LiPo=4
    }

    public class Battery
    {
        // Fields
        private string model;

        private int? hoursIdle;

        private int? hoursTalk;

        private BatteryType? batteryType;
        
        // Properties

        public string Model{get;set;}

        

        public int? HoursIdle
        {
            get { return hoursIdle; }
            set {
                if (value <= 0) 
                {
                    throw new ArgumentException("Value of hoursIdle must be positive!");
                }
                hoursIdle = value; 
            }
        }

       

        public int? HoursTalk
        {
            get { return hoursTalk; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Value of hoursTalk must be positive!");
                }
                hoursTalk = value;
            }
        }



        public BatteryType? BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        // Constructors

        public Battery()
        {
            this.Model = null;
            this.HoursIdle = null;
            this.HoursTalk = null;
            this.BatteryType = Library.BatteryType.None;
        }

        public Battery(string model, int? hoursIdle)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = null;
            this.BatteryType = Library.BatteryType.None;
        }


        public Battery(string model, int? hoursIdle, int? hoursTalk) :this(model,hoursIdle)
        {
            this.HoursTalk = hoursTalk;
        }

        public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType batteryType) :this(model, hoursIdle, hoursTalk)
        {
            this.BatteryType = batteryType;
        }
    }
}
