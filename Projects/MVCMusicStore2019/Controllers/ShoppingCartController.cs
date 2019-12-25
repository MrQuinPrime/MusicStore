using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IEntityRepository<Album> _Service;
        // GET: ShoppingCart
        public ShoppingCartController(ShoppingCartService cartService,
           IEntityRepository<Album> service )
        {
            this._Service = service;
            this._cartService = cartService;
        }

        public ActionResult AddToCart(Guid id,decimal price,string name)
        {
            //获取购物车
            var cart = _cartService.GetCart();
            var album = _Service.GetAll().Single(x => x.Id == id);//获取专辑信息
            if(album!=null)
            {
                _cartService.AddToCart(album.Id, price, album.Name);
            }
            else
            {
                ViewBag.Msg = "查无此专辑，请不要非法操作！";
            }           
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var cart = _cartService.GetCart();//获取购物车
            ShoppingCartViewModel vm = new ShoppingCartViewModel(cart)
            {
                Items = cart.Items
            };
            return View(vm);
            
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}