
namespace Mathzalot.Models
{
    public class QuestionViewModel
    {
        public string Question {get; set;}
        public KeyValuePair<float,bool>[] Answers {get; set;}

        public char Operation {get; set;}

    }
}