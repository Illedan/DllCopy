using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCopy.Models;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace DllCopy.Services
{
    static class TargetService
    {
        public static void Start(Target target) => target.Start();
        public static void Stop(Target target) => target.Stop();
        public static void StartWithCopy(Target target, Config config)
        {
            var result = new CopyResult();
            CopyService.CopyTo(FileService.GetDirectory(target.Path), config.Folders, result);
            Start(target);
            EventService.Publish(Const.MessageEvent, result);
        }

        public static void Delete(Target target, Config config)
        {
            config.Targets.Remove(target);
            ConfigService.SaveConfig(config);
        }

        public static void Open(Target target) => Process.Start(FileService.GetDirectory(target.Path));

        public static void AddTarget(string path, Config config)
        {
            if(path == null)
            {
                AddTarget(config);
                return;
            }

            config.Targets.Add(new Target(path));
            ConfigService.SaveConfig(config);
        }

        public static void AddTarget(Config config)
        {
            foreach(var file in BrowserService.GetFiles())
            {
                AddTarget(file, config);
            }
        }
    }
}
