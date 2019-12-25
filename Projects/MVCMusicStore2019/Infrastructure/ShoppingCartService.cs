using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Infrastructure
{
    public class ShoppingCartService:IShoppingCartService
    {
        public MusicDbContext _context { get; private set; }

        public ShoppingCartService(MusicDbContext context)
        {
            _context = context;
        }

        public string GetUserId()
        {
            var userName = HttpContext.Current.User.Identity.Name;  //取当前登录用户的用户名
            var userId = _context.Users.SingleOrDefault(x => x.UserName == userName).Id;//根据用户名获取用户ID
            return userId;
        }

        /// <summary>
        /// 获取购物车商品列表
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public List<ShoppingCartItem> GetItems(string cartId)
        {
            //获取当前用户购物车详单items
            var entityCollection = _context.ShoppingCart
                .Where(x => x.Id == cartId)
                .Select(y => y.Items)
                .ToList();

            //获取详单的id
            var entity = entityCollection.Select(x => x.Select(y => y.Id));

            var vmCollection = new List<ShoppingCartItem>();

            //把entityCollection读到vmCollection里面
            foreach(var items in entityCollection)
            {
                ShoppingCartItem bo = new ShoppingCartItem();
                foreach(var item in items)
                {
                    bo.Id = item.Id;
                    bo.Price = item.Price;
                    bo.Quantity = item.Quantity;
                    bo.AlbumName = item.AlbumName;                   
                }
                vmCollection.Add(bo);
            }
            return vmCollection;
        }
        /// <summary>
        /// 获取购物车（当前用户）
        /// </summary>
        /// <returns></returns>
        public ShoppingCart GetCart()
        {
        
            var userid = GetUserId();

            var cart = _context.ShoppingCart.SingleOrDefault(x => x.UserId == userid);
            if(cart!=null)
            {
                cart.Items = GetItems(cart.Id);
                return cart;
            }            
            return null;
            //var dbSet = _context.Set(typeof(ShoppingCart));
            //return (ShoppingCart)dbSet.Find(userid);
        }
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="id">音乐专辑ID</param>给ShoppingCartItem.Id
        /// <param name="price">价格</param>
        /// <param name="name">专辑名称</param>给ShoppingCartItem.AlbumName
        public void AddToCart(Guid id, decimal price, string name)
        {
            if(id!=Guid.Empty)
            {
                //查找购物车是否已有该音乐专辑数据
                ShoppingCartItem cartItem = _context.ShoppingCartItem.FirstOrDefault(x => x.Id == id);
                if(cartItem!=null)
                {
                    cartItem.Quantity++;

                }
                else
                {
                    ShoppingCartItem item = new ShoppingCartItem
                    {
                        Id = id,
                        AlbumName = name,
                        Price = price,
                    };
                    //查找当前用户购物车数据
                    var userId = GetUserId();
                    var cart = _context.ShoppingCart.SingleOrDefault(x => x.UserId == userId);

                    if(cart !=null)  //用户已有购物车数据，但是购物车没有当前专辑数据
                    {
                        cart.Items.Add(item);//思考：为什么要多此一举
                        _context.ShoppingCartItem.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        ShoppingCart shoppingCart = new ShoppingCart();
                        shoppingCart.UserId = userId;
                        shoppingCart.Items.Add(item);
                        _context.ShoppingCart.Add(shoppingCart);
                        _context.ShoppingCartItem.Add(item);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}