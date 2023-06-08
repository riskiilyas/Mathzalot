using Mathzalot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mathzalot.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        public IActionResult No1()
        {
            return View();
        }

        public IActionResult No2()
        {
            return View();
        }

        public IActionResult No3()
        {
            return View();
        }

        public IActionResult No4()
        {
            return View();
        }

        public IActionResult No5()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}