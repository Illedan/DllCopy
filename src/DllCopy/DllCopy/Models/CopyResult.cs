using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy.Models
{
    class CopyResult
    {
        public int ReplacedFiles;
        public int NewFiles;
        public int NotCopiedFiles;
        public override string ToString()
        {
            return $"New: {NewFiles} Replaced: {ReplacedFiles} Not copied: {NotCopiedFiles}";
        }
    }
}
