using System;
using System.Collections.Generic;

namespace Library
{
    public class GSM
    {
        // Fields
        private string model;

        private string manifacturer;

        private decimal? price;

        private string owner;

        private Battery battery;

        private Display display;

        private List<Call> callHistory;


        // Properties
        // Regarding the 5 Task - I have assumed that correct data for model and manufacturers means non-empty strings
        // and for price - a positive non-zero value. I have assumed that owner, Battery and Display could be null.
        public string Model
        {
            get { return model; }
            set { 
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The model field cannot be empty!");
                }
                model = value;
            }
        }
        

        public string Manifacturer
        {
            get { return manifacturer; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The manufacturer field cannot be empty!");
                }
                manifacturer = value; 
            }
        }
        

        public decimal? Price
        {
            get { return price; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }
                price = value;
            }
        }


        public string Owner{
            get {return owner;}
            set {owner=value;}}
        
        

        public Battery Battery
        {
            get { return battery; }
            set { battery = value; }
        }

       

        public Display Display
        {
            get { return display; }
            set { display = value; }
        }

        
        // 9 Task - add a property CallHistory
        public List<Call> CallHistory
        {
            get { return callHistory; }
            private set { callHistory = value; }
        }

        // Methods
        // 10 Task - add methods for adding and deleting calls from call history
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            foreach (Call c in this.CallHistory)
            {
                if ((c.Date==call.Date)&&(c.DialedNumber==call.DialedNumber)&&(c.Duration==call.Duration)&&(c.Time==call.Time))
                {
                    this.CallHistory.Remove(c);
                    break;
                }
            }
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public void PrintCallHistory()
        {
            if (this.CallHistory.Count == 0)
                Console.WriteLine("There are no calls in the call history!");
            else
            {
                foreach (Call c in this.CallHistory)
                    Console.WriteLine(c);
            }
        }

        // 11 Task - add a method calculating the total cost of calls in call history
        public decimal CalculateCostOfCalls(decimal cost)
        {
            decimal result = 0;
            foreach (var c in this.CallHistory)
            {
                result += c.Duration * cost;
            }
            return result;
        }

        // Constructors
        public GSM(string manufacturer, string model)
        {
            this.Manifacturer = manufacturer;
            this.Model = model;
            this.Owner = null;
            this.Price = null;
            this.Battery = new Battery();
            this.Display = new Display();
            this.CallHistory = new List<Call>();
        }

        public GSM(string manufacturer, string model, string owner, decimal price) :this(manufacturer,model)
        {
            this.Owner = owner;
            this.Price = price;
        }

        public GSM(string manufacturer, string model, string owner, decimal price, Battery battery, Display display) :this(manufacturer,model,owner,price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        // 4 Task - override To String
        public override string ToString()
        {
            return string.Format("Model:{0}, manufacturer:{1}, price:{2}, owner:{3} {9}Battery Info: model:{4},hours idle:{5}, hours talk:{6}, type:{10} {9}Display Info: size:{7}, number of colors:{8} {9}", this.model, this.manifacturer, (this.price!=null) ? this.price.ToString()+"€":"unknown", this.owner ?? "unknown", this.battery.Model ?? "unknown", (this.battery.HoursIdle!=null) ? this.battery.HoursIdle.ToString():"unknown", (this.battery.HoursTalk!=null) ? this.battery.HoursTalk.ToString():"unknown", (this.display.Size!=null) ? this.display.Size.ToString():"unknown", (this.display.NumberColors!=null) ? this.display.NumberColors.ToString():"unknown", Environment.NewLine, (this.Battery.BatteryType!=null)? this.Battery.BatteryType.ToString():"unknown"  );
        }

        // Static field and property - 6 Task
        private static GSM iPhone4S=new GSM("Apple","iPhone 4S", null, 399, new Battery("1552",300,14,BatteryType.LiPo), new Display(3.5m,16000000));

        public static GSM IPhone4S
        {
            get { return GSM.iPhone4S; }
        }
    }
}
