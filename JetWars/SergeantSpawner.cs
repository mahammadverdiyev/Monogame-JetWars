using Microsoft.Xna.Framework;

namespace JetWars
{
    public class SergeantSpawner : ModelSpawner
    {
        public SergeantSpawner(Vector2 position, int maxModelCount)
        : base("circle", position, new Vector2(25,25), maxModelCount, 5000)
  
        {
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
