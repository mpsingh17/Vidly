using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using AutoMapper;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        // constructor
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
            var membershipTypes = _context.MembershipTypes.ToList();
            var vm = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            vm.Title = "Create Customer";
            return View("CustomerForm", vm);
        }

        // GET: Customers/Edit/id
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers
                                   .Include(m => m.MembershipType)
                                   .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var vm = Mapper.Map<Customer, CustomerFormViewModel>(customer);
            vm.MembershipTypes = _context.MembershipTypes.ToList();
            vm.Title = "Edit Customer";

            return View("CustomerForm", vm);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(CustomerFormViewModel customerVm)
        {
            if (!ModelState.IsValid)
            {
                var vm = new CustomerFormViewModel
                {
                    Title = "Create Customer",
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", vm);
            }

            if (customerVm.Id == 0)
            {
                var customer = Mapper.Map<CustomerFormViewModel, Customer>(customerVm);
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customerVm.Id);

                if (customerInDb == null)
                    return HttpNotFound();

                Mapper.Map(customerVm, customerInDb);

                //customerInDb.Name = customer.Name;
                //customerInDb.BirthDate = customer.BirthDate;
                //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}
