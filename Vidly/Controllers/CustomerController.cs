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

        public ActionResult New()
        {
            var memberShipTypes = _databaseContext.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = memberShipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModelTemp = new CustomerFormViewModel
                {
                    MembershipTypes = _databaseContext.MembershipTypes.ToList(),
                    Customer = viewModel.Customer
                };

                return View("CustomerForm", viewModelTemp);
            }

            if (viewModel.Customer.Id==0)
            {
                _databaseContext.Customers.Add(viewModel.Customer);
            }
            else
            {
                var customerInDb = _databaseContext.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.Birthdate = viewModel.Customer.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = viewModel.Customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            }

            _databaseContext.SaveChanges();
            return RedirectToAction("Index","Customer");
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

        public ActionResult Edit(int id)
        {
            Customer customer = _databaseContext.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _databaseContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}