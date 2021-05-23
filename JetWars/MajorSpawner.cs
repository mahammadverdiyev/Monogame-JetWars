using Microsoft.Xna.Framework;

namespace JetWars
{
    public class MajorSpawner : ModelSpawner
    {

        public MajorSpawner(Vector2 position,int maxModelCount) 
            : base("circle", position, new Vector2(25,25), maxModelCount,8000)
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
