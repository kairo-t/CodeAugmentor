using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAugmentor.Models
{
    /// <summary>
    /// Represents a file that can be processed.
    /// </summary>
    class ProcessableFile
    {
        public ProcessableFile(string filePath)
        {
            FilePath = filePath;
            Stage = "Unprocessed";
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string FileName
        {
            get
            {
                return FilePath.Split('\\').Last();
            }
        }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public string FileExtension
        {
            get
            {
                return FilePath.Split('.').Last();
            }
        }

        /// <summary>
        /// Gets or sets the path of the file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the stage of processing for the file.
        /// </summary>
        public string Stage { get; set; }
    }
}
