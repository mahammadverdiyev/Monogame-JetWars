#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using JetWars.Source.Gameplay.Models.Jets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion
namespace JetWars.Source
{
    public class GamePlay
    {
        int gameState;

        World world;

        public GamePlay()
        {
            gameState = 0;

            ResetWorld(null);
        }

        public virtual void Update()
        {
            if(gameState == 0)
                world.Update();
        }

        public virtual void ResetWorld(object data)
        {
            world = new World(ResetWorld);
        }
        public virtual void Draw()
        {
            if (gameState == 0)
                world.Draw(Vector2.Zero);
        }
    }
}
