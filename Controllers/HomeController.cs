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
            var tasks = Context.Tasks
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
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

                return RedirectToAction("Index");
            }
            else // if invalid
            {
                ViewBag.Categories = Context.Categories.ToList();

                return RedirectToAction("TaskForm", tk);
            }
        }

        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            ViewBag.Categories = Context.Categories.ToList();

            var task = Context.Tasks.Single(x => x.TaskId == TaskId);

            return RedirectToAction("TaskForm", task);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task t)
        {
            if (ModelState.IsValid)
            {
                Context.Update(t);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            else // if invalid
            {
                ViewBag.Categories = Context.Categories.ToList();

                return RedirectToAction("TaskForm", t);
            }

        }

        [HttpPost]
        public IActionResult Delete(Models.Task t)
        {
            Context.Tasks.Remove(t);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
