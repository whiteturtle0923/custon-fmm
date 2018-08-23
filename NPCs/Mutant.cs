using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.NPCs
{
    [AutoloadHead]
    public class Mutant : ModNPC
    {
        public static bool shop1;
        public static bool shop2;
        public static bool shop3;
        public static int shopnum = 1;

        public override bool Autoload(ref string name)
        {
            name = "Mutant";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutant");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;

            npc.defense = NPC.downedMoonlord ? 50 : 15;

            npc.lifeMax = NPC.downedMoonlord ? 5000 : 250;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Mutant");

            /*if(ModLoader.GetMod("FargowiltasSouls") != null)
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModLoader.GetMod("FargowiltasSouls").ItemType("Masochist");
            }*/
        }

        #region other mod bools

        //thorium bools
        public bool ThoriumDownedBird => ThoriumMod.ThoriumWorld.downedThunderBird;

        public bool ThoriumDownedJelly => ThoriumMod.ThoriumWorld.downedJelly;

        public bool ThoriumDownedStorm => ThoriumMod.ThoriumWorld.downedStorm;

        public bool ThoriumDownedChamp => ThoriumMod.ThoriumWorld.downedChampion;

        public bool ThoriumDownedScout => ThoriumMod.ThoriumWorld.downedScout;

        public bool ThoriumDownedStrider => ThoriumMod.ThoriumWorld.downedStrider;

        public bool ThoriumDownedBeholder => ThoriumMod.ThoriumWorld.downedFallenBeholder;

        public bool ThoriumDownedLich => ThoriumMod.ThoriumWorld.downedLich;

        public bool ThoriumDownedAbyss => ThoriumMod.ThoriumWorld.downedDepthBoss;

        public bool ThoriumDownedRag => ThoriumMod.ThoriumWorld.downedRealityBreaker;

        //calamity bools
        public bool CalamityDownedScourge => CalamityMod.CalamityWorld.downedDesertScourge;

        public bool CalamityDownedHive => CalamityMod.CalamityWorld.downedHiveMind;

        public bool CalamityDownedPerfor => CalamityMod.CalamityWorld.downedPerforator;

        public bool CalamityDownedSlime => CalamityMod.CalamityWorld.downedSlimeGod;

        public bool CalamityDownedCryo => CalamityMod.CalamityWorld.downedCryogen;

        public bool CalamityDownedBrim => CalamityMod.CalamityWorld.downedBrimstoneElemental;

        public bool CalamityDownedCalamitas => CalamityMod.CalamityWorld.downedCalamitas;

        public bool CalamityDownedLevi => CalamityMod.CalamityWorld.downedLeviathan;

        public bool CalamityDownedPlague => CalamityMod.CalamityWorld.downedPlaguebringer;

        public bool CalamityDownedGuardian => CalamityMod.CalamityWorld.downedGuardians;

        public bool CalamityDownedProv => CalamityMod.CalamityWorld.downedProvidence;

        public bool CalamityDownedDOG => CalamityMod.CalamityWorld.downedDoG;

        public bool CalamityDownedYharon => CalamityMod.CalamityWorld.downedYharon;

        public bool CalamityDownedSCAL => CalamityMod.CalamityWorld.downedSCal;

        public bool CalamityDownedRav => CalamityMod.CalamityWorld.downedScavenger;

        public bool CalamityDownedCrab => CalamityMod.CalamityWorld.downedCrabulon;

        public bool CalamityDownedAstrum => CalamityMod.CalamityWorld.downedStarGod;

        public bool CalamityDownedBirb => CalamityMod.CalamityWorld.downedBumble;

        public bool CalamityDownedPolter => CalamityMod.CalamityWorld.downedPolterghast;

        public bool CalamityDownedAquatic => CalamityMod.CalamityWorld.downedAquaticScourge;

        public bool CalamityDownedAstragel => CalamityMod.CalamityWorld.downedAstrageldon;

        //sacred tools bools
        public bool SacredDownedHarpy => SacredTools.ModdedWorld.downedHarpy;

        public bool SacredDownedHarpy2 => SacredTools.ModdedWorld.downedRaynare;

        public bool SacredDownedAbbadon => SacredTools.ModdedWorld.OblivionSpawns;

        public bool SacredDownedSerpent => SacredTools.ModdedWorld.FlariumSpawns;

        public bool SacredDownedLunar => SacredTools.ModdedWorld.downedLunarians;

        public bool SacredDownedPump => SacredTools.ModdedWorld.downedPumpboi;

        //grealm bools
        public bool GRealmDownedFolivine => GRealm.MWorld.downedFolivine;

        public bool GRealmDownedMantid => GRealm.MWorld.downedMatriarch;

        //pumpking
        public bool PumpkingDownedHorse => Pumpking.PumpkingWorld.downedPumpkingHorseman;

        public bool PumpkingDownedTerra => Pumpking.PumpkingWorld.downedTerraLord;

        //joost
        public bool JoostDownedCactuar => JoostMod.JoostWorld.downedJumboCactuar;

        public bool JoostDownedSAX => JoostMod.JoostWorld.downedSAX;

        public bool JoostDownedGilga => JoostMod.JoostWorld.downedGilgamesh;

        //tremor
        public bool TremorDownedCorn => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn];

        public bool TremorDownedRukh => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh];

        public bool TremorDownedFungus => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle];

        public bool TremorDownedWhale => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale];

        public bool TremorDownedTrinity => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity];

        public bool TremorDownedTotem => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem];

        public bool TremorDownedJelly => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish];

        public bool TremorDownedCyber => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing];

        public bool TremorDownedHeater => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds];

        public bool TremorDownedFrost => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing];

        public bool TremorDownedEmperor => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor];

        public bool TremorDownedPixie => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen];

        public bool TremorDownedAlchemaster => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster];

        public bool TremorDownedBrutallisk => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk];

        public bool TremorDownedCog => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord];

        public bool TremorDownedWall => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow];

        public bool TremorDownedMotherboard => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard];

        public bool TremorDownedDragon => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon];

        public bool TremorDownedAndas => Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas];

        //spirit
        public bool SpiritDownedScarab => SpiritMod.MyWorld.downedScarabeus;

        public bool SpiritDownedFlier => SpiritMod.MyWorld.downedAncientFlier;

        public bool SpiritDownedRaider => SpiritMod.MyWorld.downedRaider;

        public bool SpiritDownedInfer => SpiritMod.MyWorld.downedInfernon;

        public bool SpiritDownedDusking => SpiritMod.MyWorld.downedDusking;

        public bool SpiritDownedIlluminant => SpiritMod.MyWorld.downedIlluminantMaster;

        public bool SpiritDownedAtlas => SpiritMod.MyWorld.downedAtlas;

        public bool SpiritDownedOverseer => SpiritMod.MyWorld.downedOverseer;

        public bool SpiritDownedVine => SpiritMod.MyWorld.downedReachBoss;

        public bool SpiritDownedUmbra => SpiritMod.MyWorld.downedSpiritCore;

        //BTFA
        public bool BtfaTitan => ForgottenMemories.TGEMWorld.downedTitanRock;

        public bool BtfaAcheron => ForgottenMemories.TGEMWorld.downedAcheron;

        public bool BtfaArtery => ForgottenMemories.TGEMWorld.downedArterius;

        public bool BtfaGhastly => ForgottenMemories.TGEMWorld.downedGhastlyEnt;

        //Bluemagics
        public bool BlueDownedPhantom => Bluemagic.BluemagicWorld.downedPhantom;

        public bool BlueDownedAbom => Bluemagic.BluemagicWorld.downedAbomination;

        //Eota
        public bool AncientsDownedWorms => EchoesoftheAncients.AncientWorld.downedWyrms;

        //Crystilium
        public bool CrystiliumDownedKing => CrystiliumMod.CrystalWorld.downedCrystalKing;

        //exodus
        public bool ExodusDownedAbom => Exodus.ExodusWorld.downedExodusAbomination;

        public bool ExodusDownedBlob => Exodus.ExodusWorld.downedExodusEvilBlob;

        public bool ExodusDownedColoss => Exodus.ExodusWorld.downedExodusColossus;

        public bool ExodusDownedEmperor => Exodus.ExodusWorld.downedExodusDesertEmperor;

        public bool ExodusDownedHive => Exodus.ExodusWorld.downedExodusHivemind;

        public bool ExodusDownedMaster => Exodus.ExodusWorld.downedExodusMaster;

        public bool ExodusDownedHeart => Exodus.ExodusWorld.downedExodusSludgeheart;

        //W1K
        public bool W1KDownedKutku => W1KModRedux.MWorld.downedKutKu;

        public bool W1KDownedArdorix => W1KModRedux.MWorld.downedArdorix;

        public bool W1KDownedArborix => W1KModRedux.MWorld.downedArborix;

        public bool W1KDownedAquatix => W1KModRedux.MWorld.downedAquatix;

        public bool W1KDownedIvy => W1KModRedux.MWorld.downedIvy;

        public bool W1KDownedDeath => W1KModRedux.MWorld.downedDeath;

        public bool W1KDownedRathalos => W1KModRedux.MWorld.downedRathalos;

        public bool W1KDownedRidley => W1KModRedux.MWorld.downedRidley;

        public bool W1KDownedOkiku => W1KModRedux.MWorld.downedOkiku;

        //fernium
        public bool FerniumDownedMargrama => Fernium.world.downedMargrama;

        public bool FerniumDownedLunarRex => Fernium.world.downedLunarRex;

        public bool FerniumFernite => Fernium.world.downedFerniteTheUnpleasant;

        //elements awoken
        public bool ElementsDownedWaste => ElementsAwoken.MyWorld.downedWasteland;

        public bool ElementsDownedInfern => ElementsAwoken.MyWorld.downedInfernace;

        public bool ElementsDownedScourge => ElementsAwoken.MyWorld.downedScourgeFighter;

        public bool ElementsDownedReg => ElementsAwoken.MyWorld.downedRegaroth;

        public bool ElementsDownedCelestial => ElementsAwoken.MyWorld.downedCelestial;

        public bool ElementsDownedObsid => ElementsAwoken.MyWorld.downedObsidious;

        public bool ElementsDownedPerma => ElementsAwoken.MyWorld.downedPermafrost;

        public bool ElementsDownedAque => ElementsAwoken.MyWorld.downedAqueous;

        public bool ElementsDownedEye => ElementsAwoken.MyWorld.downedEye;

        public bool ElementsDownedDragon => ElementsAwoken.MyWorld.downedAncientDragon;

        public bool ElementsDownedGuardian => ElementsAwoken.MyWorld.downedGuardian;

        public bool ElementsDownedVoid => ElementsAwoken.MyWorld.downedVoidLeviathan;

        //antiaris
        public bool AntiarisDownedAntlion => Antiaris.AntiarisWorld.DownedAntlionQueen;

        //disarray
        public bool DisarrayDownedPlant => Disarray.DisarrayWorld.downedPlantKing;

        public bool DisarrayDownedCrusher => Disarray.DisarrayWorld.downedDesertCrusher;

        public bool DisarrayDownedProbe => Disarray.DisarrayWorld.downedProbeMother;

        public bool DisarrayDownedGeneral => Disarray.DisarrayWorld.downedTheGeneral;

        public bool DisarrayDownedSerpent => Disarray.DisarrayWorld.downedLunarSerpent;

        public bool DisarrayDownedCold => Disarray.DisarrayWorld.downedColdBoss;

        public bool DisarrayDownedShadows => Disarray.DisarrayWorld.downedShadows;

        public bool DisarrayDownedLuna => Disarray.DisarrayWorld.downedLuna;

        public bool DisarrayDownedBell => Disarray.DisarrayWorld.downedBell;

        public bool DisarrayDownedMech => Disarray.DisarrayWorld.downedMech;

        public bool DisarrayDownedSludge => Disarray.DisarrayWorld.downedCosmicSludge;

        public bool DisarrayDownedDeva => Disarray.DisarrayWorld.downedCoreOfTheDevastator;

        public bool DisarrayDownedMeteor => Disarray.DisarrayWorld.downedMeteorzoid;

        public bool DisarrayDownedDungeon => Disarray.DisarrayWorld.downedDungeon;

        //cookie
        public bool CookieDownedCookie => CookieMod.CookieModWorld.downedCookieBoss;

        public bool CookieDownedBunny => CookieMod.CookieModWorld.downedBunny;

        //enigma
        public bool EnigmaDownedAnnih => Laugicality.LaugicalityWorld.downedAnnihilator;

        public bool EnigmaDownedSlyber => Laugicality.LaugicalityWorld.downedSlybertron;

        public bool EnigmaDownedTrain => Laugicality.LaugicalityWorld.downedSteamTrain;

        public bool EnigmaDownedShark => Laugicality.LaugicalityWorld.downedDuneSharkron;

        public bool EnigmaDownedHypo => Laugicality.LaugicalityWorld.downedHypothema;

        public bool EnigmaDownedRagnar => Laugicality.LaugicalityWorld.downedRagnar;

        public bool EnigmaDownedRocks => Laugicality.LaugicalityWorld.downedRocks;

        public bool EnigmaDownedEther => Laugicality.LaugicalityWorld.downedTrueEtheria;

        public bool EnigmaDownedDio => Laugicality.LaugicalityWorld.downedAnDio;

        #endregion other mod bools

        public override bool CanTownNPCSpawn(int numTownNpcs, int money) => FargoWorld.downedBoss;

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(9))
            {
                case 0:
                    return "Flacken";

                case 1:
                    return "Dorf";

                case 2:
                    return "Bingo";

                case 3:
                    return "Hans";

                case 4:
                    return "Fargo";

                case 5:
                    return "Grim";

                case 6:
                    return "Furgo";

                case 7:
                    return "Fargu";

                default:
                    return "Polly";
            }
        }

        public override string GetChat()
        {
            if (NPC.downedMoonlord && Fargowiltas.instance.fargoLoaded && Main.rand.Next(28) == 0)
            {
                return "Now that you've defeated the big guy, I'd say it's time to start collecting those materials! ;)";
            }

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(1))
                {
                    case 0:
                        return "Lovely night, isn't it?";

                    default:
                        return "I hope the constant arguing I'm hearing isn't my fault.";
                }
            }

            if (BirthdayParty.PartyIsUp)
            {
                return "I don't know what everyone's so happy about, but as long as nobody mistakes me for a Pigronata, I'm happy too.";
            }

            //specific other npc quotes
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);

            if (nurse >= 0 && Main.rand.Next(27) == 0)
            {
                return "Whenever we're alone, " + Main.npc[nurse].GivenName + " keeps throwing syringes at me, no matter how many times I tell her to stop!";
            }
            if (witchDoctor >= 0 && Main.rand.Next(26) == 0)
            {
                return "Please go tell " + Main.npc[witchDoctor].GivenName + " to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.";
            }
            if (dryad >= 0 && Main.rand.Next(25) == 0)
            {
                return "Why does " + Main.npc[dryad].GivenName + "'s outfit make my wings flutter?";
            }
            if (stylist >= 0 && Main.rand.Next(24) == 0)
            {
                return Main.npc[stylist].GivenName + " once gave me a wig... I look hideous with long hair.";
            }
            if (truffle >= 0 && Main.rand.Next(23) == 0)
            {
                return "That mutated mushroom seems like my type of fella.";
            }
            if (tax >= 0 && Main.rand.Next(22) == 0)
            {
                return Main.npc[tax].GivenName + " keeps asking me for money, but he won't accept my spawners!";
            }
            if (guide >= 0 && Main.rand.Next(21) == 0)
            {
                return "Any idea why " + Main.npc[guide].GivenName + "is always cowering in fear when I get near him?";
            }
            if (truffle >= 0 && witchDoctor >= 0 && cyborg >= 0 && Main.rand.Next(20) == 0)
            {
                return "If any of us could play instruments, I'd totally start a band with " + Main.npc[witchDoctor].GivenName + ", " + Main.npc[truffle].GivenName + ", and " + Main.npc[cyborg].GivenName + ".";
            }

            if (Main.dayTime != true && Main.rand.Next(10) == 0)
            {
                return "I'd follow and help, but I'd much rather sit around right now.";
            }

            switch (Main.rand.Next(19))
            {
                case 0:
                    return "Savagery, barbarism, bloodthirst, that's what I like seeing in people.";
                case 1:
                    return "The stronger you get, the more stuff I sell. Makes sense, right?";
                case 2:
                    return "There's something all of you have that I don't... Death perception, I think it's called?";
                case 3:
                    return "It would be pretty cool if I could sell a summon for myself...";
                case 4:
                    return "The only way to get stronger is to keep buying from me and in bulk too!";
                case 5:
                    return "What's that? You want to fight me? ...you're not worthy you rat.";
                case 6:
                    return "Don't bother with anyone else, all you'll ever need is right here.";
                case 7:
                    return "You're lucky I'm on your side.";
                case 8:
                    return "Thanks for the house, I guess.";
                case 9:
                    return "Why yes I would love a ham and swiss sandwich.";
                case 10:
                    return "Should I start wearing clothes? ...Nah.";
                case 11:
                    return "It's not like I can actually use all the gold you're spending.";
                case 12:
                    return "Violence for violence is the law of the beast.";
                case 13:
                    return "Those guys really need to get more creative. All of their first bosses are desert themed!";
                case 14:
                    return "I am proud to be known as the Mutant, but thank Fargo I'm no Abominationn";
                case 15:
                    return "I'm all you need for a calamity.";
                case 16:
                    return "Everything shall bow before me! ...after you make this purchase.";
                case 17:
                    return "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.";
                default:
                    return "Cthulhu's got nothing on me!";
            }
        }

        /*
        //will he ever sell souls ? idk
        -oh is that a soul of the universe? Fascinating I'll get all mine from the back
        -Oh wow is that a speed soul. I coulda sold you one man
        -all souls need one
        "I know, I know, these souls look really pricy, buy I'm selling them at a loss here! Nobody would buy them otherwise! What a ripoff!"
        */

        public override void SetChatButtons(ref string button, ref string button2)
        {
            switch (shopnum)
            {
                case 1:
                    button = "Pre Hardmode";
                    break;
                case 2:
                    button = "Hardmode";
                    break;
                default:
                    button = "Post Moon Lord";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "Cycle Shop";
            }

            if (NPC.downedMoonlord)
            {
                if (shopnum >= 4)
                {
                    shopnum = 1;
                }
            }
            else
            {
                if (shopnum >= 3)
                {
                    shopnum = 1;
                }
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;

                switch (shopnum)
                {
                    case 1:
                        shop1 = true;
                        shop2 = false;
                        shop3 = false;
                        break;
                    case 2:
                        shop2 = true;
                        shop1 = false;
                        shop3 = false;
                        break;
                    default:
                        shop3 = true;
                        shop1 = false;
                        shop2 = false;
                        break;
                }
            }

            if (!firstButton && Main.hardMode)
            {
                shopnum++;
            }
        }

        private void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (!check) return;
            shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
            shop.item[nextSlot].value = price;
            nextSlot++;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            #region PREHARDMODE BOSSES

            if (shop1)
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if(Fargowiltas.instance.fargoLoaded)
                {
                    AddItem(true, "FargowiltasSouls", "PandorasBox", 200000, ref shop, ref nextSlot);
                }

                //goblin king - true eater

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedAbom, "Exodus", "ZombieMeat", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedScarab, "SpiritMod", "ScarabIdol", 10000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedPlant, "Disarray", "YoungSapling", 10000, ref shop, ref nextSlot);
                }

                //antlion queen - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedBird, "ThoriumMod", "StormFlare", 20000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedSlimeKing, "Fargowiltas", "SlimyCrown", 30000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCrusher, "Disarray", "ScorpionIdol", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedScourge, "CalamityMod", "DriedSeafood", 20000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedBoss1, "Fargowiltas", "SuspiciousEye", 50000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedKutku, "W1KModRedux", "GoldenFeather", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedShark, "Laugicality", "TastyMorsel", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedColoss, "Exodus", "GraniteAnomaly", 40000, ref shop, ref nextSlot);
                    AddItem(ExodusDownedBlob, "Exodus", "DisgustingJelly", 30000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedHypo, "Laugicality", "ChilledMesh", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedProbe, "Disarray", "ProbeCaller", 30000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedRagnar, "Laugicality", "MoltenMess", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedWaste, "ElementsAwoken", "WastelandSummon", 70000, ref shop, ref nextSlot);
                }

                //The Spirit - Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedRukh, "Tremor", "DesertCrown", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedCrab, "CalamityMod", "DecapoditaSprout", 40000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedBoss2, "Fargowiltas", "WormyFood", 60000, ref shop, ref nextSlot);
                AddItem(NPC.downedBoss2, "Fargowiltas", "GoreySpine", 60000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedCookie, "CookieMod", "BloodyCookie", 60000, ref shop, ref nextSlot);
                    AddItem(CookieDownedCookie, "CookieMod", "CursedCookie", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedJelly, "ThoriumMod", "JellyfishResonator", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedTotem, "Tremor", "MysteriousDrum", 50000, ref shop, ref nextSlot);
                }

                //One Shot -Split

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedCorn, "Tremor", "CursedPopcorn", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "LunarFlame", 20000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedGeneral, "Disarray", "TornBattleArmor", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedPerfor, "CalamityMod", "BloodyWormFood", 100000, ref shop, ref nextSlot);
                    AddItem(CalamityDownedHive, "CalamityMod", "Teratoma", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    AddItem(GRealmDownedFolivine, "GRealm", "JungleBait", 70000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedJelly, "Tremor", "StormJelly", 60000, ref shop, ref nextSlot);
                }

                //Clampula - True Eater

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedVine, "SpiritMod", "ReachBossSummon", 70000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedDragon, "Tremor", "RustyLantern", 70000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedEmperor, "Exodus", "AncientArtifact", 40000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedQueenBee, "Fargowiltas", "Abeemination2", 100000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSerpent, "Disarray", "MoonStone", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedBoss3, "TrueEater", "SpitterSpawner", 70000, ref shop, ref nextSlot);
                }

                //magnoliac - btfa ?

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedFlier, "SpiritMod", "JewelCrown", 70000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.antiarisLoaded)
                {
                    AddItem(AntiarisDownedAntlion, "Antiaris", "AntlionDoll", 70000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedPump, "SacredTools", "PumpkinLantern", 70000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedBoss3, "Fargowiltas", "SuspiciousSkull", 80000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.cookieLoaded)
                {
                    AddItem(CookieDownedBunny, "CookieMod", "BunnyCrown ", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedIvy, "W1KModRedux", "CursedFlower", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArdorix, "W1KModRedux", "FieryEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedArborix, "W1KModRedux", "GrassyEgg", 150000, ref shop, ref nextSlot);
                    AddItem(W1KDownedAquatix, "W1KModRedux", "WateryEgg", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedRaider, "SpiritMod", "StarWormSummon", 80000, ref shop, ref nextSlot);
                }

                //the cluster -peculiarity

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedStorm, "ThoriumMod", "UnstableCore", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumDownedMargrama, "Fernium", "HardenedSludge", 30000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedInfern, "ElementsAwoken", "InfernaceSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedCold, "Disarray", "PermaFreeze", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedSlime, "CalamityMod", "OverloadedSludge", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaAcheron, "ForgottenMemories", "Unstable_Wisp", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedHeater, "Tremor", "MoltenHeart", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy, "SacredTools", "HarpySummon", 60000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedChamp, "ThoriumMod", "AncientBlade", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedDio, "Laugicality", "AncientAwakener", 50000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedFungus, "Tremor", "MushroomCrystal", 70000, ref shop, ref nextSlot);
                }

                //alpha cactus worm - joost

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedHive, "Exodus", "VineSerpent", 80000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedScout, "ThoriumMod", "StarCaller", 80000, ref shop, ref nextSlot);
                }

                AddItem(Main.hardMode, "Fargowiltas", "FleshyDoll", 120000, ref shop, ref nextSlot);
                AddItem(Main.hardMode, "Fargowiltas", "DeathBringerFairy", 160000, ref shop, ref nextSlot);
            }

            #endregion PREHARDMODE BOSSES

            #region HARDMODE BOSSES

            else if (shop2)
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedStrider, "ThoriumMod", "StriderTear", 100000, ref shop, ref nextSlot);
                }

                if(Fargowiltas.instance.ferniumLoaded)
                {
                    AddItem(FerniumFernite, "Fernium", "FerniumCore ", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaArtery, "ForgottenMemories", "BloodClot", 110000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedAlchemaster, "Tremor", "AncientMosaic", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedInfer, "SpiritMod", "CursedCloth", 90000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedCryo, "CalamityMod", "CryoKey", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedShadows, "Disarray", "EnhancedShadowFragment", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedMaster, "Exodus", "GlowingSkull", 100000, ref shop, ref nextSlot);
                }

                //ichor blaster/ grasper - true eater

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedBeholder, "ThoriumMod", "VoidLens", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.btfaLoaded)
                {
                    AddItem(BtfaTitan, "ForgottenMemories", "anomalydetector", 140000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedRathalos, "W1KModRedux", "MysteryTicket", 380000, ref shop, ref nextSlot);
                    AddItem(W1KDownedRidley, "W1KModRedux", "MetroidCapsule", 380000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedMechBoss1, "Fargowiltas", "MechWorm", 150000, ref shop, ref nextSlot);
                AddItem(NPC.downedMechBoss2, "Fargowiltas", "MechEye", 150000, ref shop, ref nextSlot);
                AddItem(NPC.downedMechBoss3, "Fargowiltas", "MechSkull", 150000, ref shop, ref nextSlot);
                AddItem((NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3), "Fargowiltas", "MechanicalAmalgam", 350000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedDusking, "SpiritMod", "DuskCrown", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedLuna, "Disarray", "MastersPresent", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedBrim, "CalamityMod", "CharredIdol", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedUmbra, "SpiritMod", "UmbraSummon", 100000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedMotherboard, "Tremor", "MechanicalBrain", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedBell, "Disarray", "ABell", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedAquatic, "CalamityMod", "Seafood", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedAnnih, "Laugicality", "MechanicalMonitor", 120000, ref shop, ref nextSlot);
                    AddItem(EnigmaDownedSlyber, "Laugicality", "SteamCrown ", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedScourge, "ElementsAwoken", "ScourgeFighterSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedReg, "ElementsAwoken", "RegarothSummon", 170000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedTrain, "Laugicality", "SuspiciousTrainWhistle", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMech, "Disarray", "MechPrism", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedHarpy2, "SacredTools", "HarpySummon2", 140000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedLich, "ThoriumMod", "LichCatalyst", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedPixie, "Tremor", "PixieinaJar", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedCalamitas, "CalamityMod", "BlightedEyeball", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedIlluminant, "SpiritMod", "ChaosFire", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedOkiku, "W1KModRedux", "OminousMask", 400000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedPlantBoss, "Fargowiltas", "Plantera", 160000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedLevi, "Fargowiltas", "LeviathanSummon", 300000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.exodusLoaded)
                {
                    AddItem(ExodusDownedHeart, "Exodus", "JungleCrown", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.enigmaLoaded)
                {
                    AddItem(EnigmaDownedEther, "Laugicality", "EmblemOfEtheria", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedFrost, "Tremor", "FrostCrown", 120000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedAstragel, "CalamityMod", "AstralChunk", 250000, ref shop, ref nextSlot);
                    AddItem(CalamityDownedAstrum, "CalamityMod", "Starcore", 300000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedWall, "Tremor", "ShadowRelic", 120000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedGolemBoss, "Fargowiltas", "LihzahrdPowerCell2", 180000, ref shop, ref nextSlot);
                AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BatteredClub", 150000, ref shop, ref nextSlot);
                AddItem(FargoWorld.downedBetsy, "Fargowiltas", "BetsyEgg", 160000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedCelestial, "ElementsAwoken", "CelestialSummon", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedPerma, "ElementsAwoken", "PermafrostSummon", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedObsid, "ElementsAwoken", "ObsidiousSummon", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedAbyss, "Fargowiltas", "AbyssionSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedCog, "Tremor", "ArtifactEngine", 120000, ref shop, ref nextSlot);
                    AddItem(TremorDownedCyber, "Tremor", "AdvancedCircuit", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.nightmaresLoaded)
                {
                    AddItem(NPC.downedPlantBoss, "TrueEater", "MimicKey", 150000, ref shop, ref nextSlot);
                }

                //the ancient - exodus

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedPlague, "CalamityMod", "Abomination", 500000, ref shop, ref nextSlot);
                }

                //behemoth - true eater

                if (Fargowiltas.instance.crystiliumLoaded)
                {
                    AddItem(CrystiliumDownedKing, "CrystiliumMod", "CrypticCrystal", 140000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.w1kLoaded)
                {
                    AddItem(W1KDownedDeath, "W1KModRedux", "DungeonMasterGuide", 500000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedFishron, "Fargowiltas", "TruffleWorm2", 180000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedPhantom, "Bluemagic", "PaladinEmblem", 180000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedAque, "ElementsAwoken", "AqueousSummon", 270000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedHorse, "Pumpking", "PumpkingSoul", 160000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedAtlas, "SpiritMod", "StoneSkin", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedRav, "CalamityMod", "AncientMedallion", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.blueMagicLoaded)
                {
                    AddItem(BlueDownedAbom, "Bluemagic", "FoulOrb", 250000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedAncientCultist, "Fargowiltas", "CultistSummon", 50000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedEye, "ElementsAwoken", "EyeSummon", 150000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedDragon, "ElementsAwoken", "AncientDragonSummon", 150000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedTowers, "Fargowiltas", "PillarSummon", 200000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedGuardian, "ElementsAwoken", "GuardianSummon", 300000, ref shop, ref nextSlot);
                }

                AddItem(NPC.downedMoonlord, "Fargowiltas", "CelestialSigil2", 500000, ref shop, ref nextSlot);
                AddItem(NPC.downedMoonlord, "Fargowiltas", "MutantVoodoo", 1000000, ref shop, ref nextSlot);
            }

            #endregion HARDMODE BOSSES

            #region POST MOONLORD BOSSES

            else
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedSludge, "Disarray", "VileSlimeBall", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.spiritLoaded)
                {
                    AddItem(SpiritDownedOverseer, "SpiritMod", "SpiritIdol", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.pumpkingLoaded)
                {
                    AddItem(PumpkingDownedTerra, "Pumpking", "TerraCore", 500000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedEmperor, "Tremor", "EmperorCrown", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.elementsLoaded)
                {
                    AddItem(ElementsDownedVoid, "ElementsAwoken", "VoidLeviathanSummon", 750000, ref shop, ref nextSlot);
                }

                //abomination rematch - blue

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedBrutallisk, "Tremor", "RoyalEgg", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedAbbadon, "SacredTools", "ShadowWrathSummonItem", 200000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedGuardian, "CalamityMod", "ProfanedShard", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedCactuar, "JoostMod", "Cactusofdoom", 5000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedWhale, "Tremor", "CosmicKrill", 200000, ref shop, ref nextSlot);
                    AddItem(TremorDownedTrinity, "Tremor", "StoneofKnowledge", 250000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.tremorLoaded)
                {
                    AddItem(TremorDownedAndas, "Tremor", "InfernoSkull", 300000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDeva, "Disarray", "EyeOfSouls", 600000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedProv, "CalamityMod", "ProfanedCore", 15000000, ref shop, ref nextSlot);
                }

                //void marshal -true eater

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedSerpent, "SacredTools", "SerpentSummon", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.grealmLoaded)
                {
                    AddItem(GRealmDownedMantid, "GRealm", "CrownOfMantodea", 700000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedSAX, "JoostMod", "InfectedArmCannon", 10000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedMeteor, "Disarray", "RandomSpaceRock", 750000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.sacredToolsLoaded)
                {
                    AddItem(SacredDownedLunar, "SacredTools", "MoonEmblem", 2000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.thoriumLoaded)
                {
                    AddItem(ThoriumDownedRag, "ThoriumMod", "RagSymbol", 400000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.ancientsLoaded)
                {
                    AddItem(AncientsDownedWorms, "EchoesoftheAncients", "Wyrm_Rune", 1000000, ref shop, ref nextSlot);
                }

                if (Fargowiltas.instance.joostLoaded)
                {
                    AddItem(JoostDownedGilga, "JoostMod", "Excalipoor", 15000000, ref shop, ref nextSlot);
                }

                //the challenger -sacred tools

                if (Fargowiltas.instance.disarrayLoaded)
                {
                    AddItem(DisarrayDownedDungeon, "Disarray", "DungeonAmalgamation", 1000000, ref shop, ref nextSlot);
                }

                //spirit of purity

                if (Fargowiltas.instance.calamityLoaded)
                {
                    AddItem(CalamityDownedBirb, "CalamityMod", "BirbPheromones", 20000000, ref shop, ref nextSlot);
                }

                //spirit of chaos

                //spirit of purity rematch

                AddItem(true, "Fargowiltas", "AncientSeal", 10000000, ref shop, ref nextSlot);
            }

            #endregion POST MOONLORD BOSSES
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (NPC.downedMoonlord)
            {
                damage = 500;
                knockback = 10f;
            }
            else if (Main.hardMode)
            {
                damage = 60;
                knockback = 5f;
            }
            else
            {
                damage = 20;
                knockback = 4f;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (NPC.downedMoonlord)
            {
                cooldown = 1;
            }
            else if (Main.hardMode)
            {
                cooldown = 20;
                randExtraCooldown = 25;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 30;
            }
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (NPC.downedMoonlord)
            {
                projType = mod.ProjectileType("PhantasmalEyeProjectile");
            }
            else if (Main.hardMode)
            {
                projType = mod.ProjectileType("MechEyeProjectile");
            }
            else
            {
                projType = mod.ProjectileType("EyeProjectile");
            }

            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MutantGrabBag"));
            }
        }

        //gore
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore3"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore2"));
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore1"));
                }
            }
            else
            {
                for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}