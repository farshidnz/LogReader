#nullable enable
using System;
using System.Linq;
using System.Security.Cryptography;

namespace LogReader.Logs
{
    public static class Logs
    {
        public static string? GetIps(string log)
        {
            log = log.Replace("admin", "-");
            if (log.Contains("- -") == false)
            {
                return null;
            }
            var inputArray = log.Split("- -", 5);
            return inputArray.First();
        }

        public static string GetUrls(string log)
        {
            log = log.Replace("admin", "-");
            var inputArray = log.Split("- -", 5);

            var url = inputArray.Last();

            var positionOfGet = url.IndexOf("GET", StringComparison.Ordinal);
            url = url.Remove(0, positionOfGet);

            var positionOfHttp = url.IndexOf("HTTP", StringComparison.Ordinal);
            return url.Remove(positionOfHttp);
        }
    }
}