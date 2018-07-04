using System;

namespace SoftUniWebServer.Server.Common
{
    public static class CoreParser
    {
        public static string[] Split(string text, char[] separator)
        {
            return text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] Split(string text, string[] separator)
        {
            return text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
