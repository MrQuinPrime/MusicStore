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
    public class MusicIndexController : Controller
    {
        //定义接口给变量_Service
        private readonly IEntityRepository<Album> _Service;
        private readonly IEntityRepository<PopularHotList> _phlService;

        public MusicIndexController(IEntityRepository<Album> service, 
            IEntityRepository<PopularHotList> phlservice)
        {
            this._Service = service;
            this._phlService = phlservice;
        }

        /// <summary>
        /// 取最后5条新增的Album图片数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPics()
        {
            var entityList = _Service.GetAll();//获取Album所有的数据
            var picList = entityList
                .OrderByDescending(x => x.IssueDate)//按出品日期倒序排序
                .Select(y => y.UrlString)//选择UrlString一列数据
                .Skip(0)//从结果的第0条
                .Take(5)//取5条数据
                .ToList();
            return Json(picList);
        }
        /// <summary>
        /// 获取Album表中的Id、Name、Price、URLString
        /// 根据发行日期倒序排序
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMusicAlbums()
        {
            var entityList = _Service.GetAll().ToList();
            var jsonResult = entityList
                .OrderByDescending(x => x.IssueDate)//使用集合索引器方式选择目标列
                .Select(result => new//使用集合索引器方式选择目标列
                {
                    result.Id,
                    result.Name,
                    result.Price,
                    result.UrlString
                })
               .Skip(0).Take(10) //取第0~10条数据
               .ToList();
            return Json(jsonResult);
        }

        /// <summary>
        /// 获取音乐专辑详情
        /// </summary>
        public ActionResult Detail(Guid id)
        {
            var entity = _Service.GetAll().Single(x=>x.Id==id);//根据传入形参查询album详细数据
            AlbumDisplayViewModel vm = new AlbumDisplayViewModel(entity);
            return View(vm);

        }
        /// <summary>
        /// 点赞实现
        /// </summary>

        public JsonResult AddCTR(Guid id)
        {
            var result = false;
            var entity = _phlService.GetSingleById(id);
            if(entity!=null)
            {
                entity.CTR += 1;
                _phlService.Edit(entity);
                result = true;
            }
            else
            {
                PopularHotList bo = new PopularHotList();
                bo.Id = id;
                bo.Album = _phlService.GetSingleRelevance<Album>(id);
                bo.AlbumId = id;
                bo.CTR += 1;
                _phlService.AddAndSave(bo);
                result = true;
            }
            return Json(result);
        }
    }
}