#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace JetWars
{
    public class GeneralSpawner : ModelSpawner
    {
        public GeneralSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
        : base("circle", position, dimension, maxModelCount,20000)
        {
            spawnTimer = new METimer(100);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new GeneralEnemyJet(new Vector2(position.X, position.Y), 5.0f));
        }
    }
}
