using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAugmentor.Models
{
    /// <summary>
    /// Represents the response from the OpenAI chat API.
    /// </summary>
    public class OpenAIChatResponse
    {
        public string? Id { get; set; }
        public string? Object { get; set; }
        public int Created { get; set; }
        public string? Model { get; set; }
        public Choice[]? Choices { get; set; }
        public Usage? Usagee { get; set; }

        public class Choice
        {
            public int Index { get; set; }
            public Message? Message { get; set; }
            public string? FinishReason { get; set; }
        }

        public class Message
        {
            public int Index { get; set; }
            public string? Role { get; set; }
            public string? Content { get; set; }
        }

        public class Usage
        {
            public int PromptTokens { get; set; }
            public int CompletionTokens { get; set; }
            public int TotalTokens { get; set; }
        }
    }
}