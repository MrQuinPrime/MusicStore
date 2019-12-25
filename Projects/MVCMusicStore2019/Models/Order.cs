using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    /// <summary>
    /// 订单列表
    /// </summary>
    public class OrderItems
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }//专辑ID
        public int Quantity { get; set; }//数量
        public virtual Order Order { get; set; }//对应订单
        public OrderItems()
        {
            this.Id = Guid.NewGuid();
            this.Quantity = 0;
           
        }
        public OrderItems(OrderItems item)
        {
            this.Id = Guid.NewGuid();
            this.AlbumId = item.AlbumId;
            this.Quantity = 0;
            if(this.Order!=null)
            {
                this.Id = item.Order.Id;
                this.Order.UserName = item.Order.UserName;
                this.Order.OrderTime = item.Order.OrderTime;
            }
           
        }
    }
    /// <summary>
    /// 订单类
    /// </summary>
    public class Order
    {

        public Guid Id { get; set; }//订单编号
        public string UserName { get; set; }//待商榷
        public DateTime OrderTime { get; set; }//订单生成日期
        public virtual ICollection<OrderItems> OrderItems { get; set; }
     
        public Order()
        {

            this.Id = Guid.NewGuid();
            this.OrderTime = DateTime.Now;
        }
        public Order(Order order)
        {
            this.Id = order.Id;
            this.UserName = order.UserName;
            this.OrderTime = DateTime.Now;
        }
    }
}