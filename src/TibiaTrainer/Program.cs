namespace TibiaTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            AntiAfk();
            Eat();
            SpendMana();
        }

        private static void AntiAfk()
        {
            WinApi.SetTibiaInForeground();
            WinApi.SendKeys("^(w)");
            WinApi.SendKeys("^(s)", 1000);
        }

        private static void Eat()
        {
            PressHotkey("{F12}", 4);
        }

        private static void SpendMana()
        {
            PressHotkey("{F11}", 11);
        }

        private static void PressHotkey(string hotkey, int repeat = 1)
        {
            WinApi.SetTibiaInForeground();

            for (int i = 0; i < repeat; i++)
            {
                WinApi.SendKeys(hotkey, 100);
            }

            WinApi.SetPreviousProcessInForeground();

        }
    }
}
