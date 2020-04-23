using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbContext _dbContext;

        public HomeController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var phone = _dbContext.Phones.SingleOrDefault(x => x.Id.Equals(id));
            if (phone != null && phone.ReleaseYear < 1990)
            {
                return RedirectToAction("ExpiredOrder");
            }

            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return "Thanks";
        }

        [HttpGet]
        public string PrivacyPolicy()
        {
            return "Very important privacy policy!";
        }

        [HttpGet]
        public IActionResult ExpiredOrder()
        {
            return View();
        }
    }
}