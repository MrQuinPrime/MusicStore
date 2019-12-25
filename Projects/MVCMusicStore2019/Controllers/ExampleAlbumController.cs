using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ExampleAlbumController : Controller
    {
        //定义接口给变量_Service
        private readonly IEntityRepository<Album> _Service;
        // GET: ExampleArtist
        public ExampleAlbumController(IEntityRepository<Album> service)
        {
            this._Service = service;
        }


        public ActionResult Index()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<AlbumDisplayViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                AlbumDisplayViewModel vm = new AlbumDisplayViewModel(item);
                //vm.MapToModel(item);                    
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);
            }
            ViewBag.Title = "音乐专辑";
            return View(vmCollention);
        }
        /// <summary>
        /// 音乐专辑购物车主页实现
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopIndex()
        {
            var boCollection = _Service.GetAll().OrderBy(x => x.Name);
            var vmCollention = new List<AlbumDisplayViewModel>();
            var count = 0;
            foreach (var item in boCollection)
            {
                AlbumDisplayViewModel vm = new AlbumDisplayViewModel(item);
                //vm.MapToModel(item);                    
                vm.OrderNumber = (++count).ToString();
                vmCollention.Add(vm);
            }
            ViewBag.Title = "音乐专辑购物车";
            return View(vmCollention);
        }

        /// <summary>
        /// 流派（Genre）下拉菜单内容数据集
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGenreList()
        {
            var entityList = _Service.GetRelevance<Genre>().ToList();//流派数据集
            var vmList = new List<GenreViewModel>();//音乐专辑的VM
            foreach(var item in entityList)
            {
                var boVM = new GenreViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }
        /// <summary>
        /// 歌手（Artist）下拉菜单内容数据集
        /// </summary>
        /// <returns></returns>
        public JsonResult GetArtistList()
        {
            var entityList = _Service.GetRelevance<Artist>().ToList();//歌手数据集
            var vmList = new List<ArtistViewModel>();//歌手的VM
            foreach (var item in entityList)
            {
                var boVM = new ArtistViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }
        /// <summary>
        /// 类型（AlbumType）下拉菜单内容数据集
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAlbumTypeList()
        {
            var entityList = _Service.GetRelevance<AlbumType>().ToList();//类型数据集
            var vmList = new List<AlbumTypeViewModel>();//类型的VM
            foreach (var item in entityList)
            {
                var boVM = new AlbumTypeViewModel(item);
                vmList.Add(boVM);
            }
            return Json(vmList);
        }
        /// <summary>
        /// 添加和修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateOrEdit(string id = null)//string id=null,允许形参id不传值
        {
            bool isNew = false;//判断当前操作是新增，还是修改；默认：新增
            Guid Id;
            var vm = new AlbumViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                isNew = true;
                Id = Guid.Parse(id);
                var entity = _Service.GetSingleById(Id);
                vm = new AlbumViewModel(entity);
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
        public ActionResult CreateOrEdit(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                Album entity = new Album
                {
                    Id=model.Id,
                    Name=model.Name,
                    Description=model.Description,
                    Issuer=model.Issuer,
                    IssueDate=model.IssueDate,
                    UrlString=model.UrlString,
                    Price=model.Price,
                    Language=model.Language,

                    Genre=model.Genre,
                    Artist=model.Artist,
                    AlbumType=model.AlbumType,

                    GenreId=model.GenreId,
                    ArtistId=model.ArtistId,
                    AlbumTypeId=model.AlbumTypeId
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
        /// <summary>
        /// 图片上传功能实现
        /// </summary>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public JsonResult UploadImgFile(HttpPostedFileBase imgFile)
        {
            if(imgFile.ContentLength==0)
            {
                return Json(new
                {
                    upStatus=false,
                    upMessage="请选择上传图片"
                },
                "text/html");
            }
            //生成图片文件名
            var timeStampString = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-ffff",DateTimeFormatInfo.InvariantInfo);
            var result = "Album" + timeStampString;

            int startIndex = imgFile.FileName.IndexOf(".");
            var suffix = imgFile.FileName.Substring(startIndex, imgFile.FileName.Length - startIndex);//获取文件后缀名
            var fileName = Path.Combine(Request.MapPath("/Pics"), Path.GetFileName(result + suffix));

            try
            {
                imgFile.SaveAs(fileName);
                return Json(new
                {
                    imgUrlString = result + suffix,
                    upStatus = true,
                    upMessage = "图片上传成功"
                });
            }
            catch(Exception e)
            {
                return Json(new
                {
                    upStatus = false,
                    upMessage = "图片上传失败！"
                }, "json/html");
            }
        }

       
    }
}