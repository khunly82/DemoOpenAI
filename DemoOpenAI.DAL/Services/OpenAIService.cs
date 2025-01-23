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
            return JsonConvert.DeserializeObject<CompletionResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new Exception("Déserialisation impossible");
        }
    }
}
