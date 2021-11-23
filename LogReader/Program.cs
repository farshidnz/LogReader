using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LogReader.Finder.IP;
using LogReader.Finder.Urls;

namespace LogReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to log file reader app!");
            const string logPath = @"programming-task-example-data.log";
            var ipAddresses = new List<string>();
            var urls = new List<string>();

            var lines = File.ReadAllLines(logPath);

            foreach (var line in lines)
            {
                ipAddresses.Add(Logs.Logs.GetIps(line));
                urls.Add(Logs.Logs.GetUrls(line));
            }

            var ipFinder = new Ip();
            Console.WriteLine("Most active ip address: " );
            var mostActiveIps = ipFinder.MostActiveIps(ipAddresses);
            foreach (var ip in mostActiveIps)
            {
                Console.WriteLine(ip);
            }
            
            Console.WriteLine("Number of unique ip addresses: " + ipFinder.NumberOfUniqueIps(ipAddresses));
            
            var urlFinder = new Url();
            var mostVisitedUrls = urlFinder.MostVisitedUrl(urls);
            Console.WriteLine("Most visited urls: " );
            foreach (var url in mostVisitedUrls)
            {
                Console.WriteLine(url);
            }
        }
    }
}