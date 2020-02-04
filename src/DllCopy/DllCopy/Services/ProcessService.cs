using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCopy.Services
{
    static class ProcessService
    {
        public static Process Start(string location)
        {
            try
            {
                return Process.Start(location);
            }
            catch(Exception e)
            {
                EventService.Publish(Const.MessageEvent, e.Message);
                return null;
            }
        }

        public static void Stop(Process process)
        {
            try
            {
                process.Kill();
            }
            catch(Exception e)
            {
                EventService.Publish(Const.MessageEvent, e.Message);
            }
        }
    }
}
