using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Music2019Test
{
    public class GenreTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Genre _genre;
        public GenreTest(ITestOutputHelper output)
        {
            _output = output;
            _genre = new Genre();
        }
        [Fact]
        public void GenreEntityTest()
        {
            //Arrange
            _output.WriteLine("这是我的Artist业务实体单元测试");
            List<Genre> aList = new List<Genre>();
            Genre a1 = new Genre { Id = Guid.NewGuid(), Name = "自由", Description = "流派" };
            Genre a2 = new Genre { Id = Guid.NewGuid(), Name = "经典", Description = "流派" };
            Genre a3 = new Genre { Id = Guid.NewGuid(), Name = "复古", Description = "流派" };
            Genre a4 = new Genre { Id = Guid.NewGuid(), Name = "民谣", Description = "流派" };
            Genre a5 = new Genre { Id = Guid.NewGuid(), Name = "传统", Description ="流派 "};
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            //Act
            var result = aList.Contains(a5);
            var nameResult = aList.Where(x => x.Name.Contains("自由")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            //Assert
            Assert.False(result);
            Assert.Equal("自由", nameResult);
        }
    }
}
