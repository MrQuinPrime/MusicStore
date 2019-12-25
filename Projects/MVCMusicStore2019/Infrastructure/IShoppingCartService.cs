using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Infrastructure
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCart();//获取当前用户的购物车
        void AddToCart(Guid id, decimal price,string name);
    }
}
