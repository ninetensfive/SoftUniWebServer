using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Exceptions
{
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            :base(message)
        {

        }
    }
}
