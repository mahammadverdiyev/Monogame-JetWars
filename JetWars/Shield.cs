using Microsoft.Xna.Framework;

namespace JetWars
{
    public class Shield : Item
    {
        public Shield(Vector2 position)
        : base("shield", position, new Vector2(25, 25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.ActivateShield();
        }
    }
}
