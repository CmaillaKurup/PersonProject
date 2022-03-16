using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonProject.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult AddPerson(string firstname, string lastname)
        {
            var temp = Enumerable.Range(1, 1).Select(index => new PersonModel(firstname, lastname)
            {
                Name = firstname,
                Lastname = lastname
            }).ToArray();

            //HttpContext.Session.SetObjectAsJson("Test", temp);
            //HttpContext.Session.GetObjectFromJson<PersonModel>("Test");   
            
            return Index();
        }
    }
}
