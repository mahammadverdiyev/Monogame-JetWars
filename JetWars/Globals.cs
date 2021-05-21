using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace JetWars
{
    public class Globals
    {
        public delegate void PassObject(object obj);
        public delegate object PassObjectAndReturn(object obj);
        public static int screenHeight, screenWidth;
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static KeyBoardControl keyboard;
        public static MouseControl mouse;
        public static GameTime gameTime;
        public static State currentState;
        public static State oldState;
    }
}
