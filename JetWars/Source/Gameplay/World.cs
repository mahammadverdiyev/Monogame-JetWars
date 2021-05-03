using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetWars.Source;
using JetWars.Source.Gameplay.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public class World
    {
        public PlayerJet playerJet;
        public ScrollingBackground bg1;
        public ScrollingBackground bg2;

        public World()
        {
            playerJet = new PlayerJet();
            bg1 = new ScrollingBackground("star1",new Rectangle(0,0,900,675), 1);
            bg2 = new ScrollingBackground("star2", new Rectangle(0, -675,900,675), 1);
        }

        public void Update(GameTime gameTime)
        {
            AdjustBackground();

            bg1.Update(gameTime);
            bg2.Update(gameTime);

            playerJet.Update(gameTime);
        }

        private void AdjustBackground()
        {
            if (bg1.backgroundBox.Y >= Globals.screenHeight)
                bg1.backgroundBox.Y = bg2.backgroundBox.Y - bg2.backgroundBox.Height;

            if (bg2.backgroundBox.Y >= Globals.screenHeight)
                bg2.backgroundBox.Y = bg1.backgroundBox.Y - bg1.backgroundBox.Height;
        }

        public void Draw(Vector2 OFFSET)
        {
            bg1.Draw(Vector2.Zero);
            bg2.Draw(Vector2.Zero);
            playerJet.Draw(OFFSET);
        }
    }
}
