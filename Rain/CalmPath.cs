using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rain
{
    internal class CalmPath
    {
        #region Class References

        Formatting form = new Formatting();

        #endregion

        #region Dialogue

        // “ ” <- do these work?

        private string firstDialogue =
            "\nA warm breeze carries the earthy smell of rainfall through the open window in your bedroom." +
            "\nYou breathe in deeply, and the rhythmic patter on your roof brings a smile to your face.";

        //Thunderbreak

        private string secondDialogue =
            "\nYou feel a strange giddiness, remembering how as a child" +
            " you would build blanket forts during a storm, reading to your stuffed animals by torchlight.";

        private string firstChoice =
            "\n[1] You contemplate revisiting that experience, glancing at the comfy collection of pillows and plush toys on your bed." +
            "\n[2] Maybe you’ll revisit that experience some time. For tonight, you’re going to take advantage of the energy brought on by the thunderstorm to get some work done.";

        #region Pillow Fort

        private string[] fortDialogueOne = {
            "\nYou start to smile a big, goofy grin. Are you really...? Yes. You, a grown adult, are going to build a blanket fort. Your heart soars.",
            "\nOf course, no blanket fort would be complete without a childhood teddy bear, or in your case, a little blue bunny you named “Luci”.",
            "\nYou bring Luci down from a shelf, kiss her furry head, and set her down gingerly on your bed.",
            "\nYou need to gather materials. You decide to prioritise..."
            };

        private string fortChoiceOne =
            "\n[1] The aesthetic. You’ll make the cosiest damn blanket fort there’s ever been." +
            "\n[2] Structural integrity. If you’re building a blanket fort, it’s going to be built to last.";

        //save variable: Structural or Aesthetic?

        private string[] aestheticDialogueOne = {
            ">> The aesthetic. You’ll make the cosiest damn blanket fort there’s ever been." +
            "\n\nYou place a fluffy blanket and some cushions on the floor and arrange your plushies around you.",
            "\nDownstairs in the living room, you take a small string of battery powered fairy lights off of a shelf." +
            "\nViolet, your cat, is suddenly mesmerised, and follows you (but mostly the lights) upstairs. You look at Violet and giggle."
        };

        private string aestheticDialogueTwo =
            "\n“Preeetty lights, huh baby?”";

        private string aestheticDialogueThree =
            "\n\nShe swats at them as you dangle the string back and forth in front of her.";

        private string[] structuralDialogueOne = {
            ">> Structural integrity. If you’re building a blanket fort, it’s going to be built to last." +
            "\n\nYou open the linen cupboard and choose an old bedsheet to serve as the fort’s canopy.", //add more?
            "\nYou begin gathering blankets from throughout the house. Violet, your cat, is lazily napping on the living room couch." +
            "\nShe takes interest in the sudden activity and wanders upstairs to see what the fuss is about. You smile at her."
        };

        private string structuralDialogueTwo =
            "\n“Gonna build a fort with me?”";

        private string structuralDialogueThree =
            "\n\nShe looks back at you with the biggest, dumbest eyes.";

        private string structuralDialogueFour =
            "\n“Don’t worry. I’ll handle the construction. You just be cozy and look cute.”\n";

        private string fortDialogueTwo =
            "\nWith all the required materials, you get to work assembling your masterpiece.";

        //time skip transition wut?

        private string[] fortDialogueThree = {
            "\nAs night falls, you've finally finished.",
            "\nYou crawl inside and onto the foam camping mattress you set up as the base, careful not to knock down the golden fairy lights twinkling against the bedsheet ceiling.",
            "\nThe mattress is covered in fluffy blankets and as many pillows and cushions you could scrounge from across the house.",
            "\nYour plush toys are scattered throughout, all on their own cozy little adventures.",
            "\nYou lay back and just enjoy the atmosphere for a moment.",
            "\nThe rain battering the tin roof of your house...  the thunder still rolling in, gradually louder and more intense... ", //do smth fun with these?
            "\nYou sigh contentedly. All that’s missing is Luci... but you’ll get her in a second."
        };

        private string[] fortDialogueFour = {
            "\n\nBeyond the walls of the cubby, you hear a slight pop... and it suddenly seems a lot brighter in here, and a lot darker out there.",
            "\nYou crawl out through the pillowcase door for a moment.",
            "\nAh. The power’s gone out. On the bright side, the fairy lights are still going strong- thank God for batteries.",
            "\nHm... at some point while assembling the fort, you lost track of Violet. You should call her up so you can keep an eye on her."
        };

        private string fortDialogueFive =
            "\n“Vi! Violet?”";

        private string[] fortDialogueFiveTwo = {
            "\n\nYou call out for her a few times, between making the appointed, cat summoning kissy-noises.",
            "\nYour bedroom door pushes open and Violet slinks in, head held high.",
            "\n...Is there something in her mouth?",
            "\nYou turn on your phone torch to get a better look..."
        };

        private string fortDialogueSix =
            "\nInside Violet’s mouth, she carries a small, stuffed bunny. You feel your heart skip in your chest.";

        private string fortDialogueSixTwo =
            "\n“Luci! Oh my god!”";

        private string fortDialogueSixThree =
            "\n\nYou grab Luci away from Violet, scolding her half-heartedly.";

        private string fortDialogueSixFour =
            "\n“Bad kitty...”";

        private string[] fortDialogueSixFive = {
            "\n\nYou look at your beloved little bunny - your first friend.",
            "\nYou’ve been there for each other since you can remember: playing, laughing, crying, and growing up together.",
            "\nWhen your friends cast aside their toys and declared themselves “too old for that”, you decided that no matter how old you got, you would never outgrow her.",
            "\nYou gently turn her over in your hands, examining the damage...",
            "\nHer fur is damp and matted, and stuffing falls loosely from the side of her head where one of her floppy ears used to be."
        };
        private string fortDialogueSixSix =
            "\n“I’m so sorry, darling...”";

        private string fortDialogueSixSeven =
            "\n\nYour voice is choked and soft, and a scattering of tears run down your cheeks.";

        private string[] fortDialogueSeven = {
            "\n\nYou walk downstairs to check Vi’s favourite spots for the missing ear.",
            "\nYou find it where you expect, on the couch: slightly damp and mangled, but otherwise intact.",
            "\nYou take a shaky breath as you look down at them, Luci in one hand and her forlorn ear in the other."
        };

        private string fortChoiceTwo =
            "\n[1] You’re going to try to fix her. It’s the least you can do for her after all these years." +
            "\n[2] You won’t try to fix her. She’s perfect the way she is, scars and all.";

        //save variable: Repair or Accept?

        private string repairDialogue =
            ">> You’re going to try to fix her. It’s the least you can do for her after all these years." +
            "\n\nYou wipe the tears from your eyes, feeling suddenly resolute.";

        private string repairDialogueTwo =
            "\n“I guess it’s time for surgery.”"; //lightning here?

        private string[] repairDialogueThree = {
            "\n\nYou grab a mini sewing kit from inside your desk, and bring Luci and her ear into the fort.",
            "\nWith the power out, the fairy lights provide the best visibility... and their gentle light is reassuring. You hope it is for Luci too."
        };

        private string repairDialogueFour =
            "\n“You'll be better in no time, darling.”";

        private string[] repairDialogueFive = {
            "\n\n\nCalling upon all of your tenth grade textiles knowledge, you delicately attempt to reattach her ear.",
            "\nMore than a few times you have to spend several minutes re-threading the needle after fumbling it, and by the end the tips of your fingers are tender with the effort.",
            "\nThe eventual result is... amateurish, almost a little Frankenstein-y. But she’s your Luci, whole again.",
            "\nYou hug her, kissing her little head once more, and lay back together with her."
        };

        private string[] acceptDialogue = {
            "\nYou bring Luci back up to your room and into the fort. You feel a twinge of sadness looking at her.",
            "\nGently you tuck a little of her stuffing back in, and smooth out her fur with your fingertips as best you can.",
            "\nIn the morning you’ll close up her wound, but for right now... you just hold her close to your chest, and lay back into the pillows.",
            "\nThe rain still beats against the roof. Everything smells of wet concrete and ozone now, the open window letting in the finally-cool night air.",
            "\nYou breathe it in, and your heartbeat settles into a consistent rhythm. With eyes closed you listen to the rolling thunder, gradually moving further into the distance."
        };

        private string fortDialogueFinal =
            "\nThere’s some movement at your ad-hoc doorway as Violet slinks into the fort and sits down. She looks at you for a moment.";

        private string fortDialogueFinalTwo =
            "\n“Yeah, I know. You’re sorry.”";

        private string fortDialogueFinalThree =
            "\n\nVi flicks her tail and pads across the cubby to settle down comfortably on one of the cushions, brushing up against you on her way.";

        private string fortDialogueFinalFour =
            "\n“It’s okay. I love you both ";
        private string fortDialogueFinalFourTwo =
            "no matter what.”";

        private string[] fortDialogueFinalFive = {
            "\n\nThe storm rages on outside, and you’re safe in your fort.",
            "\nViolet purrs steadily, curled up for the night.",
            "\nYou feel a wave of tiredness wash over you, and you hold your battle-hardened childhood toy close.",
            "\nYou drift off to sleep under the twinkling lights, with a smile on your face and love in your heart."
        };

        private string fortDialogueFinalSix =
            "\nThis has been a good night."; //emphasise!

        #endregion

        #region Motivation



        #endregion

        //THE END

        #endregion

        #region Scene Functions

        /*
         * Console.WriteLine();
         * Console.ReadKey(true);
         * Console.Clear();
        */

        public void CalmOne()
        {
            Console.WriteLine(firstDialogue);
            SpaceInput();
            form.LightningStrike("An abrupt peal of thunder cracks like a whip above the deafening rain. Your windowpanes shudder as the noise reverberates.");
            SpaceInput();
            Console.WriteLine(secondDialogue);
            SpaceInput();
            Console.WriteLine(firstChoice);
            FirstChoice();
            
            if (PathData.cozyOrMotivated == "Motivated")
            {
                Console.WriteLine("\n(I haven't programmed this path yet, sorry!)");
                SpaceInput();
                Console.WriteLine("(Returning you to the other path...)");
                SpaceInput();
            }
            //else if (PathData.cozyOrMotivated == "Cozy") {this needs to be enabled once we have more than one path here}

            foreach (string line in fortDialogueOne)
            {
                Console.WriteLine(line);
                SpaceInput();
            }

            Console.WriteLine(fortChoiceOne);
            SecondChoice();
            Console.Clear();
            if (PathData.aestheticOrStructural == "Aesthetic")
            {
                foreach (string line in aestheticDialogueOne)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }
                form.WriteDelayedLine(aestheticDialogueTwo, TimeSpan.FromMilliseconds(20), 4);
                Console.WriteLine(aestheticDialogueThree);
                SpaceInput();
            }
            else if (PathData.aestheticOrStructural == "Structural")
            {
                foreach (string line in structuralDialogueOne)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }
                form.WriteDelayedLine(structuralDialogueTwo, TimeSpan.FromMilliseconds(20), 4);
                Console.WriteLine(structuralDialogueThree);
                SpaceInput();
                form.WriteDelayedLine(structuralDialogueFour, TimeSpan.FromMilliseconds(10), 4);
            }

            Console.WriteLine(fortDialogueTwo);
            SpaceInput(); //transition?
            Console.Clear();
            form.WriteDelayedLine(". . .\n", TimeSpan.FromMilliseconds(10), 50);
            foreach (string line in fortDialogueThree)
            {
                Console.WriteLine(line);
                SpaceInput();
            }           
            foreach (string line in fortDialogueFour)
            {
                Console.WriteLine(line);
                SpaceInput();
            }
            form.WriteDelayedLine(fortDialogueFive, TimeSpan.FromMilliseconds(10), 4);
            foreach (string line in fortDialogueFiveTwo)
            {
                Console.WriteLine(line);
                SpaceInput();
            }

            Console.Clear();
            form.WriteDelayedLine(". . .\n", TimeSpan.FromMilliseconds(10), 50);

            Console.WriteLine(fortDialogueSix);
            SpaceInput();
            form.WriteDelayedLine(fortDialogueSixTwo, TimeSpan.FromMilliseconds(10), 4);
            Console.WriteLine(fortDialogueSixThree);
            SpaceInput();
            form.WriteDelayedLine(fortDialogueSixFour, TimeSpan.FromMilliseconds(10), 4);
            foreach (string line in fortDialogueSixFive)
            {
                Console.WriteLine(line);
                SpaceInput();
            }
            form.WriteDelayedLine(fortDialogueSixSix, TimeSpan.FromMilliseconds(10), 4);
            Console.WriteLine(fortDialogueSixSeven);
            SpaceInput();
            foreach (string line in fortDialogueSeven)
            {
                Console.WriteLine(line);
                SpaceInput();
            }

            Console.WriteLine(fortChoiceTwo);
            ThirdChoice();
            Console.Clear();

            if (PathData.repairOrAccept == "Repair")
            {
                Console.WriteLine(repairDialogue);
                SpaceInput();
                form.LightningStrikeAlt();
                Console.WriteLine(repairDialogue);
                form.WriteDelayedLine(repairDialogueTwo, TimeSpan.FromMilliseconds(10), 4);                
                foreach (string line in repairDialogueThree)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }
                form.WriteDelayedLine(repairDialogueFour, TimeSpan.FromMilliseconds(10), 4);
                foreach (string line in repairDialogueFive)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }
            }
            else if (PathData.repairOrAccept == "Accept")
            {
                foreach (string line in acceptDialogue)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }
            }

            Console.WriteLine(fortDialogueFinal);
            SpaceInput();
            form.WriteDelayedLine(fortDialogueFinalTwo, TimeSpan.FromMilliseconds(10), 4);
            Console.WriteLine(fortDialogueFinalThree);
            SpaceInput();
            form.WriteDelayedLine(fortDialogueFinalFour, TimeSpan.FromMilliseconds(10), 4);
            form.CDGreen();
            form.WriteDelayedLine(fortDialogueFinalFourTwo, TimeSpan.FromMilliseconds(10), 4);
            form.CDefault();
            foreach (string line in fortDialogueFinalFive)
            {
                Console.WriteLine(line);
                SpaceInput();
            }
            form.CDGreen();
            Console.WriteLine(fortDialogueFinalSix);
            SpaceInput();
            Console.Clear();
            Console.WriteLine("\n     THE END <3");
            SpaceInput();

        }


        #endregion

        #region Input Functions

        //func to progress narrative
        //proceeds on spacebar, ignores all other inputs
        void SpaceInput()
        {
            bool paused = true; //'pause' the narrative
            do //the thing once
            {
                char c = Console.ReadKey(true).KeyChar; //get the key that's pressed
                if (c == ' ') { paused = false; }         //if it's space, 'unpause' the narrative

            } while (paused); //keep doing it if (paused == true)   
        }

        void FirstChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.cozyOrMotivated = "Cozy";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.cozyOrMotivated = "Motivated";
                        break;                  
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        void SecondChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.aestheticOrStructural = "Aesthetic";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.aestheticOrStructural = "Structural";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }
        void ThirdChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.repairOrAccept = "Repair";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.repairOrAccept = "Accept";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        #endregion
    }
}
