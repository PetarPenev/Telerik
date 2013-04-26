using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SubscriberToTimerWithEvent
    {
        //public SubscriberToTimerWithEvent(

        private FunctionToExecute function;

        public FunctionToExecute Function
        {
            get { return function; }
            private set { function = value; }
        }

        public SubscriberToTimerWithEvent(FunctionToExecute func, TimerWithEvent timer)
        {
            this.Function = func;
            timer.CallAFunction += HandleEvent;
        }

        void HandleEvent(object sender, EventArgs e)
        {
            this.Function();
        }
    }
}
