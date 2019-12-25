using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Music2019Test
{
    public class ArtistTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Artist _artist;
        public ArtistTest(ITestOutputHelper output)
        {
            _output = output;
            _artist = new Artist();
        }
        //[Fact]
        //public void ArtistEntityTest()
        //{
        //    //Arrange
        //    _output.WriteLine("这是我的Artist业务实体单元测试");
        //    List<Artist> aList = new List<Artist>();
        //    Artist a1 = new Artist { Id = Guid.NewGuid(),Name="张杰", Description="国内歌手" };
        //    Artist a2 = new Artist { Id = Guid.NewGuid(), Name = "王杰", Description = "国内歌手" };
        //    Artist a3 = new Artist { Id = Guid.NewGuid(), Name = "李杰", Description = "国内歌手" };
        //    Artist a4 = new Artist { Id = Guid.NewGuid(), Name = "成杰", Description = "国外歌手" };
        //    Artist a5 = new Artist { Id = Guid.NewGuid(), Name = "丽杰", Description = "国外歌手" };
        //    aList.Add(a1);
        //    aList.Add(a2);
        //    aList.Add(a3);
        //    aList.Add(a4);
        //    //Act
        //    var result = aList.Contains(a5);
        //    var nameResult = aList.Where(x => x.Name.Contains("张杰")).Select(x=>x.Name).First();
        //    _output.WriteLine(nameResult);
        //    //Assert
        //    Assert.False(result);
        //    Assert.Equal("1杰", nameResult);
    }

}
