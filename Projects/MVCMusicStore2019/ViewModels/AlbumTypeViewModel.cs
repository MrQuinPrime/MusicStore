using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class AlbumTypeViewModel
    {
        [Display(Name = "编号")]
        public Guid Id { get; set; }//专辑编号 

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "类型名称是必填字段！")]
        [Display(Name = "类型名称")]
        public string Name { get; set; }//类型名称

        [Display(Name = "类型简介")]
        public string Description { get; set; }//类型简介

        public  AlbumTypeViewModel()
        {
            
        }
        public AlbumTypeViewModel(AlbumType model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(AlbumType model)
        {
            model.Id = this.Id;
            model.Name = this.Name;
            model.Description = this.Description;
        }
    }
}