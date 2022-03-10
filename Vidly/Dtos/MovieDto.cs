﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "The field Number In Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }
        [Required]
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }

    }
}