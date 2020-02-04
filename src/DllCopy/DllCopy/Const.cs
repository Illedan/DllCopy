using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy
{
    static class Const
    {
        public static string DefaultFolderName = "Plugins",
            IsSelectedEvent = "IsSelected",
            AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            ConfigFileLocation = System.IO.Path.Combine(AppData,"dllcopy.config"),
            BackupLocation = Path.Combine(AppData, "DllCopyBackup"),
            ConfigExtension = ".config",
            MessageEvent = "Message";
    }
}
