namespace ChatBot {
    public class DownseqAnswersStrategy : IChatStrategy {
        private int Position { get; set; } = 0;

        public string CreateResponse(string[] answers) {
            if (Position == 0)
                Position = answers.Length - 1;

            return answers[Position++];
        }
    }
}
