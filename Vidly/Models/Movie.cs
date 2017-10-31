using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1,20)]
        public int Stock { get; set; }

        [Range(0, 20)]
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}