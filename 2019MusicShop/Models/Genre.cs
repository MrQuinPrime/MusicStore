using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2019MusicShop.Models
{
    public class Genre:IEntity
    {
        public Guid Id { get; set; }//流派编号

        public string AlbumName { get; set; }//流派名称

        public string Description { get; set; }//简介
    }
}