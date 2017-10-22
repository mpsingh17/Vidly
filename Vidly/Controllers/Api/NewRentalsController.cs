using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers
                                   .Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movie
                                 .Where(m => newRentalDto.MovieIds.Contains(m.Id));


            foreach (var movie in movies)
            {
                Rental rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
                movie.NumberAvailable -= 1;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
