using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.DAL.Models
{
    public class ImageResponse
    {
        public List<ListItem> Data { get; set; } = null!;
        public class ListItem
        {
            public byte[] B64_json { get; set; } = null!;
        }
    }
}
