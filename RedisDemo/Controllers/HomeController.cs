#region

using System;
using System.Web.Mvc;
using RedisDemo.Infrastructure;

#endregion

namespace RedisDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            const string message = "Hello World";

            var cache = new RedisCache();

            cache.Put(nameof(message), message);

            var data = cache.Get<string>(nameof(message));

            if (data == null)
                throw new InvalidOperationException("Data is null");

            RedisCache.Clear();

            return View();
        }
    }
}