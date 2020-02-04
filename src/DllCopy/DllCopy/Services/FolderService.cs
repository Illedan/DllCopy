using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCopy.Models;

namespace DllCopy.Services
{
    static class FolderService
    {
        public static void AddFolder(Config config)
        {
            config.Folders.Add(new Folder { Title = "New" });
        }

        public static void AddFolder(Folder folder, Config config)
        {
            folder.AddFolder();
        }
        
        public static void OpenFile(File file)
        {
            ProcessService.Start(FileService.GetDirectory(file.Path));
        }
        
        public static void AddFiles(Folder folder, params string[] files)
        {
            foreach(var file in files)
            {
                folder.AddFile(file);
            }
        }

        public static void AddFiles(Folder folder)
        {
            AddFiles(folder, BrowserService.GetFiles());
        }

        public static void DeleteFile(File file, Config config)
        {
            DeleteFile(file, config.Folders);
        }

        private static void DeleteFile(File file, ObservableCollection<Folder> folders)
        {
            foreach(var nextFolder in folders)
            {
                nextFolder.Files.Remove(file);
                DeleteFile(file, nextFolder.Folders);
            }
        }

        public static void DeleteFolder(Folder folder, Config config)
        {
            DeleteFolder(folder, config.Folders);
        }

        private static void DeleteFolder(Folder folder, ObservableCollection<Folder> folders)
        {
            folders.Remove(folder);
            foreach(var nextFolder in folders)
            {
                DeleteFolder(folder, nextFolder.Folders);
            }
        }
    }
}
