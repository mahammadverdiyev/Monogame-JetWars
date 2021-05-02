using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace JetWars.Source
{
    public class Background : Basic2D
    {
        public Rectangle backgroundBox;
        public Background(string path, Rectangle bgBox) 
            : base(path, new Vector2(bgBox.X,bgBox.Y), new Vector2(bgBox.Width,bgBox.Height))
        {
            backgroundBox = bgBox;
        }

        public override void Draw(Vector2 OFFSET)
        {
            Globals.spriteBatch.Draw(model, backgroundBox, Color.White);
        }
    }
}
