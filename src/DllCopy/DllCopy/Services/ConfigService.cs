using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCopy.Models;
using Newtonsoft.Json;

namespace DllCopy.Services
{
    static class ConfigService
    {
        private static Task m_saveTask;
        public static async Task<Config> ReadConfig()
        {
            return await Task.Run(() =>
            {
                try
                {
                    if(!FileService.FileExists(Const.ConfigFileLocation))
                    {
                        return new Config();
                    }

                    var json = FileService.ReadTextFromFile(Const.ConfigFileLocation);
                    FileService.CreateFolder(Const.AppData, "DllCopyBackup");
                    var path = Path.Combine(Const.BackupLocation, "backup".AppendTimeStamp());
                    System.IO.File.WriteAllText(path, json);
                    return JsonConvert.DeserializeObject<Config>(json);
                }
                catch(Exception e)
                {
                    return new Config();
                }
            });
        }

        public static async Task SaveConfig(Config config)
        {
            if(m_saveTask != null)
                return;

            var t = Task.Run(() => {
                var json = JsonConvert.SerializeObject(config);
                FileService.WriteToFile(Const.ConfigFileLocation, json);
                FileService.CreateFolder(Const.AppData, "DllCopyBackup");
                var path = Path.Combine(Const.BackupLocation, "backup".AppendTimeStamp());
                System.IO.File.WriteAllText(path, json);
            });

            m_saveTask = t;
            await t;
            m_saveTask = null;
        }

        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                Path.GetExtension(fileName));
        }
    }
}
