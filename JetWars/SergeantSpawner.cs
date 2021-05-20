using Microsoft.Xna.Framework;

namespace JetWars
{
    public class SergeantSpawner : ModelSpawner
    {
        public SergeantSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
        : base("circle", position, dimension, maxModelCount, 3000)
  
        {
            spawnTimer = new METimer(10000);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new SergeantEnemyJet(new Vector2(position.X, position.Y), 4.0f));
        }
    }
}
