using System.ComponentModel.DataAnnotations;

namespace DemoOpenAI.DTO
{
    public class ProductFormDTO
    {
        [MinLength(5)]
        public string Name { get; set; } = null!;
    }
}
