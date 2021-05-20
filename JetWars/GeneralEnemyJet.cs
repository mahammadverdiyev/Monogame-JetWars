using JetWars.Source.Gameplay.Models.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JetWars
{
    public class GeneralEnemyJet : EnemyJet
    {
        private METimer moveTimer;
        bool movesRight, movesLeft;
        public GeneralEnemyJet(Vector2 position, float speed)
            : base("general", position, speed, 30)
        {
            shootTimer = new METimer(1000);
            movesRight = true;
            movesLeft = false;

            items.Add(new AccuracyIncreaser(position));
            items.Add(new JetSpeedIncreaser(position));
            items.Add(new MaxHealthIncreaser(position));
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

            if (moveTimer != null)
            {
                moveTimer.UpdateTimer();
                if (movesRight)
                {
                    position.X += speed;
                    if (Physics.IsOutOfArena(position))
                    {
                        movesRight = false;
                        movesLeft = true;
                    }
                }
                else if (movesLeft)
                {
                    position.X -= speed;
                    if (Physics.IsOutOfArena(position))
                    {
                        movesRight = true;
                        movesLeft = false;
                    }
                }
            }

            if (moveTimer != null && moveTimer.Test())
            {
                moveTimer = null;
            }

            if (moveTimer == null || (moveTimer != null && moveTimer.Test()))
                Move();

            if (position.Y < Globals.screenHeight / 4)
            {
                position += Physics.RadialMovement(GameGlobals.playerJet.position, position, speed);
            }

            if (!GameGlobals.playerJet.destroyed)
            {
                Rotate();
                Shoot();
            }
        }

        private void Move()
        {
            List<Bullet2D> bullets = new List<Bullet2D>(GameGlobals.playerBullets);

            foreach (Bullet2D bullet in bullets)
            {
                Vector2 playerToMe = GameGlobals.playerJet.position - position;
                Vector2 bulletToMe = bullet.position - position;
                Vector2 playerToBullet = bullet.position
                                                - GameGlobals.playerJet.position;


                playerToMe.Normalize();
                bulletToMe.Normalize();
                playerToBullet.Normalize();

                float dotProduct = -1 * Vector2.Dot(playerToMe, playerToBullet);

                if (
                    //Physics.GetDistance(position, bullet.position) < hitDistance * 8
                    //&& 
                    dotProduct >= 0.99f
                    )
                {
                    //if(bullet.position.X > position.X)
                    //{
                    //    movesLeft = true;
                    //    movesRight = false;
                    //}
                    //else if (bullet.position.X < position.X)
                    //{
                    //    movesLeft = false;
                    //    movesRight = true;
                    //}
                    moveTimer = new METimer(500);
                    return;
                }

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
                shootTimer.ResetToZero();

                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 10);

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

                Bullet2D leftFirstBullet =
                        new HighPenetratingBullet(new Vector2(leftFirstX, leftFirstY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D rightFirstBullet =
                        new HighPenetratingBullet(new Vector2(rightFirstX, rightFirstY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D leftSecondBullet =
                        new HighPenetratingBullet(new Vector2(leftSecondX, leftSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                Bullet2D rigtSecondBullet =
                        new HighPenetratingBullet(new Vector2(rightSecondX, rightSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 5.0f);

                GameGlobals.PassBullet(leftFirstBullet);
                GameGlobals.PassBullet(rightFirstBullet);
                GameGlobals.PassBullet(leftSecondBullet);
                GameGlobals.PassBullet(rigtSecondBullet);
            }

        }
    }
}