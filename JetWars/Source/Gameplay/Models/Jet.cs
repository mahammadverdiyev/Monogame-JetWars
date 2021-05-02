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

namespace JetWars
{
    public abstract class Jet : Basic2D
    {
        public float speed;

        public Jet(string PATH, Vector2 POSITION, Vector2 DIMENSION) : base(PATH,POSITION,DIMENSION)
        {
            speed = 5.0f;
        }

        public virtual void RotateJet()
        {

        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
