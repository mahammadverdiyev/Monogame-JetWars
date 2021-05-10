using JetWars.Source.Gameplay.Models.Abstracts;
using Microsoft.Xna.Framework;

namespace JetWars.Source.Gameplay.Models.Items
{
    public class MaxHealthIncreaser : Item
    {
        public MaxHealthIncreaser(Vector2 position)
        : base("health-capacity", position, new Vector2(25, 25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.IncreaseMaxHealth();
        }
    }
}
