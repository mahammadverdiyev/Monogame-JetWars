#region Includes
using Microsoft.Xna.Framework;
#endregion

namespace JetWars
{
    public class GeneralSpawner : ModelSpawner
    {
        public GeneralSpawner(Vector2 position, int maxModelCount)
        : base("circle", position, new Vector2(25,25), maxModelCount,10000)
        {
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
