using Microsoft.Xna.Framework;

namespace JetWars
{
   public class KamikazeSpawner : ModelSpawner
    {
        public KamikazeSpawner(Vector2 position, int maxModelCount)
            : base("circle", position, new Vector2(25,25), maxModelCount, 1000)
        {
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
