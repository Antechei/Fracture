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

        //ARRAY of dialogue strings - put it in a foreach loop to print them one at a time
        //(note the square brackets on 'string' - this makes it an array of strings. commas seperate each item in the array)
        private string[] initialDialogue = {
            "Outside the window, a steady patter of rain begins.",
            "it takes a few moments to build up, but the heavy droplets promise a small storm, at least.\n",
            "The air is warm and humid for now, the heat still sloughing off the suburban concrete even with the sun settling behind the hills.",
            "slowly, the air fills with the scent of warm, wet dirt. The droplets start to hit the ground faster than they can evaporate away.",
            "\nWho are you?"};

        //STRING of options - prints all at once
        private string answersInitial = 
            "[1] You feel calm as you breathe in the scent of rain. It's going to be a lovely night." +
            "\n[2] You hug your arms against yourself despite the heat, dreading the stormy night to come." +
            "\n[3] You hurry downstairs to close up the house against the humidity, grumbling under your breath." +
            "\n[4] You rest your arms on the windowsill and sigh, listening to the patter of rain and wondering if they're doing the same.";


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
            NumInput(); //wip
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
        void NumInput()
        {
            char c = Console.ReadKey(true).KeyChar; //get the key press
            switch (c)      //check what it was
            {
                case '1':   //if it's 1, do this

                    break;

                case '2':   //if it's '2', do this

                    break;

                case '3':   //etc

                    break;

                case '4':   //etc

                    break;

                default:    //if it wasn't any of those things, do this

                    break;
            }
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
