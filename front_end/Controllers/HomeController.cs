using front_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace front_end.Controllers
{
    public class HomeController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }

    }
}