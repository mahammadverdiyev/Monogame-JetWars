using Microsoft.Xna.Framework;

namespace JetWars
{
    public class CorporalSpawner : ModelSpawner
    {
        public CorporalSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
        : base("circle", position, dimension, maxModelCount, 1000)
        {
            spawnTimer = new METimer(3000);
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
