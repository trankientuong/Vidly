using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            //ViewBag.membershipTypes = membershipTypes;
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer{Id = 1, Name = "Tuong"},
                new Customer{Id = 2, Name = "Phong"},
                new Customer{Id = 3, Name = "Minh"},
                new Customer{Id = 4, Name = "Bao"}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult CreateAndUpdate(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                //Mapper.Map(customer, customerInDb);

                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
                _context.Entry(customerInDb).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        //    if (customer == null)
        //        return HttpNotFound();
        //    ViewBag.membershipTypes = _context.MembershipTypes.ToList();
        //    return View(customer);
        //}

        //[HttpPost]
        //public ActionResult Edit(Customer customer)
        //{
        //    var Editcustomer = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
        //    Editcustomer.Name = customer.Name;
        //    Editcustomer.Birthday = customer.Birthday;
        //    Editcustomer.MembershipTypeId = customer.MembershipTypeId;
        //    _context.Entry(Editcustomer).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    ViewBag.membershipTypes = _context.MembershipTypes.ToList();
        //    return RedirectToAction("Index", "Customers");
        //}

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c =>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}