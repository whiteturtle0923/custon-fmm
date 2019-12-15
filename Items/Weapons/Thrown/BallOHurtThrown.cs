using Terraria.ID;

namespace Fargowiltas.Items.Weapons.Thrown
{
    public class BallOHurtThrown : BaseThrownItem
    {
        public override int Type => ItemID.BallOHurt;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ball O' Hurt Thrown");
        }
    }
}