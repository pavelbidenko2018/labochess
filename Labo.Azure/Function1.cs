using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Labo.Azure.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Labo.Azure
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task RunAsync([TimerTrigger("0 0 0 * * 1")] TimerInfo myTimer)        {      
            
         
            using HttpClient httpClient = new HttpClient();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            IConfigurationRoot configuration = builder.Build(); 

            HttpResponseMessage message = httpClient.PostAsJsonAsync(configuration["apiURL"] + "/api/login", new { Username = "checkmate", Password = "1234" }).Result;

            if (message.IsSuccessStatusCode) {

                string responseContent = await message.Content.ReadAsStringAsync();

                // Deserialize JSON string into TokenDTO object
                TokenDTO tokenDto = JsonConvert.DeserializeObject<TokenDTO>(responseContent);
                // Log the token
                _logger.LogInformation(tokenDto.Token);

            }
          
        }
    }
}
