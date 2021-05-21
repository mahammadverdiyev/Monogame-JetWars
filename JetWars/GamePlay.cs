using Microsoft.Xna.Framework;

namespace JetWars
{
    public class GamePlay
    {
        private World world;

        private Game game;

        public GamePlay(Game game)
        {
            this.game = game;

            ResetWorld(null);
        }

        public virtual void Update()
        {
                world.Update();
        }

        public virtual void ResetWorld(object data)
        {
            world = new World(game, ResetWorld);
        }
        public virtual void Draw()
        {
                world.Draw(Vector2.Zero);
        }
    }
}
