using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCopy.Extensions;
using DllCopy.Services;
using Newtonsoft.Json;

namespace DllCopy.Models
{
    class Target : INotifyPropertyChanged
    {
        private string icon;
        private string title;

        [JsonConstructor]
        public Target(string path, string title = "", string icon = "")
        {
            Path = path;
            Title = string.IsNullOrEmpty(title) ? FileService.GetFileName(path) : title;
            Icon = string.IsNullOrEmpty(icon) ? "F1 M 19.0002,34L 19.0002,42L 43.7502,42L 33.7502,52L 44.2502,52L 58.2502,38L 44.2502,24L 33.7502,24L 43.7502,34L 19.0002,34 Z " : icon;
        }

        public string Icon { get => icon; set => this.Set(ref icon, value, PropertyChanged); }
        public string Path { get; set; }
        public string Title { get => title; set => this.Set(ref title, value, PropertyChanged); }

        [JsonIgnore]
        public Process RunningProcess { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Stop()
        {
            ProcessService.Stop(RunningProcess);
        }

        public void Start()
        {
            RunningProcess = ProcessService.Start(Path);
        }
    }
}
