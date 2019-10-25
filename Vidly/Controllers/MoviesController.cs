using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies { id = 1, Name = "Sherk"},
                new Movies { id = 2, Name = "Lord of The rings"},
            };
        }
    }
}