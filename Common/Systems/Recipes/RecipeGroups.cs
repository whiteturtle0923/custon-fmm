using Fargowiltas.Items.Ammos.Bullets;
using Fargowiltas.Items.Tiles;
using Fargowiltas.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Common.Systems.Recipes
{
    public class RecipeGroups : ModSystem
    {
        internal static int AnyGoldBar;
        internal static int AnyDemonAltar, AnyAnvil, AnyHMAnvil, AnyForge, AnyBookcase, AnyCookingPot, AnyTombstone;
        internal static int AnyButterfly, AnySquirrel, AnyCommonFish, AnyDragonfly, AnyBird, AnyDuck;

        public override void AddRecipeGroups()
        {
            //Silver or Tungsten Pouch (Used in Souls Mod)
            var group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ModContent.ItemType<SilverPouch>()), ModContent.ItemType<SilverPouch>(), ModContent.ItemType<TungstenPouch>());
            RecipeGroup.RegisterGroup("Fargowiltas:AnySilverPouch", group);

            //gold bar
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.GoldBar), ItemID.GoldBar, ItemID.PlatinumBar);
            AnyGoldBar = RecipeGroup.RegisterGroup("Fargowiltas:AnyGoldBar", group);

            //demon altar
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ModContent.ItemType<DemonAltar>()), ModContent.ItemType<DemonAltar>(), ModContent.ItemType<CrimsonAltar>());
            AnyDemonAltar = RecipeGroup.RegisterGroup("Fargowiltas:AnyDemonAltar", group);

            //iron anvil
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.IronAnvil), ItemID.IronAnvil, ItemID.LeadAnvil);
            AnyAnvil = RecipeGroup.RegisterGroup("Fargowiltas:AnyAnvil", group);

            //anvil HM
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.MythrilAnvil), ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            AnyHMAnvil = RecipeGroup.RegisterGroup("Fargowiltas:AnyHMAnvil", group);

            //forge HM
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.AdamantiteForge), ItemID.AdamantiteForge, ItemID.TitaniumForge);
            AnyForge = RecipeGroup.RegisterGroup("Fargowiltas:AnyForge", group);

            //book cases
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Bookcase),
                ItemID.Bookcase, ItemID.BlueDungeonBookcase, ItemID.BoneBookcase, ItemID.BorealWoodBookcase,
                ItemID.CactusBookcase, ItemID.CrystalBookCase, ItemID.DynastyBookcase, ItemID.EbonwoodBookcase,
                ItemID.FleshBookcase, ItemID.FrozenBookcase, ItemID.GlassBookcase, ItemID.GoldenBookcase,
                ItemID.GothicBookcase, ItemID.GraniteBookcase, ItemID.GreenDungeonBookcase, ItemID.HoneyBookcase,
                ItemID.LivingWoodBookcase, ItemID.MarbleBookcase, ItemID.MeteoriteBookcase, ItemID.MushroomBookcase,
                ItemID.ObsidianBookcase, ItemID.PalmWoodBookcase, ItemID.PearlwoodBookcase, ItemID.PinkDungeonBookcase,
                ItemID.PumpkinBookcase, ItemID.RichMahoganyBookcase, ItemID.ShadewoodBookcase, ItemID.SkywareBookcase,
                ItemID.SlimeBookcase, ItemID.SpookyBookcase, ItemID.SteampunkBookcase
            );
            AnyBookcase = RecipeGroup.RegisterGroup("Fargowiltas:AnyBookcase", group);

            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.CookingPot), ItemID.CookingPot, ItemID.Cauldron);
            AnyCookingPot = RecipeGroup.RegisterGroup("Fargowiltas:AnyCookingPot", group);

            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("LegacyMisc.87", true),
                ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly, ItemID.RedAdmiralButterfly,
                ItemID.SulphurButterfly, ItemID.TreeNymphButterfly, ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly,
                ItemID.HellButterfly
            );
            AnyButterfly = RecipeGroup.RegisterGroup("Fargowiltas:AnyButterfly", group);

            //vanilla squirrels
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Squirrel),
                ItemID.Squirrel,
                ItemID.SquirrelRed
            );
            AnySquirrel = RecipeGroup.RegisterGroup("Fargowiltas:AnySquirrel", group);

            //vanilla squirrels
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("CommonFish"),
                ItemID.AtlanticCod,
                ItemID.Bass,
                ItemID.Trout,
                ItemID.RedSnapper,
                ItemID.Salmon,
                ItemID.Tuna
            //ItemID.GoldenCarp
            );
            AnyCommonFish = RecipeGroup.RegisterGroup("Fargowiltas:AnyCommonFish", group);

            //vanilla dragonfly
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText("LegacyMisc.105", true),
                //ItemID.GoldDragonfly,
                ItemID.BlackDragonfly,
                ItemID.BlueDragonfly,
                ItemID.GreenDragonfly,
                ItemID.OrangeDragonfly,
                ItemID.RedDragonfly,
                ItemID.YellowDragonfly
            );
            AnyDragonfly = RecipeGroup.RegisterGroup("Fargowiltas:AnyDragonfly", group);

            //vanilla birds
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Bird),
                ItemID.Bird,
                //ItemID.GoldBird,
                ItemID.BlueJay,
                ItemID.Cardinal,
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe,
                ItemID.Seagull
            );
            AnyBird = RecipeGroup.RegisterGroup("Fargowiltas:AnyBird", group);

            //vanilla ducks
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Duck),
                ItemID.Duck,
                ItemID.MallardDuck,
                ItemID.Grebe
            );
            AnyDuck = RecipeGroup.RegisterGroup("Fargowiltas:AnyDuck", group);

            //tombstones
            group = new RecipeGroup(() => RecipeHelper.GenerateAnyItemRecipeGroupText(ItemID.Tombstone),
                ItemID.Tombstone,
                ItemID.CrossGraveMarker,
                ItemID.Headstone,
                ItemID.GraveMarker,
                ItemID.Gravestone,
                ItemID.Obelisk,
                ItemID.RichGravestone1,
                ItemID.RichGravestone2,
                ItemID.RichGravestone3,
                ItemID.RichGravestone4,
                ItemID.RichGravestone5
            );
            AnyTombstone = RecipeGroup.RegisterGroup("Fargowiltas:AnyTombstone", group);
        }
    }
}
