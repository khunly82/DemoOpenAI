using DemoOpenAI.DAL.Models;

namespace DemoOpenAI.DAL.Services
{
    public interface IOpenAIService
    {
        Task<CompletionResponse> GetCompletionAsync(CompletionRequest request);
        Task<Stream> GetSpeech(SpeechRequest request);
        Task<ImageResponse> GetImageAsync(ImageRequest request);
    }
}