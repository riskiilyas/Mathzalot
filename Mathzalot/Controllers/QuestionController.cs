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

        public IActionResult Index(string session = "0", int prevScore = 0)
        {
            QuestionViewModel viewModel = makeViewModel();
            if(session == "0")
            {
                string key = GenerateGameSessionKey();
                HttpContext.Session.SetString("GameSessionKey",key);
                HttpContext.Session.SetInt32(key, 0);
                viewModel.score = 0;

            }
            else
            {
                HttpContext.Session.SetInt32(session, prevScore);
                viewModel.score = prevScore;
            }
            


            return View(viewModel);
        }

        private QuestionViewModel makeViewModel(){
            Game game = new Game(1);
            List<KeyValuePair<(int,Game.Operation,int), float>> questions = game.getQuestion();

            int num1 = questions[0].Key.Item1;
            Game.Operation operation = questions[0].Key.Item2;
            int num2 = questions[0].Key.Item3;
            char opChar = compareOperationSymbol(operation);
            float answer = questions[0].Value;

            QuestionViewModel viewModel = new QuestionViewModel
            {
                Question = num1.ToString() + " " + opChar + " " + num2.ToString(),
                Answers = makeRandomAnswers(answer, opChar),
                Operation = opChar
            };
            return viewModel;
        }

        private KeyValuePair<float,bool>[] makeRandomAnswers(float correct, char opChar) {
            KeyValuePair<float,bool>[] answers = new KeyValuePair<float,bool>[4];
            Random rng = new Random((int)DateTime.Now.Ticks);
            answers[0] = new KeyValuePair<float,bool>(correct,true);

            for(var i = 1; i < 4; i++)
            {
                int wrong = rng.Next(-30,30);
                while(wrong == 0)
                {
                    wrong = rng.Next(-30,30);
                }
                float twoDec = 0;
                if(opChar == '/')
                    twoDec = rng.Next(-1, 1);

                answers[i] = new KeyValuePair<float,bool>(correct + wrong + twoDec,false);
            }

            answers = answers.OrderBy(x => rng.Next()).ToArray();

            return answers;
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

        [HttpGet]
        public ActionResult checkAnswer(bool answer)
        {
            if(answer == true){
                //put into database as correct, calculate winnings
                string key = HttpContext.Session.GetString("GameSessionKey");
                int score = (int)(100 + HttpContext.Session.GetInt32(key));
                return RedirectToAction("Index","Question", new{session = key, prevScore = score});
            }
            else{
                //save points, return to home
                return RedirectToAction("Index","Dashboard");

            }
            
        }

        public string GenerateGameSessionKey() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rng = new Random((int)DateTime.Now.Ticks);

            string key = new string(Enumerable.Repeat(chars, 10).Select(s => s[rng.Next(s.Length)]).ToArray());
            Console.WriteLine(key);
            return key;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}