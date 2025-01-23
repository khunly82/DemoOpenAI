using DemoOpenAI.BLL.Services;
using DemoOpenAI.DAL.Models;
using DemoOpenAI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DemoOpenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController(IOpenAIBusinessService openAiService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetCompletions([FromBody]CompletionFormDTO request)
        {
            try
            {
                return Ok(await openAiService.GetCompletionAsync(
                    request.NewMessage, 
                    request.Messages.Select(m => new CompletionRequest.Message { 
                        Role = m.Role, 
                        Content = m.Content
                    }).ToList())
                );
            }
            catch (Exception ex) 
            { 
                return Problem(ex.Message);
            }
        }
    }
}
