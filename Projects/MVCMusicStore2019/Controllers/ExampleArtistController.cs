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
    public class ExampleArtistController : Controller
    {
        //定义接口给变量_Service
        private readonly IEntityRepository<Artist> _Service;
        // GET: ExampleArtist
       public ExampleArtistController(IEntityRepository<Artist> service)
        {
            this._Service = service;
        }
        
        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<ArtistDisplayViewModel>();
            var count = 0;
            foreach(var item in boCollection)
            {
                ArtistDisplayViewModel vm = new ArtistDisplayViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Tags = item.Tags,
                    ViewCount = item.ViewCount,
                    Collection = item.Collection
                };
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);
            }
            ViewBag.Title = "歌手";
            return View(vmCollention);
        }

        public ActionResult CreateOrEdit(string id = null)//string id=null,允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认：新增
            Guid Id;
            var vm = new ArtistViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new ArtistViewModel(entity);
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
        public ActionResult CreateOrEdit(ArtistViewModel model)
        {
            if (ModelState.IsValid)
            {
                Artist entity = new Artist
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Tags = model.Tags,
                    ViewCount = model.ViewCount,
                    Collection = model.Collection
                };
                if (model.Id != Guid.Empty)
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
            if (id != null)
            {
                if (_Service.Delete(id))
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