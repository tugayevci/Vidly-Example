using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private DatabaseContext _databaseContext;

        public CustomerController()
        {
            _databaseContext = new DatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _databaseContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "John Wick" };
            var customers = _databaseContext.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);

        }
    }
}