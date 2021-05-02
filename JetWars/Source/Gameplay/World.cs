using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetWars.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public class World
    {
        public Jet jet;
        public ScrollingBackground bg1;
        public ScrollingBackground bg2;

        public World()
        {
            jet = new Jet("jet", new Vector2(300, 300), new Vector2(50, 50));
            bg1 = new ScrollingBackground("star1",new Rectangle(0,0,900,675),2);
            bg2 = new ScrollingBackground("star2", new Rectangle(0, -675,900,675),2);
        }
        public virtual void Update()
        {
            AdjustBackground();

            bg1.Update();
            bg2.Update();

            jet.Update();
        }

        private void AdjustBackground()
        {
            if (bg1.backgroundBox.Y >= Globals.screenHeight)
                bg1.backgroundBox.Y = bg2.backgroundBox.Y - bg2.backgroundBox.Height;

            if (bg2.backgroundBox.Y >= Globals.screenHeight)
                bg2.backgroundBox.Y = bg1.backgroundBox.Y - bg1.backgroundBox.Height;

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            bg1.Draw(Vector2.Zero);
            bg2.Draw(Vector2.Zero);
            jet.Draw(OFFSET);
        }
    }
}
