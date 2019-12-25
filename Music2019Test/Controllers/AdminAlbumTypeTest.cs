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
    public class AdminAlbumTypeTest : IDisposable
    {
        private readonly IEntityRepository<AlbumType> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;

        public AdminAlbumTypeTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<AlbumType>(_context);
        }
        [Fact]

        public void AdminAlbumTypeIndexText()
        {
            _output.WriteLine("这是AdminAlbumTypeController的Index方法的单元测试");

            var mockContext = new Mock<ControllerContext>();

            var controller = new ExampleAlbumTypeController(_repository);
            controller.Index();
            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskAdminAlbumTypeCreate()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现
            id = Guid.NewGuid();
            //一组数据新增
            //var taskList = new List<AlbumType>();
            //taskList.Add(new AlbumType()
            //{
            //    Id = id,
            //    Name = "AlbumTypeName单元测试",
            //    Description = "AlbumTypeDescription单元测试"
            //});
            //一条数据
            var task = new AlbumType()
            {
                Id = id,
                Name = "AlbumTypeName单元测试",
                Description = "AlbumTypeDescription单元测试"
            };
            _repository.AddAndSave(task);

            var result = _repository.GetSingleById(id);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaskAdminAlbumTypeCreateEdit()
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
            var task = new AlbumType()
            {
                Id = id,
                Name = "AlbumTypeName单元测试",
                Description = "AlbumTypeDescription单元测试"
            };

            _repository.AddAndSave(task);

            var task2 = new AlbumType(task)
            {
                Id = task.Id,
                Name = "ArtistName单元测试内容修改",
                Description = "AlbumTypeDescription单元测试内容修改"
            };

            _repository.Edit(task2);


            var result = _repository.GetSingleById(task.Id);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task TaskAdminAlbumTypeDelete()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现

            id = Guid.NewGuid();
            //添加一条数据

            var task = new AlbumType()
            {
                Id = id,
                Name = "AlbumTypeName单元测试",
                Description = "AlbumTypeDescription单元测试"
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
