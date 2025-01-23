using DemoOpenAI.DAL.Models;

namespace DemoOpenAI.BLL.Services
{
    public interface IOpenAIBusinessService
    {
        Task<CompletionResponse> GetCompletionAsync(string message, List<CompletionRequest.Message> previousMessage);
    }
}