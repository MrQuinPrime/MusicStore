using MVCMusicStore2019.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    public class AlbumType:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AlbumType()
        {
            this.Id = Guid.NewGuid();
        }
        public AlbumType(AlbumType albumtype)
        {
            this.Id = albumtype.Id;
            this.Name = albumtype.Name;
            this.Description = albumtype.Description;
        }
    }
}