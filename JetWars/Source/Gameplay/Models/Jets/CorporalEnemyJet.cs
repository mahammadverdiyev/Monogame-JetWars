using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using JetWars.Source.Gameplay.Models.Abstracts;
using JetWars.Source.Gameplay.Models.Bullets;
using JetWars.Source.Gameplay.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using JetWars.Source.Gameplay.Models.Items;

namespace JetWars.Source.Gameplay.Models.Jets
{
    public class CorporalEnemyJet : EnemyJet, IRotatable
    {

        private METimer missileShootCooldown;
        public CorporalEnemyJet(Vector2 position,float speed) : base("corporal",position,speed,5.0f)
        {
            shootTimer = new METimer(1000);
            missileShootCooldown = new METimer(10000);
            items.Add(new MedKit(position));
        }

        public override void Update()
        {
            base.Update();
        }

        public override void GetHit(float damage)
        {
            base.GetHit(damage);
        }

        public override void BehaveArtificially()
        {
            shootTimer.UpdateTimer();
            missileShootCooldown.UpdateTimer();

            if (position.Y < Globals.screenHeight / 4)
            {
                position += Physics.RadialMovement(GameGlobals.playerJet.position, position, speed);
            }

            if(!GameGlobals.playerJet.destroyed)
            {
                Rotate();
                Shoot();
            }
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
            if (shootTimer.Test())
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

            if(missileShootCooldown.Test())
            {
                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 4);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                float degree = MathHelper.ToDegrees(rotation);
             
                float leftX = 0, leftY = 0;
                float rightX= 0, rightY= 0;

                if(degree < 45 || (degree >= 150 && degree < 260) && degree > 0)
                {
                    leftX = position.X - dimension.X / 2;
                    rightX = position.X + dimension.X / 2;
                    leftY = rightY = position.Y;
                }
                else if(degree == 45 || degree > -60 && degree < 0)
                {
                    leftX = position.X - dimension.X / 2 + 10;
                    rightX = position.X + dimension.X / 2 - 10;
                    leftY = rightY = position.Y + 10;
                }
                else if(degree > 45 && degree < 150 || degree > 260 || (degree < 0 && degree < -60))
                {
                    leftX = rightX = position.X;
                    leftY = position.Y + dimension.Y / 2;
                    rightY = position.Y - dimension.Y / 2;
                }

                Bullet2D leftMissile =
                        new Missile(new Vector2(leftX,leftY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);
               
                Bullet2D rightMissile =
                        new Missile(new Vector2(rightX,rightY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                GameGlobals.PassBullet(leftMissile);
                GameGlobals.PassBullet(rightMissile);

                missileShootCooldown.ResetToZero();
            }
        }
    }
}
