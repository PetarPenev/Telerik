using System;
using System.Threading;

namespace Library
{
    // Using external delegate as it may be necessary to use the delegate with another class at a later time.
    public delegate void FunctionToExecute();

    // 7 Task
    public class TimerWithDelegate
    {
        private FunctionToExecute function;

        public FunctionToExecute Function
        {
          get { return this.function; }
          private set { this.function = value; }
        }

        private uint interval;

        public uint Interval
        {
            get { return interval; }
            private set { interval = value; }
        }

        public TimerWithDelegate(FunctionToExecute func, uint interval)
        {
            this.Function = func;
            this.Interval = interval*1000;
        }

        public void ExecuteTimer(int numberOfExecutions)
        {
            for (int i = 0; i < numberOfExecutions; i++)
            {
                Thread.Sleep((int)this.Interval);
                this.Function();
            }
        }
        
    }
}
