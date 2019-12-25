using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    /// <summary>
    /// 不要使用该例方法编写代码，因为它违反代码规范
    /// </summary>
    public class ExampleGenriceList
    {
        public List<StudentDemo>GetAll()
        {
            List<StudentDemo> students = new List<StudentDemo>();
            StudentDemo stu1 = new StudentDemo();
            stu1.Id = 10;
            stu1.Name = "门矢士";
            stu1.ClassName = "平成10周年班";
            StudentDemo stu2 = new StudentDemo();
            stu2.Id = 20;
            stu2.Name = "常磐庄吾";
            stu2.ClassName = "平成20周年班";
            StudentDemo stu3 = new StudentDemo { Id = 30, Name = "zero1", ClassName = "令和" };
            students.Add(stu3);
            students.Add(stu1);
            students.Add(stu2);
            return students;
        }
    }
    public class ExampleLINQLambdaController : Controller
    {
        // GET: ExampleLINQLambda
        public ActionResult Index()
        {
            ExampleGenriceList genriceList = new ExampleGenriceList();
            var list=genriceList.GetAll();
            //当前我们对list这个集合进行LINQ简单查询
            var linqList1 = from x in list
                            select x;
            //SQL条件精确查询：select * from 表名 where 条件
            var linqList2 = from x in list
                            where x.Name == "李四"//精确查询
                            select x;
            //SQL条件模糊查询：select * from 表名 where ClassName like '%软件%'
            var linqList3 = from x in list
                            where x.ClassName.Contains("软件")//Contains:包含
                            select x;

            //SQL排序： select * from list order by Name desc
            var linqList4 = from x in list
                            orderby x.Name descending
                            select x;
            //SQL计数： select count(*) from list
            var linqList5 = (from x in list
                             select x).Count();
            //SQL联接：select * from x inner on x.Id=y.Id
            var linqList6 = from x in list
                            join y in list on x.Id equals y.Id
                            select x;
            //SQL分组查询：select count (*) from list group by ClassName
            var linqList7 = from x in list
                            group x by x.ClassName into y
                            select new
                            {
                                y.Key,
                                count = y.Count()
                            };
            //SQL取第一条数据：select top 1 * from list
            var linqList8=(from x in list
                          select x).FirstOrDefault();
            //SQL取前10条数据：select top 10 * from list
            var linqList9 = (from x in list
                             select x).Take(10);
            //取第16条~30条数据
            var linqList10 = (from x in list
                             select x)
                             .Skip(15).Take(30);
            return View();
        }
    }
    public class ExampleLambdaController:Controller
    {
        public ActionResult Index()
        {
            ExampleGenriceList genriceList = new ExampleGenriceList();
            var stuList = genriceList.GetAll();
            //模糊查询
            IEnumerable<StudentDemo> list1 = stuList.Where(x => x.ClassName.Contains("软件"));
            //精确查询
            IEnumerable<StudentDemo> list2 = stuList.Where(k => k.Name == "王五");
            //获取符合条件的单条数据
            StudentDemo stu1 = stuList.Where(k => k.Name == "王五").FirstOrDefault();

            
            return null;
        }
    }
}