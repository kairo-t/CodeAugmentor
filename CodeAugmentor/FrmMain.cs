using CodeAugmentor.Models;
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
            // Load the saved templates into the combo box
            foreach (var template in _userSettings.Templates)
            {
                cmbTemplates.Items.Add(template.Name);
            }

            // Select the first template if any templates were loaded
            if (cmbTemplates.Items.Count > 0)
            {
                cmbTemplates.SelectedIndex = 0;
            }
            cmbEngine.SelectedItem = _userSettings.EngineVersion ?? "gpt-3.5-turbo";
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

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            // Save the current prompt as a new template.
            string templateName = InputBox.Show("Save Template", "Enter a name for the template:");

            if (!string.IsNullOrWhiteSpace(templateName))
            {
                var newTemplate = new Template
                {
                    Name = templateName,
                    Content = rtbPrompt.Text
                };

                _userSettings.Templates.Add(newTemplate);
                _userSettings.Save();

                cmbTemplates.Items.Add(templateName);
            }
            cmbTemplates.SelectedIndex = cmbTemplates.Items.Count - 1;
        }

        private void cmbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load the selected template into the prompt box.
            string templateName = cmbTemplates.SelectedItem.ToString();
            Template selectedTemplate = _userSettings.Templates.Find(t => t.Name == templateName);
            rtbPrompt.Text = selectedTemplate?.Content ?? string.Empty;
        }

        private void btnRemoveTemplate_Click(object sender, EventArgs e)
        {
            if (cmbTemplates.Items.Count == 0)
            {
                return;
            }
            // Remove the selected template
            string templateName = cmbTemplates.SelectedItem.ToString();
            Template templateToRemove = _userSettings.Templates.Find(t => t.Name == templateName);

            if (templateToRemove != null)
            {
                _userSettings.Templates.Remove(templateToRemove);
                _userSettings.Save();

                cmbTemplates.Items.Remove(templateName);
                cmbTemplates.Text = string.Empty;
            }
        }

        private void cmbEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the engine version in user settings when the selected engine version changes
            _userSettings.EngineVersion = cmbEngine.SelectedItem.ToString();
            _userSettings.Save();
        }
    }
}