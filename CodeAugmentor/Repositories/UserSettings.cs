using System.Text.Json;
using CodeAugmentor.Models;

namespace CodeAugmentor.Repositories
{
    /// <summary>
    /// Represents user settings.
    /// </summary>
    public class UserSettings
    {
        public string? APIKey { get; set; }
        public string? Prompt { get; set; }
        public List<Template> Templates { get; set; } = new List<Template>();
        public string? EngineVersion { get; set; }

        /// <summary>
        /// Saves the user settings to a JSON file.
        /// </summary>
        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText("userSettings.json", json);
        }

        /// <summary>
        /// Loads the user settings from a JSON file.
        /// </summary>
        /// <returns>The loaded user settings.</returns>
        public static UserSettings Load()
        {
            if (File.Exists("userSettings.json"))
            {
                string json = File.ReadAllText("userSettings.json");
                return JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
            }
            return new UserSettings();
        }
    }
}
