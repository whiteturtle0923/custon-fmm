using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class BakeSale : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bake Sale");
            Tooltip.SetDefault(@"Summons any lost Town NPCs");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 1000;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
        }

        public override bool UseItem(Player player)
        {
            NPC npc = new NPC();
            for (int i = NPCID.Count; i < Main.npcTexture.Length; i++)
            {
                npc.SetDefaults(i);
                if (npc.townNPC && NPC.TypeToHeadIndex(npc.type) >= 0 && npc.modNPC.CanTownNPCSpawn(100, 2000000000))
                {
                    Spawn(player, npc.type);
                }
            }

            if (FargoWorld.guide)
            {
                Spawn(player, NPCID.Guide);
            }
            if (FargoWorld.merch)
            {
                Spawn(player, NPCID.Merchant);
            }
            if (FargoWorld.nurse)
            {
                Spawn(player, NPCID.Nurse);
            }
            if (FargoWorld.demo)
            {
                Spawn(player, NPCID.Demolitionist);
            }
            if (FargoWorld.dye)
            {
                Spawn(player, NPCID.DyeTrader);
            }
            if (FargoWorld.dryad)
            {
                Spawn(player, NPCID.Dryad);
            }
            if (FargoWorld.keep)
            {
                Spawn(player, NPCID.DD2Bartender);
            }
            if (FargoWorld.dealer)
            {
                Spawn(player, NPCID.ArmsDealer);
            }
            if (FargoWorld.style)
            {
                Spawn(player, NPCID.Stylist);
            }
            if (FargoWorld.paint)
            {
                Spawn(player, NPCID.Painter);
            }
            if (FargoWorld.angler)
            {
                Spawn(player, NPCID.Angler);
            }
            if (FargoWorld.goblin)
            {
                Spawn(player, NPCID.GoblinTinkerer);
            }
            if (FargoWorld.doc)
            {
                Spawn(player, NPCID.WitchDoctor);
            }
            if (FargoWorld.cloth)
            {
                Spawn(player, NPCID.Clothier);
            }
            if (FargoWorld.mech)
            {
                Spawn(player, NPCID.Mechanic);
            }
            if (FargoWorld.party)
            {
                Spawn(player, NPCID.PartyGirl);
            }
            if (FargoWorld.wiz)
            {
                Spawn(player, NPCID.Wizard);
            }
            if (FargoWorld.tax)
            {
                Spawn(player, NPCID.TaxCollector);
            }
            if (FargoWorld.truf)
            {
                Spawn(player, NPCID.Truffle);
            }
            if (FargoWorld.pirate)
            {
                Spawn(player, NPCID.Pirate);
            }
            if (FargoWorld.steam)
            {
                Spawn(player, NPCID.Steampunker);
            }
            if (FargoWorld.borg)
            {
                Spawn(player, NPCID.Cyborg);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        private void Spawn(Player player, int type)
        {
            NPC npc = new NPC();
            npc.SetDefaults(type);

            if (!NPC.AnyNPCs(type))
            {
                NPC.NewNPC((int)player.position.X + Main.rand.Next(-200, 200), (int)player.position.Y - 50, type);
                Main.NewText("The " + npc.TypeName + " has arrived!", 175, 75);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.KingStatue);
            recipe.AddIngredient(ItemID.QueenStatue);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddTile(TileID.Tables);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}