using System;

namespace ChatBot {
    public class RandomAnswersStrategy : IChatStrategy {

        public string CreateResponse(string[] answers) {
            var random = new Random();
            return answers[random.Next(answers.Length - 1)];
        }
    }
}
