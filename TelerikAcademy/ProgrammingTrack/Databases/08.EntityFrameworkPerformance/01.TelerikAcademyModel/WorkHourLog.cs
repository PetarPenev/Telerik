//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.TelerikAcademyModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHourLog
    {
        public int ChangeID { get; set; }
        public Nullable<int> OldEmployeeID { get; set; }
        public Nullable<System.DateTime> OldReportDate { get; set; }
        public string OldTask { get; set; }
        public Nullable<decimal> OldTaskHours { get; set; }
        public string OldComments { get; set; }
        public Nullable<int> NewEmployeeID { get; set; }
        public Nullable<System.DateTime> NewReportDate { get; set; }
        public string NewTask { get; set; }
        public Nullable<decimal> NewTaskHours { get; set; }
        public string NewComments { get; set; }
        public string Command { get; set; }
    }
}
