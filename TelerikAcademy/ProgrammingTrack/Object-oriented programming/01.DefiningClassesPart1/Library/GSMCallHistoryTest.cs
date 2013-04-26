using System;

namespace Library
{
    // 12 Task
    public class GSMCallHistoryTest
    {
        private GSM gsm = new GSM("Apple", "IPhone");

        public GSM Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }

        public void Test()
        {
            Call[] array = new Call[] {
                new Call("20.02.2013","15:42","0888123123",12.56m),
                new Call("20.02.2013","16:17","0887557432",2.1m),
                new Call("20.02.2013","21:23","0889631422",11.0m)
            };
            foreach (Call c in array)
                gsm.AddCall(c);
            gsm.PrintCallHistory();
            Console.WriteLine();
            Console.WriteLine("The total price of all calls is {0:C}.", gsm.CalculateCostOfCalls(0.37m));
            Call callToBeRemoved=new Call("a","a","a",0);
            foreach (Call c in gsm.CallHistory)
                if (c.Duration >= callToBeRemoved.Duration)
                    callToBeRemoved = c;
            if (callToBeRemoved.Duration != -1)
                gsm.RemoveCall(callToBeRemoved);
            Console.WriteLine("The new total price of all calls bar the removed one is {0:C}.", gsm.CalculateCostOfCalls(0.37m));
            gsm.ClearCallHistory();
            gsm.PrintCallHistory();
        }
    }
}
