using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetWars.Source.Gameplay.Models.Jets
{
    public class BasicEnemyJet : EnemyJet, IRotatable
    {

        METimer shootTimer;
        Random rand;

        public BasicEnemyJet(Vector2 position,float speed) : base("basic-enemy",position,speed,5.0f)
        {
            shootTimer = new METimer(1000);
            rand = new Random();
        }

        public override void Update()
        {
            hitTimer.UpdateTimer();
            if (hitTimer.Test() && isHit)
            {
                isHit = false;
                jetColor = Color.White;
                dimension.X -= 5;
                dimension.Y -= 5;
            }

            base.Update();
        }

        public override void GetHit(float damage)
        {
            if(hitTimer.Test())
            {
                isHit = true;
                jetColor = Color.OrangeRed;
                dimension.X += 5;
                dimension.Y += 5;
                hitTimer.ResetToZero();
            }


            base.GetHit(damage);
        }

        public override void BehaveArtificially()
        {
            shootTimer.UpdateTimer();
            if(position.Y < Globals.screenHeight / 4)
            {
                position += Physics.RadialMovement(GameGlobals.playerJet.position, position, speed);
            }
            Rotate();
            Shoot();
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public void Rotate()
        {
            rotation = Physics.RotateTowards(position, GameGlobals.playerJet.position);
        }

        public override void Shoot()
        {
            if(shootTimer.Test())
            {
                int deflection = rand.Next(0, (int)Physics.GetDistance(position,GameGlobals.playerJet.position) / 4);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                Bullet2D bullet =
                        new StandardBullet(new Vector2(position.X, position.Y), 
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection, 
                        GameGlobals.playerJet.position.Y), rotation,8.0f);

                GameGlobals.PassBullet(bullet);
                shootTimer.ResetToZero();
            }
        }
    }
}
