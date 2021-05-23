using Microsoft.Xna.Framework;

namespace JetWars
{
    public class CorporalSpawner : ModelSpawner
    {
        public CorporalSpawner(Vector2 position,int maxModelCount)
        : base("circle", position, new Vector2(25,25), maxModelCount, 1500)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new CorporalEnemyJet(new Vector2(position.X, position.Y), 2.0f));
        }
    }
}
