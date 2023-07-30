using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CodeAugmentor.Models;

namespace CodeAugmentor.Repositories
{
    /// <summary>
    /// Represents a client for calling the OpenAI API.
    /// </summary>
    public class OpenAIApiClient
    {
        private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";
        private readonly string _apiKey;
        private readonly string _model;

        /// <summary>
        /// Initializes a new instance of the OpenAIApiClient class.
        /// </summary>
        /// <param name="apiKey">The API key to use for authentication.</param>
        /// <param name="model">The model to use for completion.</param>
        public OpenAIApiClient(string apiKey, string model)
        {
            _apiKey = apiKey;
            _model = model;
        }

        public static async Task<List<string>> GetModelsAsync(string apiKey)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var httpResponse = await client.GetAsync("https://api.openai.com/v1/models").ConfigureAwait(false);
                httpResponse.EnsureSuccessStatusCode();

                var response = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var document = JsonDocument.Parse(response);
                var root = document.RootElement;
                var data = root.GetProperty("data");

                var modelIds = new List<string>();
                foreach (var item in data.EnumerateArray())
                {
                    var id = item.GetProperty("id").GetString();
                    modelIds.Add(id);
                }

                return modelIds;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return new();
        }

        /// <summary>
        /// Calls the OpenAI API with the given prompt and returns the response.
        /// </summary>
        /// <param name="prompt">The prompt to send to the API.</param>
        /// <returns>The response from the API.</returns>
        public async Task<string> CallOpenAI(string prompt)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            client.Timeout = new(0, 15, 0);
            //int tokens = 1024;
            //if (_model == "gpt-3.5")
            //{
            //    tokens *= 3;
            //}
            //if (_model == "gpt-3.5-turbo-16k")
            //{
            //    tokens *= 12;
            //}
            //if (_model == "gpt-4")
            //{
            //    tokens *= 6;
            //}
            //if (_model == "gpt-4-32k")
            //{
            //    tokens *= 24;
            //}
            var data = new
            {
                model = _model,
                messages = new[]
                {
                        new { role = "user", content = prompt }
                    },
                //max_tokens = tokens,
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return string.Empty;
            }

            var result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var parsedResult = JsonSerializer.Deserialize<OpenAIChatResponse>(result, options);
            return parsedResult?.Choices?[0].Message?.Content ?? string.Empty;
        }
    }
}
