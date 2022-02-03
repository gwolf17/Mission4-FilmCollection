using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Setting up database
        private FilmCollectionContext MovieContext { get; set; }

        public HomeController(FilmCollectionContext movies)
        {
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

        //Add movie view
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Category = MovieContext.category.ToList(); //Create a list of categories to send to the Add Movies page
            return View();
        }

        //Send users back to Add Movie page when they click on the button on the Confirmation page
        public IActionResult Confirmation()
        {
            return View("AddMovie");
        }

        //Add Movie view
        [HttpPost]
        public IActionResult AddMovie(Movies newm)
        {
            if (ModelState.IsValid)  //If the model is valid, add the new record
            {
                //Create row in dataset
                MovieContext.Add(newm);
                MovieContext.SaveChanges();

                return View("Confirmation");
            }
            else  //Otherwise, send the user back to the AddMovie view
            {
                ViewBag.Category = MovieContext.category.ToList();
                return View();
            }

        }

        //List movies view
        [HttpGet]
        public IActionResult ListMovies()
        {
            var MovieList = MovieContext.responses
                .Include(x => x.category)
                .OrderBy(x => x.category)
                .ToList();
            return View(MovieList);
        }

        //Edit View
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Category = MovieContext.category.ToList();  //Resend the category list

            var movie = MovieContext.responses.Single(x => x.movieId == movieid);  //Find the correct record

            return View("AddMovie", movie);  //Send the user to the AddMovie view with the data in the movie variable
        }

        [HttpPost]
        public IActionResult Edit(Movies m)
        {
            MovieContext.Update(m);  //Update the record and save the changes
            MovieContext.SaveChanges();

            return RedirectToAction("ListMovies");  //Send back to the ListMovies view
        }

        //Delete View
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = MovieContext.responses.Single(x => x.movieId == movieid);  //Create variable to hold movie info
            return View(movie);  //Pass info to the view
        }

        public IActionResult Delete(Movies m)
        {
            MovieContext.responses.Remove(m);
            MovieContext.SaveChanges();
            return Redirect("ListMovies");
        }
    }
}
