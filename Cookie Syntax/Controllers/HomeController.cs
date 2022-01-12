using Cookie_Syntax.DAL;
using Cookie_Syntax.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookie_Syntax.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SetCookie("Man","Woman");
            return View();
            var user = new User(){UserId=1,UserName="Cimi"};
            HttpContext.Session.SetString("SessionUser",JsonConvert.SerializeObject(user));
        }
        public IActionResult Object(int id) {

            ViewBag.Cookie = GetCookie("Man");
            return View();
        }
        public void SetCookie(string key,string value) {

            HttpContext.Response.Cookies.Append(key,value);
        }
        public string GetCookie(string key) {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }
    }
}
