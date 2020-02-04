using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy.Services
{
    static class FileService
    {
        public static string CreateFolder(string path, string folder)
        {
            var newPath = Path.Combine(path, folder);
            Directory.CreateDirectory(newPath);
            return newPath;
        }
        public static void CopyFile(string path, string file)
        {
            var source = file;
            var destination = Path.Combine(path, Path.GetFileName(file) ?? "");

            File.Copy(source, destination, true);
        }
        public static bool FileExists(string fileLocation)
        {
            return File.Exists(fileLocation);
        }
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
        public static string ReadTextFromFile(string fileLocation)
        {
            return File.ReadAllText(fileLocation);
        }
        public static void WriteToFile(string fileLocation, string text)
        {
            File.WriteAllText(fileLocation, text);
        }
        public static void OpenLocationOfFile(string path)
        {
            var directory = Path.GetDirectoryName(path);
            if(string.IsNullOrEmpty(directory))
            {
                return;
            }

            Process.Start(directory);
        }

        public static string GetDirectory(string path)
        {
            return Path.GetDirectoryName(path);
        }
    }
}
