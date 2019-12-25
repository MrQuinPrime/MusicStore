using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class GenreViewModel
    {
        [Display(Name = "编号")]
        public Guid Id { get; set; }//流派编号

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "流派名称是必填字段！")]
        [Display(Name = "流派名称")]
        public string Name { get; set; }//流派名称

        [Display(Name = "流派简介")]
        public string Description { get; set; }//流派简介
        public GenreViewModel() { }
        public GenreViewModel(Genre model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Genre model)
        {
            model.Id = this.Id;
            model.Name = this.Name;
            model.Description = this.Description;
        }
    }
}