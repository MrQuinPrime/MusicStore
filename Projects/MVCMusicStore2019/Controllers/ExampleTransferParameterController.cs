using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    /// <summary>
    /// !!!!!!!!!!!!!!!!!!该案例为了上课方便使用，违反编程规范，编程时不要使用此种实现方式
    /// </summary>
    public class StudentList : List<StudentDemo> { }
    public class StudentDemo
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string ClassName { get; set; }
    }
    public class ExampleTransferParameterController : Controller
    {
        public ActionResult StuList()
        {
            //通过泛型集合名义一个学生集合，同时进行初始化操作，并返回该集合列表
            //List<T>
            List<StudentDemo> students = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo();
            stu1.Id = 10;
            stu1.Name = "门矢士";
            stu1.ClassName = "平成10周年班";
            StudentDemo stu2 = new StudentDemo();
            stu2.Id = 20;
            stu2.Name = "常磐庄吾";
            stu2.ClassName = "平成20周年班";
            students.Add(stu1);
            students.Add(stu2);
            return View(students);
        }

        // GET: ExampleTransferParameter
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JumpSite()
        {
            return new RedirectResult("http://163.com");
        }
        public void NotResult() { }
        public EmptyResult NullResult()
        {
            return null;
        }
    }
}