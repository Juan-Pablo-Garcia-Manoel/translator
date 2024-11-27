using Azure.AI.OpenAI;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using translator;
using Translator.InfoConnection;
using OpenAI.Chat;
using static System.Environment;
using System.Net.Http;

namespace Translator
{
    internal class ConnectionTranslatorAPI
    {
        public async Task connectionAPI(Message message)
        {
            InfoConnectionTranslate infoConnectionTranslate = new InfoConnectionTranslate();

            string route = $"/translate?api-version=3.0&from={message.getLanguageFrom()}&to={message.getLanguageTo()}";
            string textToTranslate = message.getText();

            object[] body = new object[] { new { Text = textToTranslate } };

            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
        
            using (var request = new HttpRequestMessage())
        
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(infoConnectionTranslate.getEndpoint() + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8 ,"application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", infoConnectionTranslate.getKey());
                request.Headers.Add("Ocp-Apim-Subscription-Region", infoConnectionTranslate.getLocation());
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                setResult(result);
            }
        }
        
        public async Task connectionAzureChatOpenAI(Message message)
        {
            InfoConnectionAzureChatOpenAI infoConnectionAzureChatOpenAI = new InfoConnectionAzureChatOpenAI();

            AzureOpenAIClient azureClient = new(
               new Uri(infoConnectionAzureChatOpenAI.getEndpoint()),
               new AzureKeyCredential(infoConnectionAzureChatOpenAI.getKey()));

            ChatClient chatClient = azureClient.GetChatClient(infoConnectionAzureChatOpenAI.getDeploymentName());

            var chatUpdates = chatClient.CompleteChatStreamingAsync(
            [
                new SystemChatMessage(message.getSystemText()),
                new UserChatMessage(message.getSystemTextUser()),
            ]);

            await foreach (var chatUpdate in chatUpdates)
            {
                if (chatUpdate.Role.HasValue)
                {
                    Console.Write($"{chatUpdate.Role} : ");
                }

                foreach (var contentPart in chatUpdate.ContentUpdate)
                {
                    Console.Write(contentPart.Text);
                }
            }
        }

        private string result;
        public string getResult()
        {
            return result;
        }
        public void setResult(string result)
        {
            this.result = result;
        }
    
    }
}
