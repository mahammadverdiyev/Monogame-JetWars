using Microsoft.Xna.Framework;

namespace JetWars
{
    public class AccuracyIncreaser : Item
    {
        public AccuracyIncreaser(Vector2 position)
        : base("accuracy", position, new Vector2(25, 25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.IncreaseAccuracy();
        }
    }
}
