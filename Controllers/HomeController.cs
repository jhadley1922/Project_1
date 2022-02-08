using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskForm()
        {
            return View();
        }
    }
}
