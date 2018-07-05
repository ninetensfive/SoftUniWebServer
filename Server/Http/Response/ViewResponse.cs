using SoftUniWebServer.Server.Contracts;
using SoftUniWebServer.Server.Enums;
using SoftUniWebServer.Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http.Response
{
    public class ViewResponse : HttpResponse
    {
        private IView view;

        public ViewResponse(HttpStatusCode statusCode, IView view)
        {
            ValidateStatusCode();
            this.StatusCode = statusCode;
            this.view = view;
        }

        private void ValidateStatusCode()
        {

            if (((int)this.StatusCode < 300) || ((int)this.StatusCode > 399))
            {
                throw new InvalidResponseException("View responses need a status code below 300 and above 400");
            }
        }

        public override string ToString()
        {
            return base.ToString() + this.view.View();
        }
    }
}
