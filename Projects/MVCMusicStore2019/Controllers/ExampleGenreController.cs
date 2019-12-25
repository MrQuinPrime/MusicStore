using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ExampleGenreController : Controller
    {
        //定义接口给变量_Service
        private readonly IEntityRepository<Genre> _Service;
        // GET: ExampleArtist
        public ExampleGenreController(IEntityRepository<Genre> service)
        {
            this._Service = service;
        }


        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<GenreDisplayViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                GenreDisplayViewModel vm = new GenreDisplayViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                };
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);
            }
            ViewBag.Title = "流派类型";
            return View(vmCollention);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(GenreViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        Genre entity = new Genre
        //        {
        //            AlbumName = model.AlbumName,
        //            Description = model.Description
        //        };
        //        _Service.AddAndSave(entity);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.Error = "新增失败";
        //        return RedirectToAction("Index");
        //    }
           
        //}

        //public ActionResult Edit(Guid id)
        //{
        //    var vm = new GenreViewModel();
        //    if(id!=null)
        //    {
        //        var entity = _Service.GetSingleById(id);
        //        vm = new GenreViewModel(entity);
        //        ViewBag.Message = "修改成功";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "找不到修改数据";
        //        return RedirectToAction("Index");
        //    }
        //    return View(vm);
        //}
        //[HttpPost]
        //public ActionResult Edit(GenreViewModel model)
        //{
        //    Genre entity = new Genre
        //    {
        //        Id = model.Id,
        //        AlbumName = model.AlbumName,
        //        Description = model.Description
        //    };
        //    _Service.Edit(entity);
        //    return RedirectToAction("Index");
        //}
        public ActionResult CreateOrEdit(string id=null)//string id=null,允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认：新增
            Guid Id;
            var vm = new GenreViewModel();
            if(!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new GenreViewModel(entity);
                ViewBag.Operation = "修改";//修改
            }
            else
            {
                ViewBag.Operation = "新建";//新建
            }
            
            ViewBag.isNew = isNew;
            return View(vm);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]//防伪造脚本攻击，CSRF
        public ActionResult CreateOrEdit(GenreViewModel model)
        {
            if(ModelState.IsValid)
            {
                Genre entity = new Genre
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description

                };
                if(model.Id!=Guid.Empty)
                {

                    _Service.Edit(entity);
                    ViewBag.Message = "修改成功";
                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    _Service.AddAndSave(entity);
                    ViewBag.Message = "新增成功";
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(Guid id)
        {
            if(id!=null)
            {
                if(_Service.Delete(id))
                {
                    ViewBag.Message = "删除成功";

                }
                else
                {
                    ViewBag.Message = "删除失败";

                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "请选择需要删除的记录";
            }            
            return View();
        }
    }
}