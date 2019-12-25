using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }   //购购物车中的条目
        public string Id { get; set; }  //购物车ID
        public string UserId { get; set; }  //当前登录用户Id
        public int TotalQuantity   //专辑总数量
        {
            get { return this.Items.Sum(x => x.Quantity); }
        }
        public decimal TotalPrice  //总金额
        {
            get { return this.Items.Sum(x => x.Price * x.Quantity); }
        }
        public ShoppingCart()
        {
            this.Id = "ShoppinCart_" + DateTime.Now.ToString("yyyy-mm-dd-mm-ss-ffff",DateTimeFormatInfo.InvariantInfo);
            Items = new List<ShoppingCartItem>();
        }
    }
    [Serializable]
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }   //价格
        public int Quantity { get; set; }  //数量
        public string AlbumName { get; set; }//音乐专辑名称
        public decimal SubTotalPrice  //当行物品计价
        {
            get { return this.Price * this.Quantity; }
        }

    }
}