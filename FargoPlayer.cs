using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas.NPCs;

namespace Fargowiltas
{
    public class FargoPlayer : ModPlayer
    {
        internal bool BattleCry;

        private int oldSelected;
        private bool isReuse = false;

        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem = false;

        public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ItemType<Items.Misc.Stats>());
            items.Add(item);
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

        private void Fargos()
        {
            if (player.GetModPlayer<FargowiltasSouls.FargoPlayer>().NinjaEnchant)
            {
                player.AddBuff(ModLoader.GetMod("FargowiltasSouls").BuffType("FirstStrike"), 60);
            }
        }

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
