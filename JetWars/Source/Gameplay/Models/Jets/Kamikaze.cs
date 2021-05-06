#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion


namespace JetWars.Source.Gameplay.Models.Jets
{
    public class Kamikaze : EnemyJet, IRotatable
    {
        Jet target;
        public Kamikaze(Vector2 position, float speed,Jet target)
        : base("kamikaze", position, speed, 2f)
        {
            this.target = target;
        }

        public override void BehaveArtificially()
        {
            position += Physics.RadialMovement(target.position, position, speed);
            if(canShoot)
            {
                Rotate();
                Shoot();
            }
        }

        public void Rotate()
        {
            rotation = Physics.RotateTowards(position, target.position);
        }

        public override void Shoot()
        {
           if(Physics.GetDistance(position,target.position) <= target.hitDistance)
           {
                target.GetHit(5);
                GetHit(maxHealth);
           }
        }
    }
}
