using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
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

        //GET: movies/create
        public ActionResult Create()
        {
            var vm = new MovieFormViewModel
            {
                Genres = _context.Genre.ToList()
            };

            ViewBag.Title = "Create";
            return View("MoviesForm", vm);
        }

        //GET: movies/edit/1
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            
            var vm = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genre.ToList()
            };

            ViewBag.Title = "Edit";
            return View("MoviesForm", vm);
        }

        //POST: movies/save
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreId = movie.GenreId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index");
        }
    }
}