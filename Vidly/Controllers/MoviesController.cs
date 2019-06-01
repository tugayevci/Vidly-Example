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

        private DatabaseContext _databaseContext;

        public MoviesController()
        {
            _databaseContext = new DatabaseContext();
        }

        public ActionResult New()
        {
            var genres = _databaseContext.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewMovieViewModel newMovieViewModel)
        {
            if (newMovieViewModel.Movie.Id==0)
            {
                _databaseContext.Movies.Add(newMovieViewModel.Movie);
            }
            else
            {
                var movieInDb = _databaseContext.Movies.Single(c => c.Id == newMovieViewModel.Movie.Id);
                movieInDb.Name = newMovieViewModel.Movie.Name;
                movieInDb.NumberInStock = newMovieViewModel.Movie.NumberInStock;
                movieInDb.ReleaseDate = newMovieViewModel.Movie.ReleaseDate;
                movieInDb.GenreId = newMovieViewModel.Movie.GenreId;

            }

            _databaseContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name="John Wick"};
            var customers = new List<Customer>
            {
                new Customer{Name="tugay"},
                new Customer{Name="gülçin"}
            };

            var viewModel = new RandomMovieViewModel() {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _databaseContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _databaseContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            //if (!pageIndex.HasValue)
            //    pageIndex = 1;

            //if (String.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";

            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            List<Movie> movies = _databaseContext.Movies.ToList();

            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4}):range(1900,2019)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _databaseContext.Movies.Where(x => x.Id == id).FirstOrDefault();

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

    }
}