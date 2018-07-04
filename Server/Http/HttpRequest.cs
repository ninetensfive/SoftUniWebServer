using SoftUniWebServer.Server.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using SoftUniWebServer.Server.Enums;
using SoftUniWebServer.Server.Common;
using System.Linq;
using SoftUniWebServer.Server.Exceptions;

namespace SoftUniWebServer.Server.Http
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestText)
        {
            CoreValidator.TrowIfNullOrEmpty(requestText, nameof(requestText));

            this.FormData = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestText);
        }

        private void ParseRequest(string requestText)
        {
            var requestLines = CoreParser.Split(requestText, new[] { Environment.NewLine });
            if (!requestLines.Any())
            {
                throw new BadRequestException();
            }

            var requestLine = CoreParser.Split(requestLines[0], new char[] { ' ' });
            if (requestLine.Length != 3
                || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException();
            }

            this.Method = ParseMethod(requestLine[0]);
            this.Url = requestLine[1];
            this.Path = this.ParsePath(this.Url);
            this.ParseHeaders(requestLines);


        }



        public IDictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.TrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.TrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private HttpRequestMethod ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch
            {
                throw new BadRequestException();
            }
        }

        private string ParsePath(string url)
        {
            return CoreParser.Split(url, new char[] { '?', '#' }).FirstOrDefault();
        }

        private void ParseHeaders(string[] requestLines)
        {
            var endOfHedears = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < endOfHedears; i++)
            {
                var headerLine = CoreParser.Split(requestLines[i], new char[] { ':' });

                if(headerLine.Length != 2)
                {
                    throw new BadRequestException();
                }

                var key = headerLine[0];
                var value = headerLine[1].Trim();

                this.Headers.Add(new HttpHeader(key, value));
            }

            if (!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException();
            }
        }
    }
}
