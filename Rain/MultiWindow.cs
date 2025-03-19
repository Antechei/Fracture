using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    //working on making a thing to open other windows, for tutorial info or similar
    //stretch goal!
    internal class MultiWindow
    {
        int windowToOpen = 1;

        public void TestCode()
        {
            if (windowToOpen != 0)
            {
                if (windowToOpen == 1)
                {
                    NormalPathOfExectution();
                }
                //add other options here and below              
            }
            else
            {              
                AlternatePathOfExecution();
            }
        }


        private void NormalPathOfExectution()
        {
            Console.WriteLine("Doing something here");
            //need one of these for each additional console window
            System.Diagnostics.Process.Start("Proof of Concept 2.exe", "1"); //so, need to build a seperate .exe that contains my stuff and then tell my main app to open it
            Console.ReadLine();

        }
        private void AlternatePathOfExecution()
        {
            Console.WriteLine("Write something different on other Console");
            Console.ReadLine();            
        }

    }
}

