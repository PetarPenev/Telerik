using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Library
{
    public delegate void MethodToExecuteHandler(object sender, EventArgs e);

    public class TimerWithEvent
    {
        public event MethodToExecuteHandler CallAFunction;

        private uint interval;

        public uint Interval
        {
            get;
            private set;
        }

        private uint timesRaised;

        public uint TimesRaised
        {
            get;
            private set;
        }

        // The constructor. The interval is converted from seconds to milliseconds.
        public TimerWithEvent(uint interval, uint timesRaised)
        {
            this.Interval = interval*1000;
            this.TimesRaised = timesRaised;
        }

        // The execution method. The event is raised the specified number of times and we "freeze" the program
        // just before that for the required interval.
        public void StartExecution()
        {
            for (int i=0;i<this.TimesRaised;i++)
            {
                Thread.Sleep((int)this.Interval);
                // The event is raised without any arguments as we do not need any for the current implementation.
                RaiseEvent(EventArgs.Empty);
            }
        }

        protected virtual void RaiseEvent(EventArgs e)
        {
            // We create a copy of the delegate and if it is not empty we raise the event with the required parameters.
            MethodToExecuteHandler handler = CallAFunction;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
