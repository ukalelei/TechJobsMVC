﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // renders the form defined in the Views/Search/Index.cshtml template
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.

        [HttpPost]
        [Route("/search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;

            List<Job> jobs; //store results in job list
            if (String.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";

            } else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;

            }

            ViewBag.jobs = jobs;

            return View();
        }
    }
}
