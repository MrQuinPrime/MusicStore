using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    public class ShopCart
    {
        public string Article { get; set; }//商品名称
        public string Type { get; set; }//商品分类
        //public string AlbumName { get; set; }//音乐专辑名称
        public int Quantity { get; set; }//商品数量
        public float price { get; set; }//商品价格
    }
}