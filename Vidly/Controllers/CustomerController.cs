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
            var customers = _databaseContext.Customers.Include(c => c.MembershipType).ToList();          

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _databaseContext.Customers.Include(c => c.MembershipType).Where(x => x.Id == id).FirstOrDefault();

            if (customer==null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}