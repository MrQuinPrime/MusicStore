using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2019MusicShop.Models
{
    public class Album:IEntity//音乐专辑实体类
    {
        public Guid Id { get; set; }//专辑编号       
        public string AlbumName { get; set; }//专辑名称
        public string Description { get; set; }//简介
        public DateTime IssueDate { get; set; }//发行日期
        public string Issuer { get; set; }//发行人
        public string Language { get; set; }//语种
        public float Price { get; set; }//价格        
        
       
        public virtual Genre Genre { get; set; }

        public virtual AlbumType AlbumType { get; set; }
        public Album() { }
    }
}