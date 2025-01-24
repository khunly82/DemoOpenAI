using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.DAL.Models
{
    public class SpeechRequest : OpenAIRequest
    {
        public string Input { get; set; } = null!;
        public string Voice { get; set; } = null!;
    }
}
