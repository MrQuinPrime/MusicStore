using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2019MusicShop.Models
{
    public class AlbumType:IEntity
    {
        public Guid Id { get; set; }
        public string AlbumName { get; set; }
        public string Description { get; set; }
       
    }
}