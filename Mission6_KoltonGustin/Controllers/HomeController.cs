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
    }
}
