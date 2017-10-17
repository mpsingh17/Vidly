﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        // GET: Customers/Details/id
        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                                   .Include(c => c.MembershipType)
                                   .SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

        // GET: Customers/Create
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            ViewBag.Title = "Create";
            return View("CustomerForm", viewModel);
        }

        // GET: Customers/Edit/id
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            ViewBag.Title = "Edit";
            return View("CustomerForm", viewModel);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vm = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                ViewBag.Title = "Create";
                return View("CustomerForm", vm);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }       

    }
}
