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
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name="Number In Stock")]
        [Range(1,20,ErrorMessage = "The field Number In Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
        [Required]
        [Display(Name= "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}