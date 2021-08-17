using System;
using System.Threading;

namespace TibiaTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var antiAfkTimerSeconds = 15 * 60 * 1000;
            var eatTimerSeconds = 16 * 60 * 1000;
            var spendManaTimerSeconds = 5 * 60 * 1000;

            var antiAfkTimer = new Timer(AntiAfk, null, 0, antiAfkTimerSeconds);
            var eatTimer = new Timer(Eat, null, 1000, eatTimerSeconds);
            var spendManaTimer = new Timer(SpendMana, null, 2000, spendManaTimerSeconds);

            Console.ReadKey();
        }

        private static void AntiAfk(object o)
        {
            Console.WriteLine(DateTime.Now.ToString() + ": Anti Afk");
            PressHotkey("^(w)");
            PressHotkey("^(s)", 1, 300);
        }

        private static void Eat(object o)
        {
            Console.WriteLine(DateTime.Now.ToString() + ": Eat");
            PressHotkey("{F12}", 4);
        }

        private static void SpendMana(object o)
        {
            Console.WriteLine(DateTime.Now.ToString() + ": Spend Mana");
            PressHotkey("{F11}", 11);
        }

        private static void PressHotkey(string hotkey, int repeat = 1, int delay = 100)
        {
            WinApi.SetTibiaInForeground();

            for (int i = 0; i < repeat; i++)
            {
                WinApi.SendKeys(hotkey, delay);
            }

            WinApi.SetPreviousProcessInForeground();
        }
    }
}
