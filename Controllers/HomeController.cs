using ArdonaghSoftwareChallenge.Models;
using ArdonaghSoftwareChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArdonaghSoftwareChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerService _customerService;

        public HomeController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetCustomers();
            return View(customers);
        }

        public IActionResult Add()
        {
            return View(new CustomerModel());
        }

        public IActionResult Edit(int index)
        {
            return View("Add", _customerService.GetCustomer(index));
        }

        [HttpPost]
        public IActionResult AddEdit(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddEditCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}
