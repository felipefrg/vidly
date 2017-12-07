using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_2.Models;
using Vidly_2.ViewModel;

namespace Vidly_2.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _dbContext { get; set; }
        IList<GenreModel> _genre { get; set; }

        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
            _genre = _dbContext.GenreModel.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _dbContext.Movie.ToList();

            return View(movies);
        }

        public ActionResult New()
        {
            var movieViewModel = new MovieViewModel()
            {
                Movie = new MovieModel(),
                Genre = _genre
            };

            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int Id)
        {
            var movie = _dbContext.Movie.SingleOrDefault(m => m.Id == Id);

            if(movie == null)
            {
                return new HttpNotFoundResult();
            }

            var movieViewModel = new MovieViewModel()
            {
                Movie = movie,
                Genre = _genre
            };


            return View("MovieForm", movieViewModel);
        }

        public ActionResult MovieForm(MovieViewModel movie)
        {            
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieModel movie)
        {
            if(!ModelState.IsValid)
            {
                var movieViewModel = new MovieViewModel()
                {
                    Movie = movie,
                    Genre = _genre
                };

                return View("MovieForm",movieViewModel);
            }

            if (movie.Id <= 0)
            {
                _dbContext.Movie.Add(movie);
            }
            else
            {
                var dbMovie = _dbContext.Movie.Single(m => m.Id == movie.Id);
                dbMovie.Name = movie.Name;
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index","Movie");
        }
    }
}