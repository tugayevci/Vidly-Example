﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "John Wick" };
            var customers = new List<Customer>
            {
                new Customer{Name="tugay"},
                new Customer{Name="gülçin"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);

        }
    }
}