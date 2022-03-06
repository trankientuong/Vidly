using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/Movies 
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<MovieDto>));
        }

        //GET api/Movies/{id}
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<MovieDto>(movie));
        }

        //POST api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT api/Movies/{id}
        [HttpPut]
        public IHttpActionResult PutMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            Mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/Movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
