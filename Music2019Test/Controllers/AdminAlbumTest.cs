using Moq;
using MVCMusicStore2019.Controllers;
using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace Music2019Test.Controllers
{
    public class AdminAlbumTest
    {
        private readonly IEntityRepository<Album> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;

        public AdminAlbumTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Album>(_context);
        }
        [Fact]

        public void AdminArtistIndexText()
        {
            _output.WriteLine("这是AdminArtistController的Index方法的单元测试");

            var mockContext = new Mock<ControllerContext>();

            var controller = new ExampleAlbumController(_repository);
            controller.Index();
            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskAdminAlbumCreate()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现
            id = Guid.NewGuid();
            Guid gId = Guid.NewGuid();//Genre的Id
            Guid aId = Guid.NewGuid();//Artist的Id
            Guid tId = Guid.NewGuid();//AlbumType的Id
            //一组数据新增

            var g = new Genre()
            {
                Id = gId,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };

            var a = new Artist()
            {
                Id = aId,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            };

            var t = new AlbumType()
            {
                Id = tId,
                Name = "AlbumTypeName单元测试",
                Description = "Description单元测试"
            };

            //一条数据
            var album = new Album()
            {
                Id = id,
                Name = "AlbumName单元测试",
                Description = "Description单元测试",
                IssueDate = DateTime.Now,
                Issuer="发行人单元测试",
                Language = "简体中文单元测试",
                Price = 1.00M,

                Genre =g,
                AlbumType=t,
                Artist=a

               
                //GenreId=gId.ToString(),
                //ArtistId=aId.ToString(),
                //AlbumTypeId=tId.ToString()
            };
            //album.Genre.Id = gId;
            //album.Artist.Id = aId;
            //album.AlbumType.Id = tId;
            _repository.AddAndSave(album);

            var result = _repository.GetSingleById(id);

            Assert.NotNull(result);

            //var taskList = new List<Album>();
            //taskList.Add(new Album()
            //{
            //    Id = id,
            //    Name = "AlbumName单元测试",
            //    Description = "Description单元测试"
            //});



        }

        public void Dispose()
        {

        }
    }
}
