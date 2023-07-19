using CodeAugmentor.Repositories;

namespace CodeAugmentor
{
    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class FrmMain : Form
    {
        // Create a field to store the settings
        private UserSettings _userSettings;
        private List<ProcessableFile> _processableFiles = new();

        /// <summary>
        /// Initializes a new instance of the FrmMain class.
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
            _userSettings = UserSettings.Load();
            txbAPIKey.Text = _userSettings.APIKey;
            rtbPrompt.Text = _userSettings.Prompt;
        }

        private async void btnFiles_Click(object sender, EventArgs e)
        {
            // Show the file dialog and get selected files
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
            // Update the API key in user settings when the API key text box changes
            _userSettings.APIKey = txbAPIKey.Text;
            _userSettings.Save();
        }

        private void rtbPrompt_TextChanged(object sender, EventArgs e)
        {
            // Update the prompt in user settings when the prompt text box changes
            _userSettings.Prompt = rtbPrompt.Text;
            _userSettings.Save();
        }
    }
}