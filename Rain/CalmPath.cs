using System;
using System.Collections;
using System.Collections.Generic;
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
        // “ ” <- do these work?

        private string firstDialogue =
            "A warm breeze carries the earthy smell of rainfall through the open window in your bedroom." +
            "\nYou breathe in deeply, and the rhythmic patter on your roof brings a smile to your face.";

        //Thunderbreak

        private string secondDialogue =
            "\nYou feel a strange giddiness, remembering how as a child" +
            " you would build blanket forts during a storm, reading to your stuffed animals by torchlight.";

        private string firstChoice =
            "[1] You contemplate revisiting that experience, glancing at the comfy collection of pillows and plush toys on your bed." +
          "\n[2] Maybe you’ll revisit that experience some time. For tonight, you’re going to take advantage of the energy brought on by the thunderstorm to get some work done.";

        private string[] thirdDialogue = {
            "You start to smile a big, goofy grin. Are you really...? Yes. You, a grown adult, are going to build a blanket fort. Your heart soars.",
            "Of course, no blanket fort would be complete without a childhood teddy bear, or in your case, a little blue bunny you named “Luci”.",
            "You bring Luci down from a shelf, kiss her furry head, and set her down gingerly on your bed.",
            "You need to gather materials. You decide to prioritise..."
            };

        private string secondChoice =
            "[1] Structural integrity. If you’re building a blanket fort, it’s going to be built to last." +
          "\n[2] The aesthetic. You’ll make the cosiest damn blanket fort there’s ever been.";

        //save variable: Structural or Aesthetic?

        private string[] structuralDialogue = {
            "You open the linen cupboard and choose an old bedsheet to serve as the fort’s canopy.", //add more?
            "You begin gathering blankets from throughout the house. Violet, your cat, is lazily napping on the living room couch." +
            "She takes interest in the sudden activity and wanders upstairs to see what the fuss is about.",
            "You smile at her. “Gonna build a fort with me?”" +
            "\nShe looks back at you with the biggest, dumbest eyes." +
            "\n“Don’t worry. I’ll handle the construction. You just be cozy and look cute.”"
        };

        private string[] aestheticDialogue = {
            "You place a fluffy blanket and some cushions on the floor and arrange your plushies around you.",
            "Downstairs in the living room, you take a small string of battery powered fairy lights off of a shelf." +
            "Violet, your cat, is suddenly mesmerised, and follows you (but mostly the lights) upstairs.",
            "You look at Violet and giggle. “Preeetty lights, huh baby?”" +
            "\nShe swats at them as you dangle the string back and forth in front of her."
        };

        private string fourthDialogue =
            "With all the required materials, you get to work assembling your masterpiece.";

        private string[] fifthDialogue = {
            "As night falls, finally you’ve finished." +
            "You crawl inside and onto the foam camping mattress you set up as the base, careful not to knock down the golden fairy lights twinkling against the bedsheet ceiling.",

        };
    }
}
