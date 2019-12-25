﻿using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class AlbumViewModel
    {
        [Display(Name ="唱片ID")]
        [ScaffoldColumn(true)]//设定表单编辑时允许隐藏的字段
        public Guid Id { get; set; }//专辑编号 

        [Display(Name ="序号")]
        public string OrderNumber { get; set; }
        
        [Required(ErrorMessage = "专辑名称是必填字段！")]
        [Display(Name = "专辑名称")]
        public string Name { get; set; }//专辑名称

        [Display(Name = "专辑简介")]
        public string Description { get; set; }//简介


        [Display(Name ="流派")]
        public string GenreName { get; set; }

        [Display(Name = "类型")]
        public string AlbumTypeName { get; set; }

        [Display(Name = "歌手")]
        public string ArtistName { get; set; }


        [Required(ErrorMessage = "发行日期是必填字段！")]
        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入发行日期")]
        public DateTime IssueDate { get; set; }//发行日期

        [Required(ErrorMessage = "发行人是必填字段！")]
        [Display(Name = "发行人")]
        public string Issuer { get; set; }//发行人

        [Required(ErrorMessage = "语种是必填字段！")]
        [Display(Name = "语种")]
        public string Language { get; set; }//语种

        [Display(Name = "价格")]
        [Range(typeof(decimal), "0.00", "10000.00", ErrorMessage = "合法数值为0.00~10000.00之间的数值")]
        public decimal Price { get; set; }//价格   

        [Display(Name = "封面链接")]
        public string UrlString { get; set; }

        [ScaffoldColumn(true)]//设定表单编辑时允许隐藏的字段
        public List<Genre> GenreItem { get; set; }

        [ScaffoldColumn(true)]//设定表单编辑时允许隐藏的字段
        public List<AlbumType> AlbumTypeItem { get; set; }

        [ScaffoldColumn(true)]//设定表单编辑时允许隐藏的字段
        public List<Artist> ArtistItem { get; set; }

        public Guid GenreId { get; set; }//流派ID

        public Guid AlbumTypeId { get; set; }//类型ID

        public Guid ArtistId { get; set; }//歌手ID

        [Display(Name="流派")]
        public virtual Genre Genre { get; set; }
        [Display(Name = "歌手")]
        public virtual Artist Artist { get; set; }
        [Display(Name = "类型")]
        public virtual AlbumType AlbumType { get; set; }


        public AlbumViewModel()
        {
            this.IssueDate = DateTime.Now;
            this.Price = 0.00M;
        }

        public AlbumViewModel(Album model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
            this.Price = model.Price;
            this.IssueDate = model.IssueDate;
            this.Issuer = model.Issuer;
            this.Language = model.Language;
            this.UrlString = model.UrlString;
            this.Artist = model.Artist;
            this.Genre = model.Genre;
            this.AlbumType = model.AlbumType;
            if (model.Genre!=null)
            {
                this.GenreId = model.Genre.Id;
                this.GenreName = model.Genre.Name;
            }
            if(model.AlbumType!=null)
            {
                this.AlbumTypeId = model.AlbumType.Id;
                this.AlbumTypeName = model.AlbumType.Name;
            }
            if(model.Artist!=null)
            {
                this.ArtistId = model.Artist.Id;
                this.ArtistName = model.Artist.Name;
            }

        }
        //public void MapToModel(Album model)
        //{
        //    model.Id = this.Id;
        //    model.Name = this.Name;
        //    model.Description = this.Description;            
        //    model.Price=this.Price;
        //    model.UrlString = this.UrlString;
        //    model.Issuer = this.Issuer;
        //    model.Language = this.Language;
        //    //model.Genre = this.Genre;
        //    //model.AlbumType = this.AlbumType;
        //    //model.Artist = this.Artist;
        //    if (model.Genre != null)
        //    {
        //        model.GenreId = this.GenreId;
        //        model.Name = this.GenreName;
        //    }
        //    if (model.AlbumType != null)
        //    {
        //        model.AlbumTypeId = this.AlbumTypeId;
        //        model.Name = this.AlbumTypeName;
        //    }
        //    if (model.Artist != null)
        //    {
        //        model.ArtistId= this.ArtistId;
        //        model.Name = this.ArtistName;
        //    }
        //}
    }
}