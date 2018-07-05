using SoftUniWebServer.Server.Common;
using SoftUniWebServer.Server.Contracts;
using SoftUniWebServer.Server.Enums;
using SoftUniWebServer.Server.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        private string StatusCodeMessage => this.StatusCode.ToString();

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();
        public HttpStatusCode StatusCode { get; protected set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {this.StatusCode} {this.StatusCodeMessage}");
            result.AppendLine(this.Headers.ToString());
            result.AppendLine();


            return result.ToString();
        }
    }
}
