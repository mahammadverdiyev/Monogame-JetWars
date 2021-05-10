using JetWars.Source.Gameplay.Models.Abstracts;
using Microsoft.Xna.Framework;

namespace JetWars.Source.Gameplay.Models.Items
{
    public class MedKit : Item
    {
        public MedKit(Vector2 position)
        : base("ait-kit",position,new Vector2(25,25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.MaximizeHealth();
        }
    }
}
