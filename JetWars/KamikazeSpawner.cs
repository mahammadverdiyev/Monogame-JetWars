using Microsoft.Xna.Framework;

namespace JetWars
{
   public class KamikazeSpawner : ModelSpawner
    {
        public KamikazeSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
            : base("circle", position, dimension, maxModelCount, 5000)
        {
            spawnTimer = new CustomTimer(500);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new Kamikaze(new Vector2(position.X, position.Y), 10));
        }
    }
}
