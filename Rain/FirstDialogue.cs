using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    internal class FirstDialogue
    {

        private int path;

        //ARRAY of dialogue strings - put it in a foreach loop to print them one at a time
        //(note the square brackets on 'string' - this makes it an array of strings. commas seperate each item in the array)
        private string[] initialDialogue = {
            "Today, the sky looked grey and heavy. Dense clouds smothered the atmosphere and concentrated the sun’s warm glow into a blanket of glaring white.\n",
            "Outside your window, rain breaks.\n",
            "It is steady and deliberate, cutting through the thick air of anticipation. The first droplets evaporate on the warm concrete, leaving tiny shadows where they fell.",
            "The humid air fills with the scent of wet dirt. Water begins to pool quicker than the earth can absorb it."};

        //STRING of options - prints all at once
        private string answersInitial = 
            "Who are you?" +
            "\n\n[1] You feel calm as you breathe in the scent of rain. It's going to be a lovely night." +
            "\n[2] You put on your headphones to drown out the sound of rain. A knot in your stomach forms as you worry about the stormy night to come." +
            "\n[3] You stand up from your computer, swearing under your breath. You had hoped there wouldn’t be a storm this summer." +
            "\n[4] You look outside and see a bird perched in the tree beyond your window, with its face tucked safely under a wing against the rain." +
            " You smile to yourself and wonder if the downpour has found its way to their part of town yet";

        private string[] secondDialogue = {
        "\nA warm breeze carries the earthy smell of rainfall through the open window in your bedroom." +
        "\nYou breathe in deeply, and the rhythmic patter on your roof brings a smile to your face.",

        "\nWhat was, moments ago, a small shower is slowly building into something more formidable." +
        "\nYou shut the window and turn back to your computer.",

        "\nThe humid air clings to your skin. Everything is slightly damp, and the ceiling fan only makes you more aware of the thin layer of sweat coating you." +
        "\nYou grumble as you close the window, begrudgingly aware that it will make no difference.",

        "\nPlaceholder Placeholder Placeholder etc"
        };

        private string[] thirdDialogue = {
        "You feel a strange giddiness, remembering how as a child, you would build blanket forts during a storm, reading to your stuffed animals by torchlight.",

        "That sounded really close. You move away from the window and seek comfort in your bed." +
        "\nYou feel as if your blood has turned to ice in your veins.",

        "The storm you hoped would pass quickly now seems like it’s here to stay." +
        "\nYou walk downstairs to cook dinner. Whatever. You’ll just go to bed early, tonight.",

        "Placeholder Placeholder Placeholder etc"
        };


        //first scene function. put all the doodads in here
        public void FirstScene()
        {
            Console.WriteLine();
            SpaceInput();
            foreach (string line in initialDialogue)
            {
                Console.WriteLine(line);
                SpaceInput();
            }
            Console.WriteLine();
            Console.WriteLine(answersInitial);
            NumInputFour(secondDialogue);
        }

        public void FirstSceneTwo()
        {
            Console.Clear();
            if (path == 1)
            { Console.WriteLine(thirdDialogue[0]); }
            else if (path == 2)
            { Console.WriteLine(thirdDialogue[1]); }
            else if (path == 3)
            { Console.WriteLine(thirdDialogue[2]); }
            else if(path == 4)
            { Console.WriteLine(thirdDialogue[3]); }
            Console.ReadKey(true);
        }

        //func to progress narrative
        //proceeds on spacebar, ignores all other inputs
        void SpaceInput()
        {
            bool paused = true; //'pause' the narrative
            do //the thing once
            {
                char c = Console.ReadKey(true).KeyChar; //get the key that's pressed
                if (c == ' ') {paused = false;}         //if it's space, 'unpause' the narrative

            } while (paused); //keep doing it if (paused == true)   
        }

        //in progress
        //func for selecting narrative options
        void NumInputFour(String[] dialogue)
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar; //get the key press
                switch (c)      //check what it was
                {
                    case '1':   //if it's 1, do this
                        Console.WriteLine(dialogue[0]);
                        path = 1;
                        numSelect = false;
                        break;
                    case '2':   //if it's '2', do this
                        Console.WriteLine(dialogue[1]);
                        numSelect = false;
                        path = 2;
                        break;
                    case '3':   //etc
                        Console.WriteLine(dialogue[2]);
                        path = 3;
                        numSelect = false;
                        break;
                    case '4':   //etc
                        Console.WriteLine(dialogue[3]);
                        path = 4;
                        numSelect = false;
                        break;
                    default:    //if it wasn't any of those things, do this (nothing)
                        break;
                }
            } while (numSelect == true);
        }


        //ignore this lol
        /*Console.WriteLine("...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("\nWhoops, that's all for now! i spent way too long fucking around with the intro to write any content after this." +
                "\nSo like, please go back and fuck with that a little. Please. Make it worth it-");
            Console.ReadKey(true);*/

    }
}
