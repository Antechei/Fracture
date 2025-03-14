using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain
{
    internal class FirstDialogue
    {
        string[] initialDialogue = {"Outside the window, a steady patter of rain begins.",
        "it takes a few moments to build up, but the heavy droplets promise a small storm, at least.\n",
        "The air is warm and humid for now, the heat still sloughing off the suburban concrete even with the sun settling behind the hills.",
        "slowly, the air fills with the scent of warm, wet dirt. The droplets start to hit the ground faster than they can evaporate away.",
        "Who are you?"};

        string answersInitial = "[1] You feel calm as you breathe in the scent of rain. It's going to be a lovely night." +
            "\n[2] You hug your arms against yourself despite the heat, dreading the stormy night to come." +
            "\n[3] You hurry downstairs to close up the house against the humidity, grumbling under your breath." +
            "\n[4] You rest your arms on the windowsill and sigh, listening to the patter of rain and wondering if they're doing the same.";

        public void FirstScene()
        {
            Console.WriteLine();
            Console.ReadKey(true);
            Console.WriteLine(initialDialogue[0]);
            Console.ReadKey(true);
            Console.WriteLine(initialDialogue[1]);
            Console.ReadKey(true);
            Console.WriteLine(initialDialogue[2]);
            Console.ReadKey(true);
            Console.WriteLine(initialDialogue[3]);
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine(initialDialogue[4]);
            Console.ReadKey(true);
            Console.WriteLine();
            Console.WriteLine(answersInitial);
            Console.ReadKey(true);

            Console.WriteLine("...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("\nWhoops, that's all for now! i spent way too long fucking around with the intro to write any content after this." +
                "\nSo like, please go back and fuck with that a little. Please. Make it worth it-");
            Console.ReadKey(true);
        }

        void SpaceInput()
        {
            char c;
        }





    }
}
