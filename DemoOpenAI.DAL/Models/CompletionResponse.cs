using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.DAL.Models
{
    public class CompletionResponse
    {
        public List<Choice> Choices { get; set; } = null!;

        public class Choice
        {
            public int Index { get; set; }
            public CompletionRequest.Message Message { get; set; } = null!;
        }
    }
}
