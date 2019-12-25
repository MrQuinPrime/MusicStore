using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCartViewModel
    {

        [Display(Name = "购物车条目")]
        public List<ShoppingCartItem> Items { get; set; }   //购购物车中的条目

        [Display(Name = "购物车ID")]
        public string Id { get; set; }  //购物车ID

        [Display(Name = "当前登录用户Id")]
        public string UserId { get; set; }  //当前登录用户Id

        [Display(Name = "专辑总数量 ")]
        public int TotalQuantity { get; }   //专辑总数量  
           
        [Display(Name = "总金额")]
        public decimal TotalPrice { get; } //总金额
           
        public ShoppingCartViewModel(ShoppingCart model)
            {
                if(Items!=null)
                {
                this.Items = model.Items;
                }
               this.Id = model.Id;
               this.UserId = model.UserId;
               this.TotalQuantity = model.TotalQuantity;
               this.TotalPrice = model.TotalPrice;
            }

       
    }
   
}