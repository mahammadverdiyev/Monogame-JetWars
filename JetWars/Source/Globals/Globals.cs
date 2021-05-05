#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars
{


    public class Globals
    {
        public delegate void PassObject(object obj);
        public delegate object PassObjectAndReturn(object obj);
        public static int screenHeight, screenWidth;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static KeyboardControl keyboard;
        public static MouseControl mouse;
        public static Rectangle leftBound;
        public static Rectangle rightBound;
        public static Rectangle topBound;
        public static Rectangle bottomBound;
        public static GameTime gameTime;

    }
}
