using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IDbContext _dbContext;

        public RegistrationController(IDbContext context)
        {
            _dbContext = context;
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
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return "Thanks for registration";
        }
    }
}