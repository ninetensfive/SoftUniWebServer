using System;

namespace SoftUniWebServer.Server.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message = "Request is not valid.")
            :base(message)
        {       
        }
    }
}
