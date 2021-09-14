using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsMVC.Models;

namespace TechJobsMVC.Controllers
{
    public class HomeController : Controller
    {
        //html in /Home/Index.cshtml
        public IActionResult Index() //display home page
        {
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");

            ViewBag.actions = actionChoices;
            return View();
        }
    }
}
