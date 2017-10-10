using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Don" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Cust 1" },
                new Customer { Name = "Cust 2" }
            };

            var vm = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(vm);
        }

        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        //GET: movies/index
        public ActionResult Index()
        {
            var movies = _context.Movie
                                 .Include(m => m.Genre)
                                 .ToList();
            return View(movies);
        }

        //GET: movies/details/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movie
                                .Include(m => m.Genre)
                                .SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            return HttpNotFound();
        }
    }
}