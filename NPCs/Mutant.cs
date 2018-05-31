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
        public static bool shop1 = false;
        public static bool shop2 = false;
        public static bool shop3 = false;
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

            if (NPC.downedMoonlord)
            {
                npc.defense = 50;
            }
            else
            {
                npc.defense = 15;
            }

            if (NPC.downedMoonlord)
            {
                npc.lifeMax = 5000;
            }
            else
            {
                npc.lifeMax = 250;
            }

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;

            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)mod.ItemType("Masochist");
        }

        #region other mod bools

        //thorium bools
        public bool ThoriumDownedBird
        {
            get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }

        public bool ThoriumDownedJelly
        {
            get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }

        public bool ThoriumDownedStorm
        {
            get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }

        public bool ThoriumDownedChamp
        {
            get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }

        public bool ThoriumDownedScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }

        public bool ThoriumDownedStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }

        public bool ThoriumDownedBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }

        public bool ThoriumDownedLich
        {
            get { return ThoriumMod.ThoriumWorld.downedLich; }
        }

        public bool ThoriumDownedAbyss
        {
            get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }

        public bool ThoriumDownedRag
        {
            get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }

        //calamity bools
        public bool CalamityDownedScourge
        {
            get { return CalamityMod.CalamityWorld.downedDesertScourge; }
        }

        public bool CalamityDownedHive
        {
            get { return CalamityMod.CalamityWorld.downedHiveMind; }
        }

        public bool CalamityDownedPerfor
        {
            get { return CalamityMod.CalamityWorld.downedPerforator; }
        }

        public bool CalamityDownedSlime
        {
            get { return CalamityMod.CalamityWorld.downedSlimeGod; }
        }

        public bool CalamityDownedCryo
        {
            get { return CalamityMod.CalamityWorld.downedCryogen; }
        }

        public bool CalamityDownedBrim
        {
            get { return CalamityMod.CalamityWorld.downedBrimstoneElemental; }
        }

        public bool CalamityDownedCalamitas
        {
            get { return CalamityMod.CalamityWorld.downedCalamitas; }
        }

        public bool CalamityDownedLevi
        {
            get { return CalamityMod.CalamityWorld.downedLeviathan; }
        }

        public bool CalamityDownedPlague
        {
            get { return CalamityMod.CalamityWorld.downedPlaguebringer; }
        }

        public bool CalamityDownedGuardian
        {
            get { return CalamityMod.CalamityWorld.downedGuardians; }
        }

        public bool CalamityDownedProv
        {
            get { return CalamityMod.CalamityWorld.downedProvidence; }
        }

        public bool CalamityDownedDOG
        {
            get { return CalamityMod.CalamityWorld.downedDoG; }
        }

        public bool CalamityDownedYharon
        {
            get { return CalamityMod.CalamityWorld.downedYharon; }
        }

        public bool CalamityDownedSCAL
        {
            get { return CalamityMod.CalamityWorld.downedSCal; }
        }

        public bool CalamityDownedRav
        {
            get { return CalamityMod.CalamityWorld.downedScavenger; }
        }

        public bool CalamityDownedCrab
        {
            get { return CalamityMod.CalamityWorld.downedCrabulon; }
        }

        public bool CalamityDownedAstrum
        {
            get { return CalamityMod.CalamityWorld.downedStarGod; }
        }

        public bool CalamityDownedBirb
        {
            get { return CalamityMod.CalamityWorld.downedBumble; }
        }

        public bool CalamityDownedPolter
        {
            get { return CalamityMod.CalamityWorld.downedPolterghast; }
        }

        public bool CalamityDownedAquatic
        {
            get { return CalamityMod.CalamityWorld.downedAquaticScourge; }
        }

        public bool CalamityDownedAstragel
        {
            get { return CalamityMod.CalamityWorld.downedAstrageldon; }
        }

        //sacred tools bools
        public bool SacredDownedHarpy
        {
            get { return SacredTools.ModdedWorld.downedHarpy; }
        }

        public bool SacredDownedHarpy2
        {
            get { return SacredTools.ModdedWorld.downedRaynare; }
        }

        public bool SacredDownedAbbadon
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }

        public bool SacredDownedSerpent
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }

        public bool SacredDownedLunar
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }

        public bool SacredDownedPump
        {
            get { return SacredTools.ModdedWorld.downedPumpboi; }
        }

        //grealm bools
        public bool GRealmDownedFolivine
        {
            get { return GRealm.MWorld.downedFolivine; }
        }

        public bool GRealmDownedMantid
        {
            get { return GRealm.MWorld.downedMatriarch; }
        }

        //pumpking
        public bool PumpkingDownedHorse
        {
            get { return Pumpking.PumpkingWorld.downedPumpkingHorseman; }
        }

        public bool PumpkingDownedTerra
        {
            get { return Pumpking.PumpkingWorld.downedTerraLord; }
        }

        //joost
        public bool JoostDownedCactuar
        {
            get { return JoostMod.JoostWorld.downedJumboCactuar; }
        }

        public bool JoostDownedSAX
        {
            get { return JoostMod.JoostWorld.downedSAX; }
        }

        public bool JoostDownedGilga
        {
            get { return JoostMod.JoostWorld.downedGilgamesh; }
        }

        //tremor
        public bool TremorDownedCorn
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.EvilCorn]; }
        }

        public bool TremorDownedRukh
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Rukh]; }
        }

        public bool TremorDownedFungus
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FungusBeetle]; }
        }

        public bool TremorDownedWhale
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.SpaceWhale]; }
        }

        public bool TremorDownedTrinity
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Trinity]; }
        }

        public bool TremorDownedTotem
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.TikiTotem]; }
        }

        public bool TremorDownedJelly
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.StormJellyfish]; }
        }

        public bool TremorDownedCyber
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CyberKing]; }
        }

        public bool TremorDownedHeater
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.HeaterofWorlds]; }
        }

        public bool TremorDownedFrost
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.FrostKing]; }
        }

        public bool TremorDownedEmperor
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.DarkEmperor]; }
        }

        public bool TremorDownedPixie
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.PixieQueen]; }
        }

        public bool TremorDownedAlchemaster
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Alchemaster]; }
        }

        public bool TremorDownedBrutallisk
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Brutallisk]; }
        }

        public bool TremorDownedCog
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.CogLord]; }
        }

        public bool TremorDownedWall
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.WallOfShadow]; }
        }

        public bool TremorDownedMotherboard
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Motherboard]; }
        }

        public bool TremorDownedDragon
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.AncientDragon]; }
        }

        public bool TremorDownedAndas
        {
            get { return Tremor.TremorWorld.downedBoss[Tremor.TremorWorld.Boss.Andas]; }
        }

        //spirit
        public bool SpiritDownedScarab
        {
            get { return SpiritMod.MyWorld.downedScarabeus; }
        }

        public bool SpiritDownedFlier
        {
            get { return SpiritMod.MyWorld.downedAncientFlier; }
        }

        public bool SpiritDownedRaider
        {
            get { return SpiritMod.MyWorld.downedRaider; }
        }

        public bool SpiritDownedInfer
        {
            get { return SpiritMod.MyWorld.downedInfernon; }
        }

        public bool SpiritDownedDusking
        {
            get { return SpiritMod.MyWorld.downedDusking; }
        }

        public bool SpiritDownedIlluminant
        {
            get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }

        public bool SpiritDownedAtlas
        {
            get { return SpiritMod.MyWorld.downedAtlas; }
        }

        public bool SpiritDownedOverseer
        {
            get { return SpiritMod.MyWorld.downedOverseer; }
        }

        public bool SpiritDownedVine
        {
            get { return SpiritMod.MyWorld.downedReachBoss; }
        }

        public bool SpiritDownedUmbra
        {
            get { return SpiritMod.MyWorld.downedSpiritCore; }
        }

        //BTFA
        public bool BtfaTitan
        {
            get { return ForgottenMemories.TGEMWorld.downedTitanRock; }
        }

        public bool BtfaAcheron
        {
            get { return ForgottenMemories.TGEMWorld.downedAcheron; }
        }

        public bool BtfaArtery
        {
            get { return ForgottenMemories.TGEMWorld.downedArterius; }
        }

        public bool BtfaGhastly
        {
            get { return ForgottenMemories.TGEMWorld.downedGhastlyEnt; }
        }

        //Bluemagics
        public bool BlueDownedPhantom
        {
            get { return Bluemagic.BluemagicWorld.downedPhantom; }
        }

        public bool BlueDownedAbom
        {
            get { return Bluemagic.BluemagicWorld.downedAbomination; }
        }

        //Eota
        public bool AncientsDownedWorms
        {
            get { return EchoesoftheAncients.AncientWorld.downedWyrms; }
        }

        //Crystilium
        public bool CrystiliumDownedKing
        {
            get { return CrystiliumMod.CrystalWorld.downedCrystalKing; }
        }

        //exodus
        public bool ExodusDownedAbom
        {
            get { return Exodus.ExodusWorld.downedExodusAbomination; }
        }

        public bool ExodusDownedBlob
        {
            get { return Exodus.ExodusWorld.downedExodusEvilBlob; }
        }

        public bool ExodusDownedColoss
        {
            get { return Exodus.ExodusWorld.downedExodusColossus; }
        }

        public bool ExodusDownedEmperor
        {
            get { return Exodus.ExodusWorld.downedExodusDesertEmperor; }
        }

        public bool ExodusDownedHive
        {
            get { return Exodus.ExodusWorld.downedExodusHivemind; }
        }

        public bool ExodusDownedMaster
        {
            get { return Exodus.ExodusWorld.downedExodusMaster; }
        }

        public bool ExodusDownedHeart
        {
            get { return Exodus.ExodusWorld.downedExodusSludgeheart; }
        }

        //W1K
        public bool W1KDownedKutku
        {
            get { return W1KModRedux.MWorld.downedKutKu; }
        }

        public bool W1KDownedArdorix
        {
            get { return W1KModRedux.MWorld.downedArdorix; }
        }

        public bool W1KDownedArborix
        {
            get { return W1KModRedux.MWorld.downedArborix; }
        }

        public bool W1KDownedAquatix
        {
            get { return W1KModRedux.MWorld.downedAquatix; }
        }

        public bool W1KDownedIvy
        {
            get { return W1KModRedux.MWorld.downedIvy; }
        }

        public bool W1KDownedDeath
        {
            get { return W1KModRedux.MWorld.downedDeath; }
        }

        public bool W1KDownedRathalos
        {
            get { return W1KModRedux.MWorld.downedRathalos; }
        }

        public bool W1KDownedRidley
        {
            get { return W1KModRedux.MWorld.downedRidley; }
        }

        public bool W1KDownedOkiku
        {
            get { return W1KModRedux.MWorld.downedOkiku; }
        }

        //fernium
        public bool FerniumDownedMargrama
        {
            get { return Fernium.world.downedMargrama; }
        }

        public bool FerniumDownedLunarRex
        {
            get { return Fernium.world.downedLunarRex; }
        }

        //elements awoken
        public bool ElementsDownedWaste
        {
            get { return ElementsAwoken.MyWorld.downedWasteland; }
        }

        public bool ElementsDownedInfern
        {
            get { return ElementsAwoken.MyWorld.downedInfernace; }
        }

        public bool ElementsDownedScourge
        {
            get { return ElementsAwoken.MyWorld.downedScourgeFighter; }
        }

        public bool ElementsDownedReg
        {
            get { return ElementsAwoken.MyWorld.downedRegaroth; }
        }

        public bool ElementsDownedCelestial
        {
            get { return ElementsAwoken.MyWorld.downedCelestial; }
        }

        public bool ElementsDownedObsid
        {
            get { return ElementsAwoken.MyWorld.downedObsidious; }
        }

        public bool ElementsDownedPerma
        {
            get { return ElementsAwoken.MyWorld.downedPermafrost; }
        }

        public bool ElementsDownedAque
        {
            get { return ElementsAwoken.MyWorld.downedAqueous; }
        }

        public bool ElementsDownedEye
        {
            get { return ElementsAwoken.MyWorld.downedEye; }
        }

        public bool ElementsDownedDragon
        {
            get { return ElementsAwoken.MyWorld.downedAncientDragon; }
        }

        public bool ElementsDownedGuardian
        {
            get { return ElementsAwoken.MyWorld.downedGuardian; }
        }

        public bool ElementsDownedVoid
        {
            get { return ElementsAwoken.MyWorld.downedVoidLeviathan; }
        }

        //antiaris
        public bool AntiarisDownedAntlion
        {
            get { return Antiaris.AntiarisWorld.DownedAntlionQueen; }
        }

        //disarray
        public bool DisarrayDownedPlant
        {
            get { return Disarray.DisarrayWorld.downedPlantKing; }
        }

        public bool DisarrayDownedCrusher
        {
            get { return Disarray.DisarrayWorld.downedDesertCrusher; }
        }

        public bool DisarrayDownedProbe
        {
            get { return Disarray.DisarrayWorld.downedProbeMother; }
        }

        public bool DisarrayDownedGeneral
        {
            get { return Disarray.DisarrayWorld.downedTheGeneral; }
        }

        public bool DisarrayDownedSerpent
        {
            get { return Disarray.DisarrayWorld.downedLunarSerpent; }
        }

        public bool DisarrayDownedCold
        {
            get { return Disarray.DisarrayWorld.downedColdBoss; }
        }

        public bool DisarrayDownedShadows
        {
            get { return Disarray.DisarrayWorld.downedShadows; }
        }

        public bool DisarrayDownedLuna
        {
            get { return Disarray.DisarrayWorld.downedLuna; }
        }

        public bool DisarrayDownedBell
        {
            get { return Disarray.DisarrayWorld.downedBell; }
        }

        public bool DisarrayDownedMech
        {
            get { return Disarray.DisarrayWorld.downedMech; }
        }

        public bool DisarrayDownedSludge
        {
            get { return Disarray.DisarrayWorld.downedCosmicSludge; }
        }

        public bool DisarrayDownedDeva
        {
            get { return Disarray.DisarrayWorld.downedCoreOfTheDevastator; }
        }

        public bool DisarrayDownedMeteor
        {
            get { return Disarray.DisarrayWorld.downedMeteorzoid; }
        }

        public bool DisarrayDownedDungeon
        {
            get { return Disarray.DisarrayWorld.downedDungeon; }
        }

        //cookie
        public bool CookieDownedCookie
        {
            get { return CookieMod.CookieModWorld.downedCookieBoss; }
        }

        public bool CookieDownedBunny
        {
            get { return CookieMod.CookieModWorld.downedBunny; }
        }

        //enigma
        public bool EnigmaDownedAnnih
        {
            get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }

        public bool EnigmaDownedSlyber
        {
            get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }

        public bool EnigmaDownedTrain
        {
            get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }

        public bool EnigmaDownedShark
        {
            get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }

        public bool EnigmaDownedHypo
        {
            get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }

        public bool EnigmaDownedRagnar
        {
            get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }

        public bool EnigmaDownedRocks
        {
            get { return Laugicality.LaugicalityWorld.downedRocks; }
        }

        public bool EnigmaDownedEther
        {
            get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }

        #endregion other mod bools

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return FargoWorld.downedBoss;
        }

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
            if (NPC.downedMoonlord && Main.rand.Next(28) == 0)
            {
                return "Now that you've defeated the big guy, I'd say it's time to start collecting those materials! ;)";
            }

            if (Main.bloodMoon == true)
            {
                switch (Main.rand.Next(1))
                {
                    case 0:
                        return "Lovely night, isn't it?";

                    default:
                        return "I hope the constant arguing I'm hearing isn't my fault.";
                }
            }

            if (BirthdayParty.PartyIsUp == true)
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
        I heard you liked fighting sealed bosses(reference to the ancient seal)

        //will he ever sell souls ? idk

        oh is that a soul of the universe? Fascinating I'll get all mine from the back

        Oh wow is that a speed soul. I coulda sold you one man

        //all souls need one

        "I know, I know, these souls look really pricy, buy I'm selling them at a loss here! Nobody would buy them otherwise! What a ripoff!"
        */

        public override void SetChatButtons(ref string button, ref string button2)
        {
            if (shopnum == 1)
            {
                button = "Pre Hardmode";
            }
            else if (shopnum == 2)
            {
                button = "Hardmode";
            }
            else
            {
                button = "Post Moon Lord";
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

                if (shopnum == 1)
                {
                    shop1 = true;
                    shop2 = false;
                    shop3 = false;
                }
                else if (shopnum == 2)
                {
                    shop2 = true;
                    shop1 = false;
                    shop3 = false;
                }
                else
                {
                    shop3 = true;
                    shop1 = false;
                    shop2 = false;
                }
            }

            if (!firstButton && Main.hardMode)
            {
                shopnum++;
            }
        }

        private void AddItem(bool check, string mod, string item, int price, ref Chest shop, ref int nextSlot)
        {
            if (check)
            {
                shop.item[nextSlot].SetDefaults(ModLoader.GetMod(mod).ItemType(item));
                shop.item[nextSlot].value = price;
                nextSlot++;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            #region PREHARDMODE BOSSES

            if (shop1)
            {
                AddItem(true, "Fargowiltas", "Overloader", 500000, ref shop, ref nextSlot);

                //AddItem(true, mod.ItemType("PandorasBox"), 200000, shop, nextSlot);

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

                //abomination rematch - bluw

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
            if (NPC.downedMoonlord == true)
            {
                cooldown = 1;
                //randExtraCooldown = 1;
            }
            else if (Main.hardMode == true)
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
            if (NPC.downedMoonlord == true)
            {
                projType = mod.ProjectileType("PhantasmalEyeProjectile");
                attackDelay = 1;
            }
            else if (Main.hardMode == true)
            {
                projType = mod.ProjectileType("MechEyeProjectile");
                attackDelay = 1;
            }
            else
            {
                projType = mod.ProjectileType("EyeProjectile");
                attackDelay = 1;
            }
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
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore3"), 1f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore2"), 1f);
                }
                for (int k = 0; k < 1; k++)
                {
                    Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
                    Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/MutantGore1"), 1f);
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