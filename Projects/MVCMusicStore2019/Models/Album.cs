using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    public class Album:IEntity//音乐专辑实体类
    {

        public Guid Id { get; set; }//专辑编号       
        public Guid GenreId { get; set; }//流派ID
        public Guid AlbumTypeId { get; set; }//类型ID
        public Guid ArtistId { get; set; }//歌手ID

        public string Name { get; set; }//专辑名称
        public string Description { get; set; }//简介
        public DateTime IssueDate { get; set; }//发行日期
        public string Issuer { get; set; }//发行人
        public string Language { get; set; }//语种
        public decimal Price { get; set; }//价格   

        public string UrlString { get; set; }//图片传入路径及文件名




        public virtual Artist Artist { get; set; }//歌手
        public virtual Genre Genre { get; set; }//流派

        public virtual AlbumType AlbumType { get; set; }//类型


        public Album()
        {
            Id = Guid.NewGuid();
            this.IssueDate = DateTime.Now;
            this.Price = 0.00M;
        }
        public Album(Album bo)
        {
            this.Id = bo.Id;
            this.Name = bo.Name;
            this.Description = bo.Description;
            this.IssueDate = bo.IssueDate;
            this.Issuer = bo.Issuer;
            this.Language = bo.Language;
            this.Price = bo.Price;
            this.UrlString = bo.UrlString;
            if(Genre!=null)
            {
                this.GenreId = bo.Genre.Id;
                this.Genre.Id = bo.Genre.Id;
                this.Genre.Name = bo.Genre.Name;
                this.Genre.Description = bo.Genre.Description;
            }
            if(AlbumType !=null)
            {
                this.AlbumTypeId = bo.AlbumType.Id;
                this.AlbumType.Id = bo.AlbumType.Id;
                this.AlbumType.Name = bo.AlbumType.Name;
                this.AlbumType.Description = bo.AlbumType.Description;
            }
            if(Artist!=null)
            {
                this.ArtistId = bo.Artist.Id;
                this.Artist.Id = bo.Artist.Id;
                this.Artist.Name = bo.Artist.Name;
                this.Artist.Description = bo.Artist.Description;
            }
        }
        public void MapToModel(AlbumViewModel model)
        {          
            this.Name = model.Name;
            this.Description = model.Description;
            this.IssueDate = model.IssueDate;
            this.Issuer = model.Issuer;
            this.Language = model.Language;
            this.Price = model.Price;
            this.UrlString = model.UrlString;

        }
    }
}