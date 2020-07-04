using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;
using System;
using Terraria.ModLoader.IO;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        internal bool BattleCry;

        private int oldSelected;
        private bool isReuse = false;

        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem = false;


        internal Dictionary<string, bool> FirstDyeIngredients = new Dictionary<string, bool>();
            
        private readonly string[] tags = new string[]
       {
            "RedHusk",
            "OrangeBloodroot",
            "YellowMarigold",
            "LimeKelp",
            "GreenMushroom",
            "TealMushroom",
            "CyanHusk",
            "SkyBlueFlower",
            "BlueBerries",
            "PurpleMucos",
            "VioletHusk",
            "PinkPricklyPear",
            "BlackInk"
       };

        public override TagCompound Save()
        {
            string name = "FargoDyes" + player.name;
            List<string> dyes = new List<string>();
            foreach (string tag in tags)
            {
                bool value;

                if (FirstDyeIngredients.TryGetValue(tag, out value))
                {
                    dyes.AddWithCondition(tag, FirstDyeIngredients[tag]);
                }
                else
                {
                    dyes.AddWithCondition(tag, false);
                }
            }

            return new TagCompound
            {
                { name, dyes },
            };
        }

        public override void Load(TagCompound tag)
        {
            string name = "FargoDyes" + player.name;

            IList<string> dyes = tag.GetList<string>(name);
            foreach (string downedTag in tags)
            {
                FirstDyeIngredients[downedTag] = dyes.Contains(downedTag);
            }
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ItemType<Items.Misc.Stats>());
            items.Add(item);

            foreach (string tag in tags)
            {
                FirstDyeIngredients[tag] = false;
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Fargowiltas.CustomKey.JustPressed)
            {
                QuickUseItemAt(40);
            }

            if (Fargowiltas.RodKey.JustPressed)
            {
                AutoUseRod();
            }

            if (Fargowiltas.HomeKey.JustPressed)
            {
                AutoUseMirror();
            }
        }

        /*private void Fargos()
        {
            if (player.GetModPlayer<FargowiltasSouls.FargoPlayer>().NinjaEnchant)
            {
                player.AddBuff(ModLoader.GetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
            }
        }*/

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (player.itemTime == 0 && player.itemAnimation == 0)
                {
                    player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }
        }

        public override void PostUpdateEquips()
        {
            Mod soulsMod = ModLoader.GetMod("FargowiltasSouls");
            
            if (Fargowiltas.SwarmActive)
            {
                player.buffImmune[BuffID.Horrified] = true;
            }

            
            for (int i = 0; i < player.bank.item.Length; i++)
            {
                Item item = player.bank.item[i];

                if (item.active && Array.IndexOf(Informational, item.type) > -1)
                {
                    player.VanillaUpdateEquip(item);
                }
            }
        }

        int[] Informational = { ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.DPSMeter, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone};

        public override void UpdateBiomes()
        {
            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.eaterBoss, NPCID.EaterofWorldsHead))
            {
                player.ZoneCorrupt = true;
            }

            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.brainBoss, NPCID.BrainofCthulhu))
            {
                player.ZoneCrimson = true;
            }

            if (FargoGlobalNPC.BossIsAlive(ref FargoGlobalNPC.plantBoss, NPCID.Plantera))
            {
                player.ZoneJungle = true;
            }

            if (GetInstance<FargoConfig>().Fountains)
            {
                switch (Main.fountainColor)
                {
                    case 0:
                        player.ZoneBeach = true;
                        break;
                    case 6:
                        player.ZoneDesert = true;
                        break;
                    case 3:
                        player.ZoneJungle = true;
                        break;
                    case 5:
                        player.ZoneSnow = true;
                        break;
                    case 2:
                        player.ZoneCorrupt = true;
                        break;
                    case 10:
                        player.ZoneCrimson = true;
                        break;
                    case 4:
                        if (Main.hardMode)
                        {
                            player.ZoneHoly = true;
                        }
                        break;

                        //oasis and cavern fountains
                }
            }
            

        }
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            int num15 = 150;
            int num18 = num15 * 7 / power;
            if (num18 < 4)
            {
                num18 = 4;
            }
            bool flag5 = false;
            if (Main.rand.Next(num18) == 0)
            {
                flag5 = true;
            }
            int num21 = 10;
            if (player.cratePotion)
            {
                num21 += 10;
            }
            if (Main.rand.Next(100) < num21)
            {
                if (flag5 && liquidType == 0 && player.ZoneSnow)
                {
                    caughtType = mod.ItemType("IceCrate");
                }
                else if (flag5 && liquidType == 1 && ItemID.Sets.CanFishInLava[fishingRod.type] && player.ZoneUnderworldHeight)
                {
                    caughtType = mod.ItemType("ShadowCrate");
                }
            }
        }

        public void AutoUseMirror()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                switch (player.inventory[i].type)
                {
                    case ItemID.RecallPotion:
                    case ItemID.MagicMirror:
                    case ItemID.IceMirror:
                    case ItemID.CellPhone:
                        QuickUseItemAt(i);
                        break;
                }
            }
        }

        public void AutoUseRod()
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ItemID.RodofDiscord)
                {
                    QuickUseItemAt(i);
                    break;
                }
            }
        }

        public void QuickUseItemAt(int index, bool use = true)
        {
            if (!autoRevertSelectedItem && player.selectedItem != index && player.inventory[index].type != 0)
            {
                originalSelectedItem = player.selectedItem;
                autoRevertSelectedItem = true;
                player.selectedItem = index;
                player.controlUseItem = true;
                if (use)
                {
                    player.ItemCheck(Main.myPlayer);
                }
            }
        }
    }
}
