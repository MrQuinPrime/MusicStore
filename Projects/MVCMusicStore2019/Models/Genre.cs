using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    /// <summary>
    /// 流派类
    /// </summary>
    public class Genre : IEntity
    {
        public Guid Id { get; set; }//流派编号

        public string Name { get; set; }//流派名称

        public string Description { get; set; }//简介

        public Genre()
        {
            this.Id = Guid.NewGuid();
        }
        public Genre(Genre bo)
        {
            this.Id = bo.Id;
            this.Name = bo.Name;
            this.Description = bo.Description;
        }
    }
}