using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DllCopy.Services
{
    static class BrowserService
    {
        public static string[] GetFiles()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.ShowDialog();

                var files = openFileDialog.FileNames;
                if(files != null && files.Any())
                {
                    return files;
                }
            }
            catch(Exception e)
            {

            }

            return new string [0];
        }
    }
}
