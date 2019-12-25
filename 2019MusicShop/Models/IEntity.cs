using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019MusicShop.Models
{
    public interface IEntity
    {
         Guid Id { get; set; }//编号       
         string AlbumName { get; set; }//名称
         string Description { get; set; }//简介
         

    }
}
