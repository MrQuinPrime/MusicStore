using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }//编号       
        string Name { get; set; }//名称
        string Description { get; set; }//简介
    }
}
