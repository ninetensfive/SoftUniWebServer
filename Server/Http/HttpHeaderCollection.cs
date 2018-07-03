using SoftUniWebServer.Server.Common;
using SoftUniWebServer.Server.Http.Contracts;
using System;
using System.Collections.Generic;

namespace SoftUniWebServer.Server.Http
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CoreValidator.TrowIfNull(header, nameof(header));

            headers[header.Key] = header;
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.TrowIfNullOrEmpty(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader Get(string key)
        {
            CoreValidator.TrowIfNullOrEmpty(key, nameof(key));

            if (!this.headers.ContainsKey(key))
            {
                throw new InvalidOperationException("The given key is not present in the headers collection.");
            }

            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers);
        }
    }
}
