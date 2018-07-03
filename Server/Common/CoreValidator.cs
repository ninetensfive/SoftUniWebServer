using System;

namespace SoftUniWebServer.Server.Common
{
    public static class CoreValidator
    {
        public static void TrowIfNull(object obj, string name)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }
        public static void TrowIfNullOrEmpty(string text, string name)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"{name} cannot be null or empty.", name);
            }
        }
    }
}
