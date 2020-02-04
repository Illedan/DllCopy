using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy.Models
{
    class Config
    {
        public Target SelectedTarget { get; set; }
        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();
        public ObservableCollection<Target> Targets { get; set; } = new ObservableCollection<Target>();
        public string Filter { get; set; }
    }
}
