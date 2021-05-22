using Microsoft.Xna.Framework;

namespace JetWars
{
    public class JetSpeedIncreaser : Item
    {
        public JetSpeedIncreaser(Vector2 position)
        : base("jet-speed", position, new Vector2(35, 35))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.IncreaseJetSpeed();
        }
    }
}
