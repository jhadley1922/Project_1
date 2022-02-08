using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private TaskContext Context { get; set; }

        public HomeController(TaskContext tc)
        {
            Context = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = Context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(Models.Task tk)
        {
            if (ModelState.IsValid)
            {
                Context.Add(tk);
                Context.SaveChanges();

                return View();
            }
            else // if invalid
            {
                ViewBag.Categories = Context.Categories.ToList();

                return View();
            }
        }
    }
}
