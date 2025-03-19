using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        

        public void CharDelay(string str, int charDelay)
        {
            char nextChar;
            for (int i = 0; i <= str.Length - 1; i++) //for the length of the string
            {
                nextChar = str[i]; //decide the current character in the string
                Console.Write(nextChar); //print the current character in the string
                Thread.Sleep(charDelay); //input how long you want it to wait for, it will wait for that length in milliseconds
            }
        }

        public void EatInputs(TimeSpan delay)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            TimeSpan lastValue = TimeSpan.Zero;
            CharDelay("An abrupt peal of thunder cracks like a whip above the deafening rain. Your windowpanes shudder as the noise reverberates.", 1);
            while (lastValue < delay)
            {
                Console.Out.Flush();
                TimeSpan currentValue = stopWatch.Elapsed;            
                lastValue = currentValue;
                // run a loop that gets everything currently queued, does something with it, and carries on
                //for each thing in buffer, readkey(true) ?
            }
            
        }
        #endregion
    }
}
