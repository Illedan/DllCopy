using System;
using System.Collections.ObjectModel;
using DllCopy.Models;

namespace DllCopy.Services
{
    static class CopyService
    {
        public static void CopyTo(string path, ObservableCollection<Folder> folders, CopyResult copyResult)
        {
            try
            {
                foreach(var folder in folders)
                {
                    if(folder.IsSelected)
                    {
                        CopyTo(path, folder, copyResult);
                    }
                }
            }
            catch(Exception e)
            {
                EventService.Publish(Const.MessageEvent, e.Message);
            }
        }

        public static void CopyTo(string path, Folder folder, CopyResult copyResult)
        {
            System.IO.Directory.CreateDirectory(path);
            foreach(var file in folder.Files)
            {
                if(!System.IO.File.Exists(System.IO.Path.Combine(path, (file as File).Title)))
                {
                    copyResult.NewFiles++;
                }
                else if(System.IO.File.GetLastWriteTime((file as File).Path) != System.IO.File.GetLastWriteTime(System.IO.Path.Combine(path, (file as File).Title)))
                {
                    copyResult.ReplacedFiles++;
                }
                else
                {
                    copyResult.NotCopiedFiles++;
                }

                // Copy anyway, in case of rare equal time or whatnot..
                FileService.CopyFile(path, (file as File).Path);
            }

            foreach(var nextFolder in folder.Folders)
            {
                CopyTo(FileService.CreateFolder(path, nextFolder.Title), nextFolder, copyResult);
            }
        }
    }
}
