using SoftUniWebServer.Server.Common;
using SoftUniWebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.TrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.Headers.Add(new HttpHeader("Location", redirectUrl));
        }
    }
}
