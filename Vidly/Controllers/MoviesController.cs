using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content($"Page index {pageIndex} is sort by {sortBy}");
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

    }
}