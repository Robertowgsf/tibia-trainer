using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TibiaTrainer
{
    public class WinApi
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        private static Process _previousProcess;

        private static Process GetTibiaProcess()
        {
            return Process.GetProcessesByName("client")[0];
        }

        public static void SetTibiaInForeground()
        {
            _previousProcess = Process.GetCurrentProcess();
            SetForegroundWindow(GetTibiaProcess().MainWindowHandle);
        }

        public static void SetPreviousProcessInForeground()
        {
            SetForegroundWindow(_previousProcess.MainWindowHandle);
        }

        public static void SendKeys(string key, int delay = 0)
        {
            if (delay > 0) Thread.Sleep(delay);

            System.Windows.Forms.SendKeys.SendWait(key);
        }
    }
}
