using Microsoft.Xna.Framework;

namespace JetWars
{
    public class MajorSpawner : ModelSpawner
    {

        public MajorSpawner(Vector2 position, Vector2 dimension, int maxModelCount) 
            : base("circle", position, dimension, maxModelCount,5000)
        {
            
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new MajorEnemyJet(new Vector2(position.X, position.Y), 5.0f));

        }
    }
}
