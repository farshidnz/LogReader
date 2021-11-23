using System.Collections.Generic;
using System.Linq;

namespace LogReader.Finder.Urls
{
    public class Url
    {
        public List<string> MostVisitedUrl(List<string> urls, int numberOfMostVisitedUrl = 3)
        {
            var mostCommonUrlsInOrder = urls.GroupBy(url => url).OrderByDescending(group => group.Count()).ToArray();
            var mostVisited = new List<string>();
            for (var i = 0; i < numberOfMostVisitedUrl; i++)
            {
                mostVisited.Add(mostCommonUrlsInOrder[i].Key);
            }

            return mostVisited;
        }
    }
}