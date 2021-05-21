using Microsoft.Xna.Framework;

namespace JetWars
{
    public abstract class Background : Basic2D
    {
        public Rectangle backgroundBox;
        public Background(string path, Rectangle bgBox)
            : base(path, new Vector2(bgBox.X, bgBox.Y), new Vector2(bgBox.Width, bgBox.Height))
        {
            backgroundBox = bgBox;
        }

        public override void Draw(Vector2 OFFSET)
        {
            Globals.spriteBatch.Draw(model, backgroundBox, Color.White);
        }
    }
}