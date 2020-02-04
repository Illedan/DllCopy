using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DllCopy.Extensions;
using DllCopy.Models;
using DllCopy.Services;
using DllCopy.View;

namespace DllCopy
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Config m_config;
        private string message;

        public MainViewModel(Config config)
        {
            m_config = config;
            EventService.Subscribe(Const.MessageEvent, o => Message = o.ToString());
        }

        public async void OnClosing()
        {
            await ConfigService.SaveConfig(m_config);
        }

        public ObservableCollection<Folder> Folders => m_config.Folders;
        public ObservableCollection<Target> Targets => m_config.Targets;

        public Command StartCommand => new Command(o => TargetService.Start((Target) o), o => true);
        public Command StopCommand => new Command(o => TargetService.Stop((Target) o), o => true);
        public Command StartWithCopyCommand => new Command(o => TargetService.StartWithCopy((Target) o, m_config), o => true);
        public Command OpenCommand => new Command(o => TargetService.Open((Target) o), o => true);


        public Command AddTargetCommand => new Command(o => TargetService.AddTarget(o as string, m_config), o => true);
        public Command RemoveTargetCommand => new Command(o => TargetService.Delete((Target)o, m_config), o => true);


        public Command DeleteFolderCommand => new Command(o => FolderService.DeleteFolder((Folder) o, m_config), o => true);
        public Command DeleteFileCommand => new Command(o => FolderService.DeleteFile((File) o, m_config), o => true);
        public Command AddFolderCommand => new Command(o => FolderService.AddFolder((Folder) o, m_config), o => true);
        public Command AddFileCommand => new Command(o => FolderService.AddFiles((Folder) o), o => true);
        public static Command OpenFileCommand => new Command(o => FolderService.OpenFile((File)o), o => true);


        public Command AddOuterFolderCommand => new Command(o => FolderService.AddFolder(m_config), o => true);


        public Command SaveConfigCommand => new Command(o => ConfigService.SaveConfig(m_config), o => true);


        public Target SelectedTarget
        {
            get => m_config.SelectedTarget; set
            {
                m_config.SelectedTarget = value;
                this.OnPropertyChanged(PropertyChanged);
            }
        }
        public string Message { get => message; set => this.Set(ref message, value, PropertyChanged); }
        public string FolderFilter
        {
            get => m_config.Filter; set
            {
                m_config.Filter = value;
                this.OnPropertyChanged(PropertyChanged);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
