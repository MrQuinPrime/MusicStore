using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class GenreDisplayViewModel
    {
        [Display(Name = "流派编号")]
        public Guid Id { get; set; }//流派编号

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "流派名称是必填字段！")]
        [Display(Name = "流派名称")]
        public string Name { get; set; }//流派名称

        [Display(Name = "流派简介")]
        public string Description { get; set; }//简介
    }
}