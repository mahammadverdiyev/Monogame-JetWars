using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using JetWars.Source.Gameplay.Models.Bullets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace JetWars.Source.Gameplay.Models.Jets
{
    public class SergeantEnemyJet : EnemyJet, IRotatable
    {
        private METimer missileShootCooldown;

        public SergeantEnemyJet(Vector2 position, float speed) 
            : base("sergeant", position, speed, 10)
        {
            shootTimer = new METimer(800);
            missileShootCooldown = new METimer(7000);
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

            if (canShoot)
            {
                Rotate();
                Shoot();
            }
        }

        public void Rotate()
        {
            rotation = Physics.RotateTowards(position, GameGlobals.playerJet.position);
        }

        public override void Shoot()
        {
            if (shootTimer.Test())
            {
                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 4);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                Bullet2D bullet =
                        new ImprovedBullet(new Vector2(position.X, position.Y),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 8.0f);

                GameGlobals.PassBullet(bullet);
                shootTimer.ResetToZero();
            }

            if (missileShootCooldown.Test())
            {
                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 4);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                float degree = MathHelper.ToDegrees(rotation);

                float leftFirstX = 0, leftFirstY = 0;
                float rightFirstX = 0, rightFirstY = 0;

                float leftSecondX = 0;
                float leftSecondY = 0;
                float rightSecondX = 0;
                float rightSecondY = 0;

                float difference = 15;

                if (degree < 45 || (degree >= 150 && degree < 260) && degree > 0)
                {
                    leftFirstX = position.X - dimension.X / 2;
                    rightFirstX = position.X + dimension.X / 2;
                    leftFirstY = rightFirstY = position.Y;
                    leftSecondX = leftFirstX + difference;
                    leftSecondY = leftFirstY;
                    rightSecondX = rightFirstX - difference;
                    rightSecondY = rightFirstY;

                }
                else if (degree == 45 || degree > -60 && degree < 0)
                {
                    leftFirstX = position.X - dimension.X / 2 + 10;
                    rightFirstX = position.X + dimension.X / 2 - 10;
                    leftFirstY = rightFirstY = position.Y + 10;
                    leftSecondX = leftFirstX + difference;
                    leftSecondY = leftFirstY + difference;
                    rightSecondX = rightFirstX - difference;
                    rightSecondY = rightFirstY - difference;
                }
                else if (degree > 45 && degree < 150 || degree > 260 || (degree < 0 && degree < -60))
                {
                    leftFirstX = rightFirstX = position.X;
                    leftFirstY = position.Y + dimension.Y / 2;
                    rightFirstY = position.Y - dimension.Y / 2;
                    leftSecondX = leftFirstX + difference;
                    leftSecondY = leftFirstY;
                    rightSecondX = rightFirstX - difference;
                    rightSecondY = rightFirstY;
                    leftSecondX = leftFirstX;
                    leftSecondY = leftFirstY + difference;
                    rightSecondX = rightFirstX;
                    rightSecondY = rightFirstY - difference;
                }

                Bullet2D leftMissileLeft =
                        new Missile(new Vector2(leftFirstX, leftFirstY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D rightMissileRight =
                        new Missile(new Vector2(rightFirstX, rightFirstY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D leftMissileSecond =
                        new Missile(new Vector2(leftSecondX, leftSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D rightMissileSecond =
                        new Missile(new Vector2(rightSecondX, rightSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                GameGlobals.PassBullet(leftMissileLeft);
                GameGlobals.PassBullet(rightMissileRight);
                GameGlobals.PassBullet(leftMissileSecond);
                GameGlobals.PassBullet(rightMissileSecond);
                                
                missileShootCooldown.ResetToZero();
            }
        }
    }
}
