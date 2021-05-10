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

            healthBar = new DisplayBar(new Vector2(200,20), 2, Color.Green);
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

            int margin_right = 15;
            str = $"Jet speed: {GameGlobals.playerJet.speed}";
            strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 4 * strDimensions.Y), Color.White);

            str = $"Firing speed: {GameGlobals.playerJet.bulletFireSpeed}";
            strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 3 * strDimensions.Y), Color.White);

            str = $"Accuracy: {GameGlobals.playerJet.accuracyValue}";
            strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 2 * strDimensions.Y), Color.White);

            str = $"Max health: {GameGlobals.playerJet.maxHealth}";
            strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 1 * strDimensions.Y), Color.White);

            if (GameGlobals.playerJet.destroyed)
            {
                str = $"Press Enter to Restart";
                strDimensions = font.MeasureString(str);
                Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2, Globals.screenHeight / 2), Color.White);
            }
        }
    }
}
