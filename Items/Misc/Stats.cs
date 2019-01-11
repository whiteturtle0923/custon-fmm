using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Misc
{
    public class Stats : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stat Sheet");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 38;
            item.maxStack = 1;
            item.value = 0;
            item.rare = 0;
            item.consumable = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[item.owner];

            TooltipLine[] lines = new TooltipLine[15];
            lines[0] = new TooltipLine(mod, "1", "Life Regen: " + player.lifeRegen + " HP/second");
            lines[1] = new TooltipLine(mod, "2", "Damage Reduction: " + player.endurance * 100 + "%");
            lines[2] = new TooltipLine(mod, "3", "Melee Damage: " + player.meleeDamage * 100 + "%");
            lines[3] = new TooltipLine(mod, "4", "Melee Speed: " + player.meleeSpeed * 100 + "%");
            lines[4] = new TooltipLine(mod, "5", "Ranged Damage: " + player.rangedDamage * 100 + "%");
            lines[5] = new TooltipLine(mod, "6", "Magic Damage: " + player.magicDamage * 100 + "%");
            lines[6] = new TooltipLine(mod, "7", "Summon Damage: " + player.minionDamage * 100 + "%");
            lines[7] = new TooltipLine(mod, "8", "Max Minions: " + player.maxMinions);
            lines[8] = new TooltipLine(mod, "9", "Throwing Damage: " + player.thrownDamage * 100 + "%");
            lines[9] = new TooltipLine(mod, "10", "Melee Crit: " + player.meleeCrit + "%");
            lines[10] = new TooltipLine(mod, "11", "Ranged Crit: " + player.rangedCrit + "%");
            lines[11] = new TooltipLine(mod, "12", "Magic Crit: " + player.magicCrit + "%");
            lines[12] = new TooltipLine(mod, "13", "Throwing Crit: " + player.thrownCrit + "%");
            lines[13] = new TooltipLine(mod, "14", "Max Speed: " + (player.accRunSpeed + player.maxRunSpeed) / 2f * player.moveSpeed * 6 + " mph"); 
            lines[14] = new TooltipLine(mod, "15", "Wing Time: " + player.wingTimeMax / 60 + " seconds");

            for (int i = 0; i < lines.Length; i++)
            {
                tooltips.Add(lines[i]);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sign);
            recipe.AddIngredient(ItemID.CopperAxe);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}