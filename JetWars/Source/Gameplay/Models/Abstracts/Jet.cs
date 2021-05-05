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
        public METimer hitTimer;
        protected Color jetColor;
        protected bool isHit;
        public Jet(string PATH, Vector2 POSITION, Vector2 DIMENSION,float speed,
                        float _maxHealth) : base(PATH,POSITION,DIMENSION)
        {
            isHit = false;
            this.speed = speed;
            hitDistance = 35f;

            jetColor = Color.White;
            health = _maxHealth;
            maxHealth = health;

            hitTimer = new METimer(100);
            destroyed = false;
            velocity = new Vector2(0, 0);
        }

        public virtual void GetHit(float damage)
        {
            //health -= damage;
            if(health <= 0)
                destroyed = true;
        }

        public override void Draw(Vector2 OFFSET)
        {
            Vector2 origin = new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2);
            base.Draw(OFFSET,origin,jetColor);
        }
    }
}
