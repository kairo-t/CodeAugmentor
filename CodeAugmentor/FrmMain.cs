using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CodeAugmentor
{
    public partial class FrmMain : Form
    {
        // Create a field to store the settings
        private UserSettings _userSettings;
        private List<ProcessableFile> _processableFiles = new();

        public FrmMain()
        {
            InitializeComponent();
            _userSettings = UserSettings.Load();
            txbAPIKey.Text = _userSettings.APIKey;
            rtbPrompt.Text = _userSettings.Prompt;
        }


        private async void btnFiles_Click(object sender, EventArgs e)
        {
            if (ofdFiles.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofdFiles.FileNames)
                {
                    _processableFiles.Add(new(file));
                }
                OpenAIApiClient openAIApiClient = new(txbAPIKey.Text, cmbEngine.Text);
                foreach (ProcessableFile processableFile in _processableFiles)
                {
                    // Read the content of the file
                    string fileContent = File.ReadAllText(processableFile.FilePath);

                    // Append the desired prompt to the file content
                    string prompt = $"{fileContent}\n{rtbPrompt.Text}\nRespond only with the code and do not skip writing any code, this will directly overwrite my file.";

                    // Call the OpenAI API with the prompt
                    var response = await openAIApiClient.CallOpenAI(prompt);

                    // Overwrite the file with the response
                    if (response.StartsWith("```") && response.EndsWith("```"))
                    {
                        // Remove the first and last line
                        var lines = response.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        response = string.Join("\n", lines.Skip(1).Take(lines.Length - 2));
                    }
                    File.WriteAllText(processableFile.FilePath, response);

                }
                MessageBox.Show($"Finished editing {_processableFiles.Count} files.");
                _processableFiles.Clear();
            }
        }

        private void txbAPIKey_TextChanged(object sender, EventArgs e)
        {
            _userSettings.APIKey = txbAPIKey.Text;
            _userSettings.Save();
        }

        private void rtbPrompt_TextChanged(object sender, EventArgs e)
        {
            _userSettings.Prompt = rtbPrompt.Text;
            _userSettings.Save();
        }
    }

    class ProcessableFile
    {
        public ProcessableFile(string filePath)
        {
            FilePath = filePath;
            Stage = "Unprocessed";
        }

        public string FileName
        {
            get
            {
                return FilePath.Split('\\').Last();
            }
        }
        public string FileExtension
        {
            get
            {
                return FilePath.Split('.').Last();
            }
        }
        public string FilePath { get; set; }
        public string Stage { get; set; }
    }

    public class OpenAIApiClient
    {
        private readonly string _apiUrl = "https://api.openai.com/v1/engines/davinci-codex/completions";
        private readonly string _apiKey;
        private readonly string _model;

        public OpenAIApiClient(string apiKey, string model)
        {
            _apiKey = apiKey;
            _model = model;
        }

        public async Task<string> CallOpenAI(string prompt)
        {
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
                client.Timeout = new(0, 15, 0);
                int tokens = 1024;
                if (_model == "gpt-3.5")
                {
                    tokens *= 3;
                }
                if (_model == "gpt-3.5-turbo-16k")
                {
                    tokens *= 12;
                }
                if (_model == "gpt-4")
                {
                    tokens *= 6;
                }
                if (_model == "gpt-4-32k")
                {
                    tokens *= 24;
                }
                var data = new
                {
                    model = _model,
                    messages = new[]
                    {
                        new { role = "user", content = prompt }
                    },
                    max_tokens = tokens,
                };

                var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

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
                return parsedResult.Choices[0].Message.Content;
            }
        }
    }

    public class OpenAIChatResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public Choice[] Choices { get; set; }
        public Usage Usagee { get; set; }

        public class Choice
        {
            public int Index { get; set; }
            public Message Message { get; set; }
            public string FinishReason { get; set; }
        }

        public class Message
        {
            public int Index { get; set; }
            public string Role { get; set; }
            public string Content { get; set; }
        }

        public class Usage
        {
            public int PromptTokens { get; set; }
            public int CompletionTokens { get; set; }
            public int TotalTokens { get; set; }
        }
    }


    public class Choice
    {
        public string Text { get; set; }
    }

    public class UserSettings
    {
        public string APIKey { get; set; }
        public string Prompt { get; set; }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText("userSettings.json", json);
        }

        public static UserSettings Load()
        {
            if (File.Exists("userSettings.json"))
            {
                string json = File.ReadAllText("userSettings.json");
                return JsonSerializer.Deserialize<UserSettings>(json);
            }
            return new UserSettings();
        }
    }
}