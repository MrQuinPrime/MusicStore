using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class ArtistDisplayViewModel
    {
        [Display(Name = "歌手ID")]
        public Guid Id { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "歌手名称是必填字段！")]
        [Display(Name = "歌手名称")]
        public string Name { get; set; }//歌手名称

        [Required(ErrorMessage = "歌手简介是必填字段！")]
        [Display(Name = "歌手简介")]
        public string Description { get; set; }//简介


        [Required(ErrorMessage = "标签是必填字段！")]
        [Display(Name = "标签")]
        public string Tags { get; set; }//标签

        [Display(Name = "播放量")]
        [Range(typeof(int), "0", "10000", ErrorMessage = "合法数值为0~10000之间的数值")]
        public int ViewCount { get; set; }//播放量

        [Display(Name = "收藏量")]
        [Range(typeof(int), "0", "10000", ErrorMessage = "合法数值为0~10000之间的数值")]
        public int Collection { get; set; }//收藏量
    }
}