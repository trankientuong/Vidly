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
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Shrek!"
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer{Id = 1, Name = "Tuong"},
                new Customer{Id = 2, Name = "Phong"},
                new Customer{Id = 3, Name = "Minh"},
                new Customer{Id = 4, Name = "Bao"}
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;
            //return viewResult;

            RandomMovieViewModel randomMovieView = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieView);




            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id )
        {
            return Content($"id= {id}");
        }


        // movies
        public ActionResult Index(/*int? pageIndex, string sortBy*/)
        {
            //pageIndex = pageIndex ?? 1;
            //if (string.IsNullOrWhiteSpace(sortBy))
            //{
            //    sortBy = "Name";
            //}
            //return Content($"pageIndex={pageIndex}-sortBy={sortBy}");

            var movies = new List<Movie>(){
                new Movie { Id = 1, Name = "Shrek"},
                new Movie { Id = 2, Name = "Wall-e"}
            };
            return View(movies);

        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content($"{year} / {month}");
        }      
    }
}