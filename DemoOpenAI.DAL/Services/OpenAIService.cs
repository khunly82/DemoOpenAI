using DemoOpenAI.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.DAL.Services
{
    public class OpenAIService(HttpClient httpClient) : IOpenAIService
    {
        public async Task<CompletionResponse> GetCompletionAsync(CompletionRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("chat/completions", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection à l'API impossible");
            }
            return await response.Content.ReadFromJsonAsync<CompletionResponse>() 
                ?? throw new Exception(); ;
        }

        public async Task<Stream> GetSpeech(SpeechRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("audio/speech", request);
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection à l'API impossible");
            }
            return await response.Content.ReadAsStreamAsync();
        }

        public async Task<ImageResponse> GetImageAsync(ImageRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("images/generations", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection à l'API impossible");
            }
            string content = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadFromJsonAsync<ImageResponse>()
                ?? throw new Exception();
        }

    }
}
