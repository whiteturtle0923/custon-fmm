using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class GoblinHead : ModItem
    {
        public static Item target;
        public static bool weapon = false;
        public static bool accessory = false;
        public static int counter = 0;
        public static int index = 0;

        private byte[] weaponPrefixes = new byte[] {  PrefixID.Ruthless, PrefixID.Godly, PrefixID.Demonic, PrefixID.Legendary, PrefixID.Unreal, PrefixID.Mythical };

        private string[] weaponPrefixNames = new string[] { "Ruthless", "Godly", "Demonic", "Legendary", "Unreal", "Mythical" };

        private byte[] accessoryPrefixes = new byte[] { PrefixID.Warding, PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick2, PrefixID.Violent };

        private string[] accessoryPrefixNames = new string[] { "Warding", "Arcane", "Lucky", "Menacing", "Quick", "Violent"  };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cheapskate's End");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[Main.myPlayer];

            for (int i = 0; i < 50; i++)
            {
                if (player.inventory[i] != null && player.inventory[i].type == mod.ItemType("GoblinHead"))
                {
                    target = player.inventory[++i];
                    break;
                }
            }

            if (target == null)
            {
                tooltips.Add(new TooltipLine(mod, "1", "This goblin head seems drawn to weapons and accessories"));
                return;
            }
            else if (target.accessory)
            {
                accessory = true;
                weapon = false;
            }
            else if (target.damage > 0)
            {
                accessory = false;
                weapon = true;
            }
            else
            {
                tooltips.Add(new TooltipLine(mod, "1", "This goblin head seems drawn to weapons and accessories"));
                return;
            }

            counter++;

            if (counter > 60)
            {
                counter = 0;
                index++;
            }

            if ((accessory && index >= accessoryPrefixes.Length) || (weapon && index >= weaponPrefixes.Length))
            {
                index = 0;
            }

            if (accessory)
            {
                tooltips.Add(new TooltipLine(mod, "1", "Right click to give the item to the right of this the " + accessoryPrefixNames[index] + " prefix"));
            }
            else if (weapon)
            {
                tooltips.Add(new TooltipLine(mod, "1", "Right click to give the item to the right of this the " + weaponPrefixNames[index] + " prefix"));
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 0;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override string Texture => "Terraria/NPC_Head_9";

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (target == null) return;

            target.SetDefaults(target.type);

            if (accessory)
            {
                target.Prefix(accessoryPrefixes[index]);
            }
            else if (weapon)
            {
                target.Prefix(weaponPrefixes[index]);
            }
        }
    }
}