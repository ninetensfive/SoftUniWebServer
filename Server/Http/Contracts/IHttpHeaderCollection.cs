using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniWebServer.Server.Http.Contracts
{
    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader Get(string key);
    }
}
