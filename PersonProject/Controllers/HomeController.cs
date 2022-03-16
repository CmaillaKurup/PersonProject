using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace PersonProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Test", "This is My Session!");
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult AddPerson(string firstname, string lastname)
        {   
            List<PersonModel> person = new List<PersonModel>();
            person.Add(new PersonModel
            {
                Name = firstname,
                Lastname = lastname
            });
            ViewBag.Message = HttpContext.Session.GetString("Test");
            return View(person);
        }
    }
}