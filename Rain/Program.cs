using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    static class Winuser
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmd);

        public const int SW_MAXIMISE = 3;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //what it says on the box - put other class references in here to access their content
            #region Class References

            OpeningScene oS = new OpeningScene();
            CalmPath calm = new CalmPath();
            Formatting form = new Formatting();
            MultiWindow mWindow = new MultiWindow();
            int selection = 10;
            #endregion          

            //if you're gonna write a function in this class, put it in this region
            #region Main Functions

            void Fullscreen()
            {
                Process p = Process.GetCurrentProcess();
                Winuser.ShowWindow(p.MainWindowHandle, Winuser.SW_MAXIMISE);
            }

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

            //tutorial thingy
            void InstructionsNew()
            {
                Console.WriteLine("\n Welcome to A Rain Story.txt,\n   aka our silly lil SlamJam2025 submission,\n      aka a short text-based rpg about the rain, possibly?");
                Console.Write("\n      Written and produced by "); form.CPurple(); Console.Write("LunaMouse "); form.CDefault(); Console.Write("and "); form.CDGreen(); Console.WriteLine("Flora & Stone.");
                form.CDefault(); Console.Write("\n      With very special thanks to "); form.CPink(); Console.Write("Catgirl Software <3"); form.CDefault();
                Console.WriteLine("\n\n\n Please press Spacebar to continue...");
                SpaceInput();
                Console.Clear();
                Console.WriteLine("Good job! Spacebar will be used to progress to the next line at most points in the story.");
                SpaceInput();
                Console.WriteLine("\n...Unless you're prompted to select an option. In that case, press the numerical key that correlates to the path you wish to take.\n\nGot that?");
                Console.WriteLine("\n[1] Yeah!\n[2] Not really...");
                
                NumProceed();
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nThen here goes nothing!");
                        break;
                    case 2:
                        Console.WriteLine("\nWell, you seem to have figured it out anyway.");
                        break;
                    default:
                        break;
                }
                SpaceInput();
                Console.Clear();
                Console.WriteLine("\nBy the way: We couldn't quite polish all of the current content before the submission deadline..." +
                    "\n\nI'd recommend choosing the option to build a pillow fort for your first playthrough! The other option is playable, but... well, you'll see. It's a bit janky >.<" +
                    "\nAnd the pillow fort path is our favourite anyway :3");
                SpaceInput();
                Console.WriteLine("\n\nHave fun <3");
                SpaceInput();
                Console.Clear();
            }

            void SpaceInput()
            {
                bool paused = true; //'pause' the narrative
                do //the thing once
                {
                    char c = Console.ReadKey(true).KeyChar; //get the key that's pressed
                    if (c == ' ') { paused = false; }         //if it's space, 'unpause' the narrative

                } while (paused); //keep doing it if (paused == true)   
            }

            void NumProceed()
            {
                bool numSelect = true;
                do
                {
                    char c = Console.ReadKey(true).KeyChar; //get the key press
                    switch (c)      //check what it was
                    {
                        case '1':   //if it's 1, do this
                            selection = 1;
                            numSelect = false;
                            break;
                        case '2':   //if it's '2', do this
                            selection = 2;
                            numSelect = false;
                            break;
                        default:    //if it wasn't any of those things, do this (nothing)
                            break;
                    }
                } while (numSelect == true);
            }
                #endregion

                //put functions in here to run them as part of the program
                #region Playing
                Fullscreen();
                InstructionsNew();
                oS.Opening();
                calm.CalmOne();
                Console.ReadKey(true);
                #endregion

            
            
        }
    }
}