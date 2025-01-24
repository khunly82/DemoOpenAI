using DemoOpenAI.DAL.Models;
using DemoOpenAI.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DemoOpenAI.BLL.Services
{
    public class ProductService(IOpenAIService openAIService, HttpClient httpClient) : IProductService
    {

        public async Task Add(string name)
        {
            // recupérer une description
            string description = (await openAIService.GetCompletionAsync(new CompletionRequest
            {
                Model = "gpt-4o",
                Messages = [new CompletionRequest.Message {
                    Role = "user",
                    Content = "Donne moi une description pour " + name
                }]
            })).Choices.First().Message.Content;

            // récupérer un fichier audio
            using Stream stream = await openAIService.GetSpeech(new SpeechRequest
            {
                Model = "tts-1",
                Voice = "nova",
                Input = description,
            });
            // créer un fichier vierge
            string fileName = Guid.NewGuid().ToString() + ".mp3";
            using Stream newFile = File.Create("wwwroot/Audio/" + fileName);
            // remplir le ficher avec le flux audio
            await stream.CopyToAsync(newFile);

            // récupérer une image

            ImageResponse data = await openAIService.GetImageAsync(new ImageRequest
            {
                Model = "dall-e-3",
                Prompt = description,
                N = 1,
                Size = "1024x1024",
                Response_format = "b64_json",

            });
            string imageFileName = Guid.NewGuid().ToString() + ".png";

            await File.WriteAllBytesAsync("wwwroot/Images/" + imageFileName, data.Data.First().B64_json);
                

            // sauver tout.
        }
    }
}
