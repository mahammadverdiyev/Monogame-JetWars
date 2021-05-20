using Microsoft.Xna.Framework;

namespace JetWars
{
    public class GamePlay
    {
        private int gameState;

        private World world;

        public GamePlay()
        {
            gameState = 0;

            ResetWorld(null);
        }

        public virtual void Update()
        {
            if(gameState == 0)
                world.Update();
        }

        public virtual void ResetWorld(object data)
        {
            world = new World(ResetWorld);
        }
        public virtual void Draw()
        {
            if (gameState == 0)
                world.Draw(Vector2.Zero);
        }
    }
}
