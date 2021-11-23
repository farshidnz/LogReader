using System;
using System.Collections.Generic;
using System.Linq;

namespace LogReader.Finder.IP
{
    public class Ip
    {
        public List<string> MostActiveIps(List<string> ips, int numberOfActive = 3)
        {
            var mostCommonIpsInOrder = ips.GroupBy(ip => ip).OrderByDescending(group => group.Count()).ToArray();
            var activeIps = new List<string>();
            for (var i = 0; i < numberOfActive; i++)
            {
                activeIps.Add(mostCommonIpsInOrder[i].Key);
            }

            return activeIps;
        }

        public int NumberOfUniqueIps(List<string> ips)
        {
            return ips.Distinct().Count();
        }
    }
}