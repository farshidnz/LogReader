using FluentAssertions;
using Xunit;

namespace LogReader.Tests.Logs
{
    public class ReadLogs
    {
        [Fact]
        public void Should_Find_Ip()
        {
            //Arrange
            const string ip = "168.41.191.40";
            var log =
                $"{ip} - - [09/Jul/2018:10:11:30 +0200] \"GET http://example.net/faq/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Linux; U; Android 2.3.5; en-us; HTC Vision Build/GRI40) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1";
            
            //Act
            var ipResponse = LogReader.Logs.Logs.GetIps(log);
            
            //Assert
            ipResponse!.Trim().Should().Match(ip);
        }
        
        [Fact]
        public void Should_Find_Urls()
        {
            //Arrange
            const string ip = "168.41.191.40";
            const string url = "GET http://example.net/faq/";
            var log =
                $"{ip} - - [09/Jul/2018:10:11:30 +0200] \"GET http://example.net/faq/ HTTP/1.1\" 200 3574 \"-\" \"Mozilla/5.0 (Linux; U; Android 2.3.5; en-us; HTC Vision Build/GRI40) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1";

            //Act
            var urlResponse = LogReader.Logs.Logs.GetUrls(log);
            
            //Assert
            urlResponse!.Trim().Should().Match(url);
        }
        
        [Fact]
        public void Should_Not_Find_Ip()
        {
            //Arrange
            var log = "INVALID LOG";
            
            //Act
            var ipResponse = LogReader.Logs.Logs.GetIps(log);
            
            //Assert
            ipResponse.Should().BeNull();
        }
    }
}