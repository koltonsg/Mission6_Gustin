using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_KoltonGustin.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_KoltonGustin.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext context) // initialize the context
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel() // get to know joel page
        {
            return View();
        }
        
        public IActionResult MovieForm() // movie form page
        {
            ViewBag.Categories = _context.Categories.ToList(); // get the list of categories from the database
            return View();
        }

        [HttpPost] // code for post request (submitting the form)
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("confirmation", response); // take the user to the confirmation page
        }

        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();
            return View("MovieForm", recordToEdit);

        }

        [HttpPost]
        public IActionResult Edit(Movie UpdatedInfo)
        {
            _context.Update(UpdatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
