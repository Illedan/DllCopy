using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DllCopy.Models
{
    class File
    {
        [JsonConstructor]
        public File(string path)
        {
            Path = path;
        }

        [JsonIgnore]
        public string Title => string.IsNullOrEmpty(Path) ? "" : System.IO.Path.GetFileName(Path);

        public string Path { get; }
    }
}
