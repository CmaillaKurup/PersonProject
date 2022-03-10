using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonProject.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IEnumerable<PersonModel> AddPerson(string firstName, string lastname)
        {
            return Enumerable.Range(1, 1).Select(index => new PersonModel(firstName, lastname)
            {
                Name = firstName,
                Lastname = lastname
            }).ToArray();
        }
        

        public void AddSession()
        {
            var myComplexObject = new PersonModel();
            HttpContext.Session.SetObjectAsJson("Test", myComplexObject);

            HttpContext.Session.GetObjectFromJson<PersonModel>("Test");

        }
    }
}
