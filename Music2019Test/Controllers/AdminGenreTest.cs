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
    public class AdminGenreTest:IDisposable
    {
        private readonly IEntityRepository<Genre> _repository;
        private readonly MusicDbContext _context;
        private readonly ITestOutputHelper _output;

        public AdminGenreTest(ITestOutputHelper output)
        {
            _output = output;
            _context = new MusicDbContext();
            _repository = new EntityRepository<Genre>(_context);
        }
        [Fact]

        public void AdminGenreIndexText()
        {
            _output.WriteLine("这是AdminGenreController的Index方法的单元测试");

            var mockContext = new Mock<ControllerContext>();

            var controller = new ExampleGenreController(_repository);
            controller.Index();
            mockContext.Verify();
        }

        Guid id;
        [Fact]
        public async Task TaskAdminGenreCreate()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现


            id = Guid.NewGuid();

            //一组数据新增

            //var taskList = new List<Genre>();
            //taskList.Add(new Genre()
            //{
            //    Id = id,
            //    Name = "GenreName单元测试",
            //    Description = "Description单元测试"
            //});

            //一条数据
            var task = new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task);

            var result = _repository.GetSingleById(id);
            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TaskAdminGenreCreateEdit()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现


           
            //一组数据新增
           
            //Arrange
            var task1=new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };

            //Act
            _repository.AddAndSave(task1);


            //一条数据
            //Arrange
            var task2 = new Genre(task1)
            {
                Id = task1.Id,
                Name = "GenreName单元测试内容修改",
                Description = "GenreDescription单元测试内容修改"
            };
            _repository.Edit(task2);

            var result = _repository.GetSingleById(id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TaskAdminGenreDelete()
        {
            //TaskAdminGenreCreate()方法会飘绿，是因为该方法采用异步实现
            //方法会自动检测方法实现中有无await关键字
            //如果没有await,就会飘绿，方法将会按照同步进行实现

            id = Guid.NewGuid();
            //添加一条数据

            var task = new Genre()
            {
                Id = id,
                Name = "GenreName单元测试",
                Description = "Description单元测试"
            };
            _repository.AddAndSave(task);
          
            //删除数据
            //Act
            _repository.Delete(task.Id);            
            if(task.Id==null)
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
