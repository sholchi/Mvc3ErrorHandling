using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElmahAndMvc3.ErrorHandler.Exceptions
{
    public class JavaScriptException : Exception
    {
        string message;

        public override string Message
        {
            get
            {
                if (message.Contains(": at document path "))
                {
                    return message.Substring(0, message.IndexOf(": at document path "));
                }
                return message;
            }
        }

        public JavaScriptException(string message) : base(message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return message;
        }
    }
}