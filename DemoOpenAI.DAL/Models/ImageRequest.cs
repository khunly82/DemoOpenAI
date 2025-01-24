using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.DAL.Models
{
    public class ImageRequest : OpenAIRequest
    {
        public string Prompt { get; set; } = null!;
        public int N { get; set; }
        public string Size { get; set; } = null!;
        public string Response_format { get; set; } = null!;
    }
}
