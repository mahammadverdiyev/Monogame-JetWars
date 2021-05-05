using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace JetWars.Source
{
    public class ScrollingBackground : Background
    {
        private int scrollingSpeed;

        public ScrollingBackground(string path, Rectangle bgBox,int scrollingSpeed) : base(path,bgBox)
        {
            this.scrollingSpeed = scrollingSpeed;
        }

        public override void Update()
        {
            float delta = (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;
            backgroundBox.Y += scrollingSpeed * (int)Math.Ceiling(delta);
        }

    }
}
