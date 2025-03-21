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
            "She takes interest in the sudden activity and wanders upstairs to see what the fuss is about. You smile at her.",
            "“Gonna build a fort with me?”",
            "She looks back at you with the biggest, dumbest eyes.",
            "“Don’t worry. I’ll handle the construction. You just be cozy and look cute.”"
        };

        private string[] aestheticDialogue = {
            "You place a fluffy blanket and some cushions on the floor and arrange your plushies around you.",
            "Downstairs in the living room, you take a small string of battery powered fairy lights off of a shelf." +
            "Violet, your cat, is suddenly mesmerised, and follows you (but mostly the lights) upstairs. You look at Violet and giggle.",
            "“Preeetty lights, huh baby?”",
            "She swats at them as you dangle the string back and forth in front of her."
        };

        private string fourthDialogue =
            "With all the required materials, you get to work assembling your masterpiece.";

        //time skip transition wut?

        private string[] fifthDialogue = {
            "As night falls, you've finally finished.",
            "You crawl inside and onto the foam camping mattress you set up as the base, careful not to knock down the golden fairy lights twinkling against the bedsheet ceiling.",
            "The mattress is covered in fluffy blankets and as many pillows and cushions you could scrounge from across the house.",
            "Your plush toys are scattered throughout, all on their own cozy little adventures.",
            "You lay back and just enjoy the atmosphere for a moment.",
            "The rain battering the tin roof of your house...  the thunder still rolling in, gradually louder and more intense... ", //do smth fun with these?
            "You sigh contentedly. All that’s missing is Luci... but you’ll get her in a second."
        };

        private string[] sixthDialogue = {
            "Beyond the walls of the cubby, you hear a slight pop... and it suddenly seems a lot brighter in here, and a lot darker out there.",
            "You crawl out through the pillowcase door for a moment.",
            "Ah. The power’s gone out. On the bright side, the fairy lights are still going strong- thank God for batteries.",
            "Hm... at some point while assembling the fort, you lost track of Violet. You should call her up so you can keep an eye on her."
        };

        private string[] seventhDialogue = {
            "“Vi! Violet?”",
            "You call out for her a few times, between making the appointed, cat summoning kissy-noises.",
            "Your bedroom door pushes open and Violet slinks in, head held high",
            "...Is there something in her mouth?",
            "You turn on your phone torch to get a better look..."
        };

        private string[] eigthDialogue = {
            "Inside Violet’s mouth, she carries a small, stuffed bunny.",
            "You feel your heart skip in your chest", //delay?
            "“Luci! Oh my god!”",
            "You grab Luci away from Violet, scolding her half-heartedly.",
            "“Bad kitty...”",
            //extra new line?
            "You look at your beloved little bunny - your first friend.",
            "You’ve been there for each other since you can remember: playing, laughing, crying, and growing up together.",
            "When your friends cast aside their toys and declared themselves “too old for that”, you decided that no matter how old you got, you would never outgrow her.",
            //extra new line?
            "You gently turn her over in your hands, examining the damage...",
            "Her fur is damp and matted, and stuffing falls loosely from the side of her head where one of her floppy ears used to be.",
            "“I’m so sorry, darling...”",
            "Your voice is choked and soft, and a scattering of tears run down your cheeks."
        };

        private string[] tenthDialogue = {
            "You walk downstairs to check Vi’s favourite spots for the missing ear.",
            "You find it where you expect, on the couch: slightly damp and mangled, but otherwise intact.",
            "You take a shaky breath as you look down at them, Luci in one hand and her forlorn ear in the other."
        };

        private string thirdChoice =
            "[1] You’re going to try to fix her. It’s the least you can do for her after all these years." +
          "\n[2] You won’t try to fix her. She’s perfect the way she is, scars and all.";

        private string[] repairDialogue = {
            "You wipe the tears from your eyes, feeling suddenly resolute.",
            "“I guess it’s time for surgery.”", //lightning here?
            "You grab a mini sewing kit from inside your desk, and bring Luci and her ear into the fort.",
            "With the power out, the fairy lights provide the best visibility... and their gentle light is reassuring. You hope it is for Luci too.",
            "“You'll be better in no time, darling.”"
        };
    }
}
