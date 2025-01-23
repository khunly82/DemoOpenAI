using DemoOpenAI.DAL.Models;
using DemoOpenAI.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.BLL.Services
{
    public class OpenAIBusinessService(IOpenAIService openAIService) : IOpenAIBusinessService
    {
        public async Task<CompletionResponse> GetCompletionAsync(string message, List<CompletionRequest.Message> previousMessage)
        {
            if (message.ToLower().Contains("khun"))
            {
                throw new Exception("Soyons serieux ...");
            }
            return await openAIService.GetCompletionAsync(new CompletionRequest
            {
                Model = "gpt-4o-mini",
                Messages = [..previousMessage, new CompletionRequest.Message {
                    Role = "user",
                    Content = message
                }]
            });
        }

    }
}
