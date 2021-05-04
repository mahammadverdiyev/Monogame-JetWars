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
        public bool destroyed;
        public float speed, hitDistance;
        protected Vector2 velocity;
        protected Vector2 acceleration;

        public Jet(string PATH, Vector2 POSITION, Vector2 DIMENSION) : base(PATH,POSITION,DIMENSION)
        {
            speed = 5.0f;
            hitDistance = 35f;
            destroyed = false;
            velocity = new Vector2(0, 0);
            acceleration = Vector2.Zero;
        }

        public virtual void GetHit()
        {
            destroyed = true;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
