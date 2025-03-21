using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //what it says on the box - put other class references in here to access their content
            #region Class References

            OpeningScene oS = new OpeningScene();
            Formatting form = new Formatting();
            MultiWindow mWindow = new MultiWindow();

            #endregion
           

            //if you're gonna write a function in this class, put it in this region
            #region Main Functions

            //temp amusing tutorial thingy
            void Instructions()
            {
                Console.WriteLine("\nWelcome to Rain.txt, aka my silly lil SlamJam2025 submission, aka a short text-based rpg about the rain, possibly?" +
                    "\n\nPress Spacebar to continue to the next line.");
                Console.ReadKey(true);
                Console.WriteLine("\nGood job! You have a keyboard and reading comprehension, or else you got really lucky somehow I guess." +
                    "\n\n(What the govenment doesn't want you to know is that any standard key input will work for now, but it'll be Spacebar later!" +
                    "\n(Also, I recommend resizing this window so that each of these lines fits on the screen without wrapping! You should do that now)");
                Console.ReadKey(true);
                Console.WriteLine("\nAre you ready to progress? (Press the numerical key to select an option}\n[1] Yes.\n[2] No.");

                bool waiting = false;
                bool waitingTwo = false;
                bool waitingThree = false;
                char i;
                int oops = 0;
                do
                {
                    i = Console.ReadKey(true).KeyChar;
                    if (i == '1')
                    {
                        Console.Clear();
                        if (waitingThree == true)
                        {
                            Console.WriteLine("\nThere you go, you did it!\nHave fun :)");
                            Console.ReadKey(true);
                            Console.Clear();
                            return;
                        }
                        Console.WriteLine("\nHave fun.");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                    else if (i == '2')
                    {
                        if (waiting == false)
                        {
                            if (waitingThree == true)
                            { Console.WriteLine("\nHey, you found 2! I'm so proud of you.\nGood luck finding 1! Whenever you're ready :)"); }
                            else { Console.WriteLine("\nUhhh, okay. Well, whenever you're ready..."); }
                            waiting = true;
                        }
                    }
                    else
                    {
                        waitingTwo = true;
                        if (waiting == false)
                        {
                            switch (oops)
                            {
                                case 0:
                                    Console.WriteLine("\nYeah, that's not a 1 or a 2. Try again?");
                                    oops++;
                                    break;
                                case 1:
                                    Console.WriteLine("Not quite. You can do it!");
                                    waitingThree = true;
                                    oops++;
                                    break;
                                case 2:
                                    Console.WriteLine("So close!!");
                                    oops++;
                                    break;
                                case 3:
                                    Console.WriteLine("I'll always believe in you!");
                                    oops++;
                                    break;
                                case 4:
                                    Console.WriteLine("Just one more try!!");
                                    oops++;
                                    break;
                                case 5:
                                    Console.WriteLine("One..... more....!");
                                    oops++;
                                    break;
                                case 6:
                                    Console.WriteLine("Uh.");
                                    oops++;
                                    break;
                                case 7:
                                    Console.WriteLine("Alright, I'm patient! I can wait. You take as much time as you need to find 1 or 2. I'll be here. <3");
                                    oops++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                } while ((waiting == true) || (waitingTwo == true));
            }



            #endregion

            //put functions in here to run them as part of the program
            #region Playing

            //Instructions();
            oS.Opening();
            form.LightningStrike("An abrupt peal of thunder cracks like a whip above the deafening rain. Your windowpanes shudder as the noise reverberates.");
            //oS.FirstSceneTwo();
            Console.ReadKey(true);
            #endregion

        }
    }
}