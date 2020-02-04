using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCopy.Services;

namespace DllCopy.Models
{
    class Folder
    {
        private bool m_isSelected;
        public string Title { get; set; }
        public ObservableCollection<Folder> Folders { get; } = new ObservableCollection<Folder>();
        public ObservableCollection<File> Files { get; } = new ObservableCollection<File>();

        public void AddFiles(string [] paths)
        {
            foreach(var path in paths)
            {
                AddFile(path);
            }
        }

        public void AddFile(string path)
        {
            Files.Add(new File(path));
        }

        public void AddFolder()
        {
            Folders.Add(new Folder { Title = Const.DefaultFolderName });
        }

        public bool IsExpanded { get; set; }

        public bool IsSelected
        {
            get { return m_isSelected; }
            set
            {
                m_isSelected = value;
                EventService.Publish(Const.IsSelectedEvent);
            }
        }
    }
}
