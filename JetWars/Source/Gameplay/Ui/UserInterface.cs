#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using JetWars.Source.Engine.Output;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars.Source.Gameplay
{
    public class UserInterface
    {

        public SpriteFont font;

        public DisplayBar healthBar;

        public UserInterface()
        {
            font = Globals.content.Load<SpriteFont>("Arial");

            healthBar = new DisplayBar(new Vector2(200,20), 2, Color.Red);
        }

        public void Update(World world)
        {
            healthBar.Update(GameGlobals.playerJet.health, GameGlobals.playerJet.maxHealth);
        }
        public void Draw(World world)
        {
            string str = $"Destroyed: {world.destroyedJetCount}";
            Vector2 strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str,new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2,Globals.screenHeight - strDimensions.Y), Color.White);
            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

            if(GameGlobals.playerJet.destroyed)
            {
                str = $"Press Enter to Restart";
                strDimensions = font.MeasureString(str);
                Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2, Globals.screenHeight / 2), Color.White);
            }
        }
    }
}
