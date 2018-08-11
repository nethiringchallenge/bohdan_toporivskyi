namespace ChatBot {
    public class UpseqAnswersStrategy : IChatStrategy {
        private int Position { get; set; } = 0;

        public string CreateResponse(string[] answers) {
            if (Position >= answers.Length)
                Position = 0;

            return answers[Position++];
        }
    }
}
