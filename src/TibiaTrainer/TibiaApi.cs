using System.Diagnostics;

namespace TibiaTrainer
{
    public class TibiaApi : WinApi
    {
        private static Process GetTibiaProcess()
        {
            return Process.GetProcessesByName("client")[0];
        }

        public static void SetTibiaInForeground()
        {
            WinApi.PreviousProccess = Process.GetCurrentProcess();
            SetForegroundWindow(GetTibiaProcess().MainWindowHandle);
        }
    }
}
