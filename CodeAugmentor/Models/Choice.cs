using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAugmentor.Models
{
    /// <summary>
    /// Represents a choice in a conversation.
    /// </summary>
    public class Choice
    {
        private string? _text;

        public string Text 
        { 
            get { return _text ?? string.Empty; } 
            set { _text = value; } 
        }
    }
}