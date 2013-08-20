using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace _01.DayReturnerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DayService : IDayService
    {
        public string GetDate(DateTime date)
        {
            CultureInfo bulgarianCulture = CultureInfo.GetCultureInfo("bg-BG");
            return bulgarianCulture.DateTimeFormat.DayNames[(int)date.DayOfWeek];
        }
    }
}
