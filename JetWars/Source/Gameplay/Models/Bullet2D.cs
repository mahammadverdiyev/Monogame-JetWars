using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using JetWars.Source.Engine;
using System.Diagnostics;

namespace JetWars.Source.Gameplay.Models
{
    public class Bullet2D : Basic2D
    {
        public bool done;

        public float speed;

        public Vector2 direction;

        public Jet owner;

        public METimer timer;

        public Bullet2D(string path, Vector2 position, Vector2 dimension, Jet owner,Vector2 target) 
            : base(path, position, dimension)
        {
            done = false;
            speed = 15.0f;
            this.owner = owner;

            direction = Physics.GetDirection(owner.position, target);
            
            timer = new METimer(1500);
        }

        public override void Update()
        {
            // leave empty
        }

        public virtual void Update(Vector2 offset, List<Jet> jets)
        {
            float speedForce = 50f;
            float delta = (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;

            position += direction * speed * delta * speedForce;

            timer.UpdateTimer();

            if (timer.Test())
            {
                done = true;
            }

            if(HitSomething(jets))
            {
                // implement kill, reduce healrth these kind of things
                done = true;
            }
        }

        public virtual bool HitSomething(List<Jet> jets)
        {
            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
