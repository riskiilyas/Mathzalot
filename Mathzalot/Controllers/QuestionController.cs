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
            Game game = new Game(5);
            List<KeyValuePair<(int,Game.Operation,int), float>> questions = game.getQuestion();

            int num1 = questions[1].Key.Item1;
            Game.Operation operation = questions[1].Key.Item2;
            int num2 = questions[1].Key.Item3;
            char opChar = compareOperationSymbol(operation);

            ViewBag.Question = num1.ToString() + " " + opChar + " " + num2.ToString();
            ViewBag.Answer = questions[1].Value;
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

        private char compareOperationSymbol(Game.Operation operation)
        {
            char opChar;
            if(operation == Game.Operation.Addition) opChar = '+';
            else if(operation == Game.Operation.Subtraction) opChar = '-';
            else if(operation == Game.Operation.Multiplication) opChar = '*';
            else if(operation == Game.Operation.Division) opChar = '/';
            else {
                Console.WriteLine("Error - Operation symbol not found");
                return '?';
            }
            return opChar;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}