using ChatBot;
using System;
using System.IO;
using System.Text;
using System.Linq;

namespace ChatBotApp {
    class Program {
        static void Main(string[] args) {

            var strategy = GetStrategyParam(args);

            var answers = ReadFile(args);
            var bot = new Bot(answers, strategy);
            bot.Start();

            string message = "";
            do {
                Console.Write("[Я] ");
                message = Console.ReadLine();

                bot.ProcessComand(message);

            } while (message != "exit");

        }

        private static string[] ReadFile(string[] args) {
            var filePath = GetFilePath(args);
            return File.ReadAllLines(filePath, Encoding.UTF8).Select(x => x.Replace(">", string.Empty).Trim()).ToArray();
        }

        private static string GetFilePath(string[] args) {
            var filePath = @"C:\files\projects\codingtest\answers.txt";

            return filePath; // tmp
        }

        private static string GetStrategyParam(string[] args) {

            return "rand"; // tmp
        }
    }
}
