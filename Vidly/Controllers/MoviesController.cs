using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;
using AutoMapper;

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
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        //GET: movies/details/1
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                                .Include(m => m.Genre)
                                .SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            return HttpNotFound();
        }

        //GET: movies/create
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var vm = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList(),
            };

            return View("MoviesForm", vm);
        }

        //GET: movies/edit/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            
            var vm = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MoviesForm", vm);
        }

        //POST: movies/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(MovieFormViewModel movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                movieViewModel.Genres = _context.Genres.ToList();
                return View("MoviesForm", movieViewModel);
            }
            if (movieViewModel.Id == 0)
            {
                var movie = Mapper.Map<MovieFormViewModel, Movie>(movieViewModel);

                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.Stock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movieViewModel.Id);
                
                var movie = Mapper.Map(movieViewModel, movieInDb);
                movie.NumberAvailable = movie.Stock;
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