#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using JetWars.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars.Source.Gameplay.Models
{
    public class PlayerJet : Jet
    {
        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(50, 50))
        {

        }

        public override void Update()
        {
            MoveJet();
            RotateJet();
        }

        public override void RotateJet()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.GetScreenPos(Globals.mouse.New));
        }

        private void MoveJet()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                position.X -= speed;
            }
            if (Globals.keyboard.GetPress("D"))
            {
                position.X += speed;
            }
            if (Globals.keyboard.GetPress("W"))
            {
                position.Y -= speed;
            }
            if (Globals.keyboard.GetPress("S"))
            {
                position.Y += speed;
            }
        }
    }
}
