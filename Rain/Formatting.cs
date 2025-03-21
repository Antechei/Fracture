using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rain
{
    internal class Formatting
    {
        #region Colour Cheet Sheet
        /* Desired Colour = Function Name
         * 
         * Red = CRed();
         * Yellow = CYel();
         * Green = CGreen();
         * Dark Green = CDGreen();
         * Cyan = CCyan();
         * Blue = CBlue();
         * Dark Blue = CDBlue();
         * Magenta = CPink();
         * Dark Magenta = CPurple();
         * White = CWhite();
         * Dark Gray = CGray();
         * Gray = CDefault();
         * 
        */
        #endregion

        #region Colours
        public void CRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void CYel()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void CGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void CDGreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        public void CCyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void CBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void CDBlue()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        public void CPink()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        public void CPurple()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
        public void CWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void CGray()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
        public void CDefault()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion

        #region Dramatic Delay

        public void WriteDelayedLine(string writeLine, TimeSpan delay, int charDelay) //Line to write, total time taken to write it, delay between each character
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            TimeSpan lastValue = TimeSpan.Zero;
            CharDelay(writeLine, charDelay);
            while (lastValue < delay)
            {
                TimeSpan currentValue = stopWatch.Elapsed;            
                lastValue = currentValue;
                Console.ReadKey(true);
            }
        }

        public void CharDelay(string str, int charDelay)
        {
            char nextChar;
            for (int i = 0; i <= str.Length - 1; i++) //for the length of the string
            {
                nextChar = str[i]; //decide the current character in the string
                Console.Write(nextChar); //print the current character in the string
                Task.Delay(charDelay).Wait();
                ClearBuffer();
            }
        }

        static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            { Console.ReadKey(true); }
        }

        #endregion

        #region Lightning

        public void LightningStrike(string displayAfter)
        {
            string bigPause = "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";

            Console.ReadKey(true);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(bigPause);
            Console.WriteLine(bigPause);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(bigPause);
            Console.Clear();
            Console.WriteLine(displayAfter + "\n");
            Console.ReadKey(true);
        }

        #endregion
    }
}
