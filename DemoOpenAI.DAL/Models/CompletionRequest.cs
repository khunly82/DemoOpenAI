namespace DemoOpenAI.DAL.Models
{
    public class CompletionRequest : OpenAIRequest
    {
        public List<Message> Messages { get; set; } = null!;

        public class Message
        {
            public string Role { get; set; } = null!;
            public string Content { get; set; } = null!;
        }
    }
}
