using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class RegistrationController : Controller
    {
        MobileContext db;

        public RegistrationController(MobileContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return RedirectToAction("Registration");
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public string Registration(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return "Thanks for registration";
        }
    }


}