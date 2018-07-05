using SoftUniWebServer.Server.Common;
using SoftUniWebServer.Server.Http.Contracts;

namespace SoftUniWebServer.Server.Http
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(IHttpRequest request)
        {
            CoreValidator.TrowIfNull(request, nameof(request));

            this.request = request;
        }

        public IHttpRequest Request => this.request;
    }
}
