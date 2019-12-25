using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Hello from Store.Index()";
        }
        //GET:Store/Browse
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }
        //GET:Store/Details
        public string Details()
        {
            return "Hello from Store.Details()";
        }
        // GET: Store/ShuiBian
        public string ShuiBian(Guid id)
        {
            id = Guid.NewGuid();
            string message = "当前登录用户的编码" + id;
            return message;
        }
    }
}