using Terraria.ID;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class BatteredClub : BaseSummon
    {
        public override int Type => NPCID.DD2OgreT3;

        public override string NPCName => "Ogre";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battered Club ");
            Tooltip.SetDefault("Summons the Ogre");
        }
    }
}