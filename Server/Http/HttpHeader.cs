using SoftUniWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            CoreValidator.TrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.TrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public String Key { get; private set; }

        public String Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
