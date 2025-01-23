using System.ComponentModel.DataAnnotations;

namespace DemoOpenAI.DTO
{
    public class CompletionFormDTO
    {
        [MaxLength(255)]
        [MinLength(10)]
        public string NewMessage { get; set; } = null!;

        [MaxLength(100)]
        public List<MessageDTO> Messages { get; set; } = null!;

        public class MessageDTO
        {
            public string Role { get; set; } = null!;
            public string Content { get; set; } = null!;
        }
    }
}
