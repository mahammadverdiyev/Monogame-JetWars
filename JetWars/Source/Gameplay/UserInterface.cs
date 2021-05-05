#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
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
        public UserInterface()
        {
            font = Globals.content.Load<SpriteFont>("Arial");
        }

        public void Update(World world)
        {

        }
        public void Draw(World world)
        {
            string str = $"Destroyed: {world.destroyedJetCount}";
            Vector2 strDimensions = font.MeasureString(str);
            Globals.spriteBatch.DrawString(font, str,new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2,Globals.screenHeight - strDimensions.Y), Color.White);
        }
    }
}
