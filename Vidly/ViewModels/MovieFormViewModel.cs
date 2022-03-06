using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "The field Number In Stock must be between 1 and 20")]
        public int? NumberInStock { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "Create Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}