using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LogReader.Finder.IP;
using Xunit;

namespace LogReader.Tests
{
    public class MostActiveIps
    {
        [Fact]
        public void Should_Find_Most_Active_Ips()
        {
            //Arrange
            var ips = new List<string> {"1", "2", "1", "2", "1", "3", "4"};
            var ip = new Ip();
            
            //Act
            var mostActive = ip.MostActiveIps(ips);
            
            //Assert
            mostActive.Should().Contain("1");
            mostActive.Should().Contain("2");
            mostActive.Should().Contain("3");
        }
        [Fact]
        public void Should_Find_Unique_Number_Of_Ips()
        {
            //Arrange
            var ips = new List<string> {"1", "2", "1", "2", "1", "3", "4"};
            var ip = new Ip();
            
            //Act
            var numberOfUniqueIps = ip.NumberOfUniqueIps(ips);
            
            //Assert
            numberOfUniqueIps.Should().Be(ips.Distinct().Count());
        }
    }
}