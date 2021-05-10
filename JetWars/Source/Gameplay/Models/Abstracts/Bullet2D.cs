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
    public abstract class Bullet2D : Basic2D
    {
        public bool outOfArena;

        public float speed;

        public Vector2 direction;

        public Jet owner;

        public float damage;

        public Bullet2D(string path, Vector2 position, Vector2 dimension, Jet owner,Vector2 target,float speed,
            float damage) 
            : base(path, position, dimension)
        {
            this.damage = damage;
            outOfArena = false;
            this.speed = speed;
            this.owner = owner;
            
            direction = Physics.GetDirection(owner.position, target);
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
            else if(HitSomething(jets))
            {
                outOfArena = true;
            }
        }

        public virtual bool HitSomething(List<Jet> jets)
        {
            if (IsOwnerPlayerJet())
            {
                for (int i = 0; i < jets.Count; i++)
                {
                    if (HitsJet(jets[i]))
                    {
                        jets[i].GetHit(damage);
                        return true;
                    }
                }
            }
            else
            {
                PlayerJet jet = GameGlobals.playerJet;

                if (HitsJet(jet))
                {
                    jet.GetHit(damage);
                    return true;
                }
            }

            return false;
        }

        private bool IsOwnerPlayerJet()
        {
            return owner.GetType() == typeof(PlayerJet);
        }

        private bool HitsJet(Jet jet) =>
            Physics.GetDistance(position, jet.position) < jet.hitDistance;

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
