using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Setting up database
        private FilmCollectionContext MovieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, FilmCollectionContext movies)
        {
            _logger = logger;
            MovieContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //Send users back to Add Movie page when they click on the button on the Confirmation page
        public IActionResult Confirmation()
        {
            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult AddMovie(Movies newm)
        {
            //Create row in dataset
            MovieContext.Add(newm);
            MovieContext.SaveChanges();

            return View("Confirmation");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
