using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers //provides functionality for users to see either table or list of job info
{

    public class ListController : Controller
    {
        // provide a centralized collection of the different List and Search options presented throughout the user interface.
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"}, //this list needs work
            {"employer", "Employer"},
            {"location", "Location"},
            {"positionType", "Position Type"},
            {"coreCompetency", "Skill"}
        };

        //provide a centralized collection of the different List and Search options presented throughout the user interface.
        internal static Dictionary<string, List<JobField>> TableChoices = new Dictionary<string, List<JobField>>()
        {
            //implememts JobData class method
            {"employer", JobData.GetAllEmployers()},
            {"location", JobData.GetAllLocations()},
            {"positionType", JobData.GetAllPositionTypes()},
            {"coreCompetency", JobData.GetAllCoreCompetencies()}
        };

        public IActionResult Index() //renders a view that displays a table of clickable links for dif job categories
        {
            //implememts JobData class methods
            ViewBag.columns = ColumnChoices;
            ViewBag.tableChoices = TableChoices;
            ViewBag.employers = JobData.GetAllEmployers();
            ViewBag.locations = JobData.GetAllLocations();
            ViewBag.positionTypes = JobData.GetAllPositionTypes();
            ViewBag.skills = JobData.GetAllCoreCompetencies();

            return View();
        }

        // list jobs by column and value
        //renders a dif view that displays info for jobs that relate to a selected category
        //is called when a link in List view is clicked 
        public IActionResult Jobs(string column, string value) //query parameter
        {
            //implememts JobData class methods
            List<Job> jobs;
            if (column.ToLower().Equals("all")) //fetch all job data
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(column, value);
                ViewBag.title = "Jobs with " + ColumnChoices[column] + ": " + value;

            }
            ViewBag.jobs = jobs;

            return View();
        }

    }
}
