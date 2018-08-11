using System;
using System.Collections.Generic;

namespace ChatBot {
    public class Bot
    {
        private string[] Answers { get; set; }
        public IChatStrategy AnswersStrategy { get; set; }

        public Bot(string[] answers, string strategyName) {
            Answers = answers;
            AnswersStrategy = GetChatStrategy(strategyName);
            if (AnswersStrategy == null) {
                AnswersStrategy = GetDefaultIStrategy();
            }
        }

        public void Start() {
            Talk(BotMessages.HelloMessage);
        }

        private string GetResponse() => AnswersStrategy.CreateResponse(Answers);

        public void ProcessComand(string message) {
            if (message.StartsWith(Commands.Strategy)) {
                ChangeStrategy(message);
                return;
            }

            Talk(GetResponse());
        }

        public void Talk(string message) {
            Console.WriteLine($"[бот] {message}");
        }

        public void ChangeStrategy(string command) {
            var startegyName = command.Replace(Commands.Strategy, string.Empty).Trim();
            var strategy = GetChatStrategy(startegyName);
            if (startegyName == null) {
                new ArgumentException($"Unknown strategy {startegyName}");
            }

            AnswersStrategy = strategy;
            Talk($"{GetResponse()} {BotMessages.ChangeStrategySuccess} : {startegyName}");
        }

        private IChatStrategy GetChatStrategy(string name) {
            return ChatStrategies[name];
        }

        private IChatStrategy GetDefaultIStrategy() => new RandomAnswersStrategy();

        readonly Dictionary<string, IChatStrategy> ChatStrategies = new Dictionary<string, IChatStrategy>() {
            { StrategyNames.Rand, new RandomAnswersStrategy() },
            { StrategyNames.Upseq, new UpseqAnswersStrategy() },
            { StrategyNames.Downseq, new DownseqAnswersStrategy() }
        };

        private class BotMessages {
            public const string HelloMessage = "Привет. Как дела на плюке?";
            public const string ChangeStrategySuccess = "Использую стратегию";
        }


        private class Commands {
            public const string Strategy = "strategy:";
            public const string Calculate = "calculate:";
        }

        private class StrategyNames {
            public const string Rand = "rand";
            public const string Upseq = "upseq";
            public const string Downseq = "downseq";
        }
    }
}
