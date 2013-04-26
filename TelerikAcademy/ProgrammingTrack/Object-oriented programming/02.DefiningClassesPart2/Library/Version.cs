using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // 11 Task  - Create a Version attribute
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct | System.AttributeTargets.Interface 
        | System.AttributeTargets.Enum | System.AttributeTargets.Method)]
    public class Version: System.Attribute
    {
        private string major;

        public string Major
        {
          get { return String.Format("{0:0.00}",Convert.ToDecimal(this.major)); }
          set { major = value; }
        }

        public Version(string input)
        {
            this.Major = input;
        }
    }
}
