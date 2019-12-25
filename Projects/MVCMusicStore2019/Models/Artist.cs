using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    public class Artist: IEntity
    {
        public Guid Id { get; set; }//专辑编号 
        public string Name { get; set; }//歌手名称
        public string Description { get; set; }//简介
        public string Tags { get; set; }//标签
        public int ViewCount { get; set; }//播放量
        public int Collection { get; set; }//收藏量
        
        public Artist()
        {
            this.Id = Guid.NewGuid();
        }
        public Artist(Artist artist)
        {
            this.Id = artist.Id;
            this.Name = artist.Name;
            this.Description = artist.Description;
            this.Tags = artist.Tags;
            this.ViewCount = artist.ViewCount;
            this.Collection = artist.Collection;
        }
    }
}