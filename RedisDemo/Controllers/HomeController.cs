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
            int counter;

            try
            {
                var cache = new RedisCache();
                
                counter = cache.Get<int>("counter");
                counter++;
            
                cache.Put("counter", counter);
            }
            catch (Exception e)
            {
                return View(new CounterView
                {
                    HasError = true,
                    ErrorMessage = e.Message
                });
            }

            return View(new CounterView
            {
                Counter = counter
            });
        }
    }
}