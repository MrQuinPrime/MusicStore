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
    public class AdminArtistTest
    {
        private readonly IEntityRepository<Artist> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;

        public AdminArtistTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Artist>(_context);
        }
        [Fact]

        public void AdminArtistIndexText()
        {
            _output.WriteLine("这是AdminArtistController的Index方法的单元测试");

            var mockContext = new Mock<ControllerContext>();

            var controller = new ExampleArtistController(_repository);
            controller.Index();
            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskAdminArtistCreate()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现
            id = Guid.NewGuid();
            //一组数据新增
            var taskList = new List<Artist>();
            taskList.Add(new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            });
            //一条数据
            var task = new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task);

            var result = _repository.GetSingleById(id);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaskAdminArtistCreateEdit()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现
            id = Guid.NewGuid();
            //一组数据新增
            //var taskList = new List<Artist>();
            //taskList.Add(new Artist()
            //{
            //    Id = id,
            //    Name = "ArtistName单元测试",
            //    Description = "Description单元测试"
            //});
            //一条数据
            var task = new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "ArtistDescription单元测试",
                Tags= "ArtistTag单元测试",
                ViewCount=0,
                Collection=0
            };
            _repository.AddAndSave(task);
            var task2 = new Artist(task)
            {
                Id = task.Id,
                Name = "ArtistName单元测试内容修改",
                Description = "ArtistDescription单元测试内容修改",
                Tags = "ArtistTag单元测试修改",
                ViewCount = 0,
                Collection = 0
            };

            _repository.Edit(task2);


            var result = _repository.GetSingleById(task.Id);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaskAdminArtistDelete()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现

            id = Guid.NewGuid();
            //添加一条数据

            var task = new Artist()
            {
                Id = id,
                Name = "ArtistName单元测试",
                Description = "ArtistDescription单元测试"
            };
            _repository.AddAndSave(task);

            //删除数据
            //Act
            _repository.Delete(task.Id);
            if (task.Id == null)
            {
                string message = "删除成功";
                _output.WriteLine(message);
                Assert.Null(message);
            }

        }

        public void Dispose()
        {

        }
    }
}
