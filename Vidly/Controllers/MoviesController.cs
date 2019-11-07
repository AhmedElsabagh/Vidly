using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.movies.Include(m => m.genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.movies.Include(m => m.genre).SingleOrDefault(m => m.id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieDataViewModel()
            {
                genres = _context.genres.ToList(),
            };

            return View("MovieData",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieDataViewModel(movie)
                {
                    genres = _context.genres.ToList()
                };

                return View("MovieData", viewModel);
            }
            //Movies movies = viewModel.movie;
            if (movie.id == 0)
            {
                movie.dateAdded = DateTime.Now;
                _context.movies.Add(movie);
            }
            else
            {
                Movies movieInDB = _context.movies.Single(m => m.id == movie.id);
                movieInDB.Name = movie.Name;
                movieInDB.releaseDate = movie.releaseDate;
                movieInDB.genreId = movie.genreId;
                movieInDB.numberInStock = movie.numberInStock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieDataViewModel(_context.movies.SingleOrDefault(m => m.id == id))
            {
                genres = _context.genres.ToList()
            };
            return View("MovieData", viewModel);
        }
    }
}