﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03.Services.Exceptions
{
        public class ServerErrorException : Exception
        {
            public ServerErrorException()
                : base()
            {
            }

            public ServerErrorException(string msg)
                : base(msg)
            {
            }

            public ServerErrorException(string msg, string errCode)
                : base(msg)
            {
                this.ErrorCode = errCode;
            }

            public string ErrorCode { get; set; }
        }
}