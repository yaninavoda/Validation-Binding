using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data)
        {
            users = data.Users;
        }

        public IActionResult Index(string id)
        {
            return View("Index", users);
        }

        [HttpGet]
        public IActionResult Create([FromQuery] int? id,
                                    [FromQuery] string name,
                                    [FromQuery] string email,
                                    [FromQuery] string role)
        {
            var user = new User { Name = name, Email = email, Role = role };

            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            int lastId = users.Max(user => user.Id.Value);
            user.Id = lastId + 1;

            if (!ModelState.IsValid)
            {
                return View();
            }

            users.Add(user);

            return View("Details", user);
        }

        public IActionResult Details(User user)
        {
            return View(user);
        }
    }
}
