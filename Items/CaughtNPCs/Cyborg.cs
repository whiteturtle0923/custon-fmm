using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Fargowiltas.Items.CaughtNPCs
{
    public class Cyborg : CaughtNPC
    {
        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Cyborg");
            Tooltip.SetDefault("'My expedition efficiency was critically reduced when a projectile impacted my locomotive actuator.'");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.makeNPC = NPCID.Cyborg;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 26));
        }

        public override string Texture => "Terraria/NPC_209";
    }
}