using SoftUniWebServer.Server.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        HttpHeaderCollection Headers { get; }
    }
}
