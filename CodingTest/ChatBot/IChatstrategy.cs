namespace ChatBot {
    public interface IChatStrategy {
        string CreateResponse(string[] answers);
    }
}
