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
        public float speed, hitDistance, health, maxHealth;
        protected Vector2 velocity;

        public Jet(string PATH, Vector2 POSITION, Vector2 DIMENSION,float speed) : base(PATH,POSITION,DIMENSION)
        {
            this.speed = speed;
            hitDistance = 35f;

            health = 1;
            maxHealth = health;

            destroyed = false;
            velocity = new Vector2(0, 0);
        }

        public virtual void GetHit(float damage)
        {
            health -= damage;
            if(health <= 0)
                destroyed = true;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
