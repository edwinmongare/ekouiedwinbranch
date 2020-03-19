using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ekobiashara.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Password()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AddBusiness()
        {
            return View();
        }
    }
}