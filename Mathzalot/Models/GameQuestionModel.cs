using System;
using System.Collections.Generic;

namespace Mathzalot.Models
{
    public class Game
    {

        public enum Operation
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private Operation[] mathOperations = (Operation[])Enum.GetValues(typeof(Operation));
        private Random rng;

        private List<KeyValuePair<(int,Operation,int),float>> questionsAndAnswers;
        
        public Game(int maxQuestions)
        {
            rng = new Random((int)DateTime.Now.Ticks);
            questionsAndAnswers = new List<KeyValuePair<(int,Operation,int),float>>();

            for (int i = 0; i < maxQuestions; i++)
            {
                QuestionGenerator(100);
            }
        }

        public List<KeyValuePair<(int,Operation,int),float>> getQuestion()
        {
            return questionsAndAnswers;
        }

        private Operation OperationRandomizer()
        {
            int index = rng.Next(0, mathOperations.Length);

            Operation randOp = mathOperations[index];

            return randOp;
        }

        private void QuestionGenerator(int maxValue)
        {
            int num1 = rng.Next(0,maxValue);
            int num2 = rng.Next(0, maxValue);
            float answer = float.NaN;
            Operation operation = OperationRandomizer();

            if (operation == Operation.Addition)
            {
                answer = num1 + num2;
            }
            else if (operation == Operation.Subtraction)
            {
                answer = num1 - num2;
            }
            else if (operation == Operation.Multiplication)
            {
                answer = num1 * num2;
            }
            else if (operation == Operation.Division)
            {
                while(num2 == 0)
                {
                    num2 = rng.Next(0, maxValue);
                }
                answer = num1/(float)num2;
            }

            questionsAndAnswers.Add(new KeyValuePair<(int,Operation,int),float>((num1,operation,num2),answer));
        }
    }
}