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
        public bool outOfArena;

        public float speed;

        public Vector2 direction;

        public Jet owner;


        public Bullet2D(string path, Vector2 position, Vector2 dimension, Jet owner,Vector2 target) 
            : base(path, position, dimension)
        {
            outOfArena = false;
            speed = 15.0f;
            this.owner = owner;

            direction = Physics.GetDirection(owner.position, target);
            
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

            if(Physics.IsOutOfArena(position))
            {
                outOfArena = true;
            }
            if(HitSomething(jets))
            {
                // implement kill, reducing health & these kind of things
                outOfArena = true;
            }
        }

        public virtual bool HitSomething(List<Jet> jets)
        {
            if(owner.GetType() == typeof(PlayerJet))
            {
                for (int i = 0; i < jets.Count; i++)
                {
                    if (Physics.GetDistance(position, jets[i].position) < jets[i].hitDistance)
                    {
                        Debug.WriteLine("HIT");
                        jets[i].GetHit();
                        return true;
                    }
                }
            }
            else
            {
                PlayerJet jet = GameGlobals.playerJet;

                if(Physics.GetDistance(position,jet.position) < jet.hitDistance)
                {
                    Debug.WriteLine("PLAYER DEAD");
                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
