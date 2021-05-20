using Microsoft.Xna.Framework;

namespace JetWars
{
    public class FireSpeedIncreaser : Item
    {
        public FireSpeedIncreaser(Vector2 position)
        : base("fire-speed", position, new Vector2(25, 25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.IncreaseFireSpeed();
        }
    }
}
