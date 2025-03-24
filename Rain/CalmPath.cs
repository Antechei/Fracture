using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
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
            "\n[2] Maybe you’ll revisit that experience some time. For tonight, you’re going to take advantage of the extra energy brought on by the thunderstorm to get some more work done.";

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

        private string[] motiDialogueOne = {
            "\nYour eyes return to the project open on your screen. You’ve already been working for a couple hours tonight, after finally hitting the flow state you’d been searching for all week.",
            "\nYou reach for the mug resting at the edge of your desk..."
        };

        //do the hypothetical project choice thing here

        private string motiFirstChoice =
            "\n[1] It’s a cup of tea." +
            "\n[2] It’s a cup of coffee.";

        private string[] motiDialogueTwo() {
            string[] lines = {
                "\nYou take a sip. The warmth of the " + PathData.teaOrCoffee + " relaxes you to your core.",
                "\nYou let out a deep, involuntary sigh-- and realise you probably look like you’re in a commercial.",
                "\nYou smile and scoff at yourself, returning to your work."
            };
            return lines; // grrr c# syntax hates my paws
        }

        // ... delay?

        private string[] motiDialogueThree() {
            string[] lines = {
                "\n\nHalf an hour passes, and you’re making good progress between intermittent sips of " + PathData.teaOrCoffee + ".",
                "\nYou reach for the mug once more, when suddenly a deafening thunderclap startles you."
            };
            return lines;
        }

        //lightning

        private string[] motiDialogueFour() {
            string[] lines = {
                "\nNearly jumping out of your seat, you send the mug and its contents flying.",
                "\nYour " + PathData.teaOrCoffee + " splashes across the power board connected to your PC, and something inside crackles and pops ominously.", //emphasise pops?
                "\nYour screen goes dark. What now?"
            };
            return lines;
        }

        private string motiSecondChoice =
            "\n[1] Well, heck. You should probably do something." +
            "\n[2] Stay completely still. Maybe if you don’t do anything, it’ll start working again."; //emphasise 'something' and 'anything'

        private string hopeDialogueOne =
            "\n>> Stay completely still. Maybe if you don’t do anything, it’ll start working again." +
            "\n\nAaaand";
        private string hopeDialogueTwo =
            "\n......";
        private string hopeDialogueTwoTwo =
            "\n\nNope. :(";

        private string motiSecondChoiceTwo =
            "\n[1] >> Well, heck. You should probably do something. <<" + //emphasise 'something'
            "\n[2] Maybe you didn’t stay frozen long enough. Try again?";

        // if hope 2, ... delay

        private string[] hopeDialogueThree = {
            "\n>> Maybe you didn’t stay frozen long enough. Try again?" +
            "\n\nOh?",
            "\n[1] What’s this?"
        };
        //hope2 input
        private string[] hopeDialogueFour = {
            "\nIt’s working again! Your screen flashes back on.",
            "\n[1] Hell yes! Really?!"
        };
        //hope2 input
        private string[] hopeDialogueFive ={
            "\nNo, not really... It’s still broken. Was worth a try, though!",
            "\n[1] Well, heck. Now you really should do something about it." //emphasis 'really should do something'
        };

        private string[] MotiDialogueFiveHope() {
            string[] lines = {
            "\n>> Well, heck. Now you really should do something about it." +
            "\n\nYou set about cleaning up the mess, removing as much of the " + PathData.teaOrCoffee + " as possible from your power board with some towels. The poor thing is quite gunked up.",
            "\nAfter you clean up, your mind immediately goes to your older sister, who generally knows about This Kind Of Stuff.",
            "\nYou pick up your phone and dial her number."
            };
            return lines;
        }

        private string[] MotiDialogueFiveAct() {
            string[] lines = {
            "\n>> Well, heck. You should probably do something." +
            "\n\nYou set about cleaning up the mess, removing as much of the " + PathData.teaOrCoffee + " as possible from your power board with some towels. The poor thing is quite gunked up.",
            "\nAfter you clean up, your mind immediately goes to your older sister, who generally knows about This Kind Of Stuff.",
            "\nYou pick up your phone and dial her number."
            };
            return lines;
        }

        // ... delay

        private string[] motiDialogueSix() {
            string[] lines = {
                "\n\nShe picks up after a few rings.\n", //0
                "“Hey!”\n", //1
                "\n“Hey.....”\n", //2
                "\n“Everything all good?”\n", //3
                "\nYou hesitate, taking a moment to prepare yourself for the inevitable older sibling sass. Maybe you didn't think this through...\n", //4
                "“Yeah...?”\n", //5
                "\n“You know I can hear you cringing from here, you goober. What’s up?”\n", //6
                "\n“Well I... Ikindaspilledamugof" + PathData.teaOrCoffee + "onmydeskandnowmycomputersbroken-”\n", //7 //shorter than usual delay
                "\nThe words come out all in a rush, and your sister is chuckling before you've even finished speaking.\n", //8
                "“Sorry, sorry... lets try a little slower: you did what?”\n", //9
                "\n“I SAID: I kinda spilled a mug of " + PathData.teaOrCoffee + " on my desk and now my computer’s broken!”\n", //10
            };
            return lines;
        }

        private string[] motiDialogueSeven = {
            "\nYou explain the situation to your sister, and she advises you (after she’s spent a couple minutes laughing at your expense) " +
            "not to try anything before you’ve replaced the power board.",
            "\nWith one last laugh, she wishes you good luck, and you thank her before hanging up.",
            "\nThe only problem is, you can’t remember where a spare power board might be...",
        };

        private string motiChoiceThree =
            "\n[1] Maybe in the garage? You probably have one sitting in a box." +
            "\n[2] Possibly in the hallway cupboards. That’s where you put everything you don’t know what to do with, after all.";

        // Variable: Garage or Hallway

        private string[] garaDialogueOne = {
            "\n>> Maybe in the garage? You probably have one sitting in a box." +
            "\n\nYou walk downstairs and through the door to the garage. It smells faintly of oil, petrol, and the old tools your dad gave you.",
            "\nYou flick on the lights, some old fluorescents, which take a second to warm-up. A shelving unit with a bunch of unlabelled plastic containers sit against the far wall.",
            "\nYou may as well start at the top and work your way down...\n"
        };

        //delay ...

        private string garaDialogueTwo =
            "\n\nAfter searching fruitlessly through a few boxes, you open one full of power cables: Old chargers, network cables, extension cords, and power boards.";

        private string garaDialogueThree =
        "\n“Yesss!”\n";

        private string[] garaDialogueFour = {
            "\nYou dig one of them out of the box and set it aside.",
            "\nAs you begin to tidy up the mess your search created, the fluorescent lights above you go dead, and the quiet, ambient hum of the house's electronics falls silent."
        };

        private string[] garaDialogueFive = {
            "\nLuckily, your household had the presence of mind to keep a headlamp in the garage for just these situations.",
            "\nYou retrieve it from a nearby shelf (nearly tripping over the remaining mess in the process- whoops!) and put it on. It makes you feel cool, like someone who digs for treasure.",
            "\nWell, you found a power board... but now you have bigger problems."
        };

        private string[] hallDialogueOne = {
            "\n>> Possibly in the hallway cupboards. That’s where you put everything you don’t know what to do with, after all." +
            "\n\nYou retrieve a stepladder from the laundry and begin scouring through the hallway cupboards.",
            "\nRiffling through years of ephemera, you find Christmas decorations, Halloween costumes, and even few small instruments, which you don’t remember ever being used.",
            "\nBut no power boards. They’re probably in the garage after all...",
            "\nYou do find a kazoo among the aforementioned instruments, though."
        };

        private string hallChoiceOne =
            "\n[1] This will totally come in handy." +
            "\n[2] Now is not the time for kazoos!";

        // kazoo variable

        private string[] kazooDialogue = {
            "\nYou put the kazoo in your mouth as you dismount the stepladder. So far, you have found one kazoo, and zero powerboards.",
            "\nYou hum a mournful tune, like the music that plays when someone gets an answer wrong on a gameshow. Which you don’t watch. Obviously.",
            "\n...As if cued by your song, all the lights in the house go dark.",
            "\nYou feel like this is cosmic retribution for taking the kazoo, but you don’t know for sure. You put it in your pocket nevertheless."
        };

        private string[] noKazooDialogue = {
            "\nYou discard the kazoo, demoralised by your fruitless search. Goddamn it. You just want to know if the last two hours of your work was saved.",
            "\nTo make matters worse, suddenly all the lights in the house flicker off."
        };

        private string[] hallDialogueTwo = {
            "\nWith a steadying breath, you dismount the stepladder.",
            "\nYou carefully make your way to the garage, occasionally stumbling over random furniture, and only stubbing your toes really badly one time.",
            "\nIn the garage, you retrieve the headlamp that’s kept for these sorts of situations. You feel a little better equipped now that you’re not wandering around in the dark.",
            "\n...Your foot hurts, though.",
            "\nWell... with the power entirely out, finding a power board is a bit pointless!"
        };

        private string[] motiDialogueEight = {
            "\nYou leave the garage and find your cat, Violet, sitting on the couch.",
            "\nThe headlamp you’re wearing shines in her perfect little face, and she runs off somewhere else.\n",
            "”Oops. Sorry, Vi...”\n",
        };

        // elle note long first line?
        private string[] motiDialogueNine = {
            "\nYou switch it off and sit down at the edge of the couch, losing yourself staring out the living room window for a moment. The rain outside is heavy enough now to be visible, even in the dark.",
            "\nThe wind whips it around into mesmerising patterns, and occasionally a flash of lightning will illuminate the whole scene in stark blue-white contrast.",
            "\nYou watch it mindlessly, contemplating your options."
        };

        private string motiChoiceFour =
            "\n[1] You need to try and fix this. You’re in far too deep to quit now. Go outside and check the breaker box." +
            "\n[2] This can all be tomorrow’s problem. The storm is too nice to waste on stressing out about it.";

        // var Tonight or Tomorrow
        //lightning?

        private string[] toniDialogueOne = {
            "\n>> You need to try and fix this. You’re in far too deep to quit now. Go outside and check the breaker box." +
            "\n\n- and hey, maybe getting soaked to the bone will improve your mood. Somehow.",
            "\nYou flick your headlamp back on and open the back door. Walking around the side of the house, you're immediately caught in the full force of the storm.",
            "\nWithin a few steps, you're totally drenched and starting to shiver in the cold. God, wasn't it stiflingly warm just a few hours ago?",
            "\nYou reach the breaker box and yank it open, and begin flipping switches- any switches, really, to see if anything happens. Totally advisable during a thunderstorm.",
            "\n...Nothing happens. It occurs to you to walk out and check if the other houses on the street have their lights on.",
            "\nWith an awkward half-run across the soggy concrete, you duck into the front yard. Standing in your driveway, you see that the entire neighbourhood has gone dark.",
            "\nYou just stand there for a moment in the wind and the rain. There’s nothing you can do, then."
        };

        private string[] toniDialogueTwo = {
            "\n...Nothing except go back inside and dejectedly trudge upstairs.",
            "\nSnatching a towel from the bathroom you attempt to towel yourself off, with no particular energy or success.",
            "\nIt’d probably be a good idea to change out of these clothes, but you can’t quite summon the motivation.",
            "\nInstead you just sit on the edge of your bed, staring at nothing and shivering lightly. The rain beats against the house around you for a long minute.",
            "\nAfter a while, your bedroom door pushes open as Violet walks in, looking at you curiously. She stops in front of your bed, rears back, and jumps up next to you.",
            "\nYou nearly push her away in frustration when she struts across your lap, arching her back and mewing politely for attention. But she doesn’t deserve that.",
            "\nInstead your extend your hand, running it through her silky fur and letting her push her face against you happily. The mews quickly turn into a soft purr.",
            "\nShe sniffs your shirt curiously, which is still quite wet from the rain... then screws up her face and sneezes. You laugh quietly.\n"
        };

        private string toniDialogueThree =
            "“Thanks for cheering me up, Vi. I can always count on you to be a bit of a goofball, huh?”";

        private string[] toniDialogueFour = {
            "\n\nAfter hanging out with Violet for a bit, you eventually feel restored enough to change into your pyjamas, getting properly dry and settling into bed.",
            "\nToday didn’t really go how you wanted it to. But that’s alright...",
            " there’s always tomorrow.\n",
            "As the storm finally begins to settle into a softer melody, you drift off to sleep with Vi purring- and then softly snoring- at your side."
        };

        private string toniDialogueFinal =
            "\nIt wasn’t the lovely night you planned... but perhaps you've learned something from that."; //colour

        private string[] tomoDialogueOne = {
            "\n>> This can all be tomorrow’s problem. The storm is too nice to waste on stressing out about it." +
            "\n\nYeah... time to go upstairs, try to relax, and deal with things in the morning.",
            "\nYou feel conflicted for a moment at the idea of letting yourself off the hook, after all that effort... but with a deep breath it morphs into an immense relief.",
            "\nYou remember how happy you felt when the rain broke earlier tonight. Where did that all go?",
            "\nYou got so caught up in trying to solve problem after problem, you barely got to relax and enjoy the weather. Well... perhaps there's still time to do something about that.",
            "\nWith the weight off your shoulders, you walk back upstairs to your room, Violet appearing from somewhere to follow inquisitively behind you.",
            "\nYou tried your best to be productive... now you’re going to let yourself relax, and enjoy what's left of the night. And you think you have exactly the thing.",
            "\nYou retrieve a handful of tea candles from a drawer in your desk and scatter them around the room," +
            " watching the shadows dance around the walls with your movement as you light each one.",
            "\nGrabbing a book, you curl up on your bed. The rain continues to loudly batter the tin roof of your house.",
            "\nVi performs the biggest yawn you’ve ever seen, and curls up to cuddle next to you. With a comfortable sigh and a smile, you gently scritch the fur between her ears, eliciting a rumbling purr.",
            "\nThe only thing left to do is open your book and settle in.\n"
        };

        //delay ... and clear (?)

        private string[] tomoDialogueTwo = {
            "\n\nA couple hours later, the first of your tea candles fades and gutters out with a curling wisp of smoke. The others look like they’re not far behind.",
            "\nYou perform a big stretch and yawn of your own, closing the book and setting it down next to you.",
            "\nBy now, the storm has settled into a soft melody, with the occasional rumble of thunder far away in the distance. " +
            "You smile and giggle to yourself a little, still enjoying the ambience.",
            "\nGetting up to extinguish the rest of your hard-working candles and change into your pyjamas, you figure it’s time to get some sleep yourself.",
            "\nYou settle back into bed next to Vi, and find yourself getting drowsy within a couple minutes.",
            "\nOne way or another, it all worked out in the end. You drift away to sleep, lulled by the sound of the rain."
        };

        private string tomoDialogueFinal =
            "\nIt wasn’t what you planned. But it was still a lovely night."; //colour

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
                foreach (string line in motiDialogueOne)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                Console.WriteLine(motiFirstChoice);
                FirstMotiChoice();

                foreach (string line in motiDialogueTwo())
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                Console.Clear();
                form.WriteDelayedLine(". . .", TimeSpan.FromMilliseconds(10), 50);

                foreach (string line in motiDialogueThree())
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                form.LightningStrikeAlt();
                Console.Write(". . .");
                foreach (string line in motiDialogueThree())
                {
                    Console.WriteLine(line);
                }

                foreach (string line in motiDialogueFour())
                {
                    Console.WriteLine(line);
                    SpaceInput();

                    // emphasise pops
                }

                Console.WriteLine(motiSecondChoice);
                SecondMotiChoice();
                Console.Clear();

                if (PathData.actOrHope == "Hope")
                {
                    Console.WriteLine(hopeDialogueOne);
                    SpaceInput();
                    form.WriteDelayedLine(hopeDialogueTwo, TimeSpan.FromMilliseconds(10), 32);
                    Console.WriteLine(hopeDialogueTwoTwo);
                    SpaceInput();
                    Console.WriteLine(motiSecondChoiceTwo);
                    SecondMotiChoiceTwo();
                    Console.Clear();

                    if (PathData.actOrHope == "Hope2")
                    {
                        // elle note added the foreach
                        Console.WriteLine(hopeDialogueThree[0]);
                        SpaceInput();
                        Console.WriteLine(hopeDialogueThree[1]);
                        NumOneInput();
                        Console.WriteLine(hopeDialogueFour[0]);
                        SpaceInput();
                        Console.WriteLine(hopeDialogueFour[1]);
                        NumOneInput();
                        Console.WriteLine(hopeDialogueFive[0]);
                        SpaceInput();
                        Console.WriteLine(hopeDialogueFive[1]);
                        NumOneInput();
                        Console.Clear();
                        foreach (string line in MotiDialogueFiveHope())
                        {
                            Console.WriteLine(line);
                            SpaceInput();
                        }
                    }
                    else
                    {
                        foreach (string line in MotiDialogueFiveAct())
                        {
                            Console.WriteLine(line);
                            SpaceInput();
                        }
                    }
                }
                else
                {
                    foreach (string line in MotiDialogueFiveAct())
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }
                }

                Console.Clear();
                form.WriteDelayedLine(". . .", TimeSpan.FromMilliseconds(10), 50);

                var motiSix = motiDialogueSix();
                Console.WriteLine(motiSix[0]);
                SpaceInput();
                form.CPurple(); form.WriteDelayedLine(motiSix[1], TimeSpan.FromMilliseconds(10), 4); // hey
                form.CDefault(); form.WriteDelayedLine(motiSix[2], TimeSpan.FromMilliseconds(10), 4); // hey
                form.CPurple(); form.WriteDelayedLine(motiSix[3], TimeSpan.FromMilliseconds(10), 4); // everything good?
                form.CDefault(); Console.WriteLine(motiSix[4]);
                SpaceInput();
                form.WriteDelayedLine(motiSix[5], TimeSpan.FromMilliseconds(10), 4); // yeah
                form.CPurple();form.WriteDelayedLine(motiSix[6], TimeSpan.FromMilliseconds(10), 4); // cringe
                form.CDefault(); form.WriteDelayedLine(motiSix[7], TimeSpan.FromMilliseconds(10), 2); // spill
                Console.WriteLine(motiSix[8]);
                SpaceInput();
                form.CPurple(); form.WriteDelayedLine(motiSix[9], TimeSpan.FromMilliseconds(10), 4); // use your words puppy
                form.CDefault(); form.WriteDelayedLine(motiSix[10], TimeSpan.FromMilliseconds(10), 4); // spill


                foreach (string line in motiDialogueSeven)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                Console.WriteLine(motiChoiceThree);
                ThirdMotiChoice();
                Console.Clear();

                if (PathData.garageOrHallway == "Garage")
                {
                    foreach (string line in garaDialogueOne)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }

                    form.WriteDelayedLine(". . .", TimeSpan.FromMilliseconds(10), 50);

                    Console.WriteLine(garaDialogueTwo);
                    SpaceInput();

                    // elle zone begin here sorry hana

                    form.WriteDelayedLine(garaDialogueThree, TimeSpan.FromMilliseconds(10), 4);

                    foreach (string line in garaDialogueFour)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }

                    foreach (string line in garaDialogueFive)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }
                }
                else if (PathData.garageOrHallway == "Hallway")
                {
                    foreach (string line in hallDialogueOne)
                    {
                        Console.WriteLine(line);    
                        SpaceInput();
                    }

                    Console.WriteLine(hallChoiceOne);
                    FirstHallChoice();

                    // Console.Clear(); // elle - hmmm?
                    if (PathData.kazooOrNoKazoo == "Kazoo")
                    {
                        foreach (string line in kazooDialogue)
                        {
                            Console.WriteLine(line);
                            SpaceInput();
                        }
                    }
                    else if (PathData.kazooOrNoKazoo == "NoKazoo")
                    {
                        foreach (string line in noKazooDialogue)
                        {
                            Console.WriteLine(line);
                            SpaceInput();
                        }
                    }
                    // paths kazzoo/no kazzoo merge
                    foreach (string line in hallDialogueTwo)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }
                }
                // paths garage/hallway merge

                Console.WriteLine(motiDialogueEight[0]);
                SpaceInput();
                Console.WriteLine(motiDialogueEight[1]);
                SpaceInput();
                form.WriteDelayedLine(motiDialogueEight[2], TimeSpan.FromMilliseconds(10), 4);


                foreach (string line in motiDialogueNine)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                Console.WriteLine(motiChoiceFour);
                FourthMotiChoice();
                Console.Clear();

                if (PathData.tonightOrTomorrow == "Tonight")
                {
                    foreach (string line in toniDialogueOne)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }
                    foreach (string line in toniDialogueTwo)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }

                    form.WriteDelayedLine(toniDialogueThree, TimeSpan.FromMilliseconds(10), 4);

                    Console.WriteLine(toniDialogueFour[0]);
                    SpaceInput();
                    Console.Write(toniDialogueFour[1]);
                    SpaceInput();
                    form.CDGreen();
                    Console.WriteLine(toniDialogueFour[2]);
                    SpaceInput();
                    form.CDefault();
                    Console.WriteLine(toniDialogueFour[3]);
                    SpaceInput();
                    form.CDGreen();
                    Console.WriteLine(toniDialogueFinal);
                    SpaceInput();

                }
                else if (PathData.tonightOrTomorrow == "Tomorrow")
                {
                    foreach (string line in tomoDialogueOne)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }

                    form.WriteDelayedLine(". . .", TimeSpan.FromMilliseconds(10), 50);

                    foreach (string line in tomoDialogueTwo)
                    {
                        Console.WriteLine(line);
                        SpaceInput();
                    }

                    form.CDGreen();
                    Console.WriteLine(tomoDialogueFinal);
                    SpaceInput();
                }
                // choice tonight/tomorrow merges
                // the end
            }

            //------------ OTHER PATH ----------------

            else if (PathData.cozyOrMotivated == "Cozy")
            {
                foreach (string line in fortDialogueOne)
                {
                    Console.WriteLine(line);
                    SpaceInput();
                }

                Console.WriteLine(fortChoiceOne);
                FirstFortChoice();
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
                SecondFortChoice();
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
            }
            // paths motivated/cozy merge
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
        void NumOneInput()
        {
            bool paused = true; //'pause' the narrative
            do //the thing once
            {
                char c = Console.ReadKey(true).KeyChar; //get the key that's pressed
                if (c == '1') { paused = false; }         //if it's 1, 'unpause' the narrative

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

        void FirstFortChoice()
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
        void SecondFortChoice()
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

        void FirstMotiChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.teaOrCoffee = "tea";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.teaOrCoffee = "coffee";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        void SecondMotiChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.actOrHope = "Act";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.actOrHope = "Hope";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        void SecondMotiChoiceTwo()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.actOrHope = "Act";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.actOrHope = "Hope2";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        void ThirdMotiChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.garageOrHallway = "Garage";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.garageOrHallway = "Hallway";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }


        void FourthMotiChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.tonightOrTomorrow = "Tonight";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.tonightOrTomorrow = "Tomorrow";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        void FirstHallChoice()
        {
            bool numSelect = true;
            do
            {
                char c = Console.ReadKey(true).KeyChar;
                switch (c)
                {
                    case '1':
                        PathData.kazooOrNoKazoo = "Kazoo";
                        numSelect = false;
                        break;
                    case '2':
                        numSelect = false;
                        PathData.kazooOrNoKazoo = "NoKazoo";
                        break;
                    default:
                        break;
                }
            } while (numSelect == true);
        }

        #endregion
    }
}
