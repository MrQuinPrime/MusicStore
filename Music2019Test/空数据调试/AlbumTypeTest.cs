using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Music2019Test
{
    public class AlbumTypeTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AlbumType _albumType;
        public AlbumTypeTest(ITestOutputHelper output)
        {
            _output = output;
            _albumType = new AlbumType();
        }
        [Fact]
        public void AlbumTypeEntityTest()
        {
            //Arrange
            _output.WriteLine("这是我的AlbumType业务实体单元测试");
            List<AlbumType> aList = new List<AlbumType>();
            AlbumType a1 = new AlbumType { Id = Guid.NewGuid(), Name = "电音", Description = "类型" };
            AlbumType a2 = new AlbumType { Id = Guid.NewGuid(), Name = "纯音", Description = "类型" };
            AlbumType a3 = new AlbumType { Id = Guid.NewGuid(), Name = "中文", Description = "类型" };
            AlbumType a4 = new AlbumType { Id = Guid.NewGuid(), Name = "英文", Description = "类型" };
            AlbumType a5 = new AlbumType { Id = Guid.NewGuid(), Name = "日文", Description = "类型 " };
            aList.Add(a1);
            aList.Add(a2);
            aList.Add(a3);
            aList.Add(a4);
            //Act
            var result = aList.Contains(a5);
            var nameResult = aList.Where(x => x.Name.Contains("电音")).Select(x => x.Name).First();
            _output.WriteLine(nameResult);
            //Assert
            Assert.False(result);
            Assert.Equal("电音", nameResult);
        }
    }
}
