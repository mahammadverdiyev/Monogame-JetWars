using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JetWars
{
    public class SergeantEnemyJet : EnemyJet, IRotatable
    {
        private CustomTimer missileShootCooldown;
        private CustomTimer moveTimer;
        private bool movesRight;
        private bool movesLeft;

        public SergeantEnemyJet(Vector2 position, float speed) 
            : base("sergeant", position, speed, 10)
        {
            shootTimer = new CustomTimer(800);
            missileShootCooldown = new CustomTimer(7000);

            if(rand.Next(0,2) == 0)
            {
                movesRight = true;
                movesLeft = false;
            }
            else
            {
                movesRight = false;
                movesLeft = true;
            }
            itemChanceToSpawn = 45;
            items.Add(new MedKit(position));
            items.Add(new Shield(position));
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
            missileShootCooldown.UpdateTimer();

            MoveLeftOrRight();

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

        private void MoveLeftOrRight()
        {
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
        }

        private void Move()
        {
            List<Bullet2D> bullets = new List<Bullet2D>(GameGlobals.playerBullets);

            foreach (Bullet2D bullet in bullets)
            {
                Vector2 playerToMe = GameGlobals.playerJet.position - position;
                Vector2 playerToBullet = bullet.position
                                                - GameGlobals.playerJet.position;


                playerToMe.Normalize();
                playerToBullet.Normalize();



                float dotProduct = -1 * Vector2.Dot(playerToMe, playerToBullet);

                if (
                    Physics.GetDistance(position, bullet.position) < hitDistance * 10
                    &&
                    dotProduct >= 0.99f
                    )
                {
                    moveTimer = new CustomTimer(1000);
                    if (rand.Next(0, 2) == 0)
                    {
                        movesRight = true;
                        movesLeft = false;
                    }
                    else
                    {
                        movesRight = false;
                        movesLeft = true;
                    }
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
                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 4);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                Bullet2D bullet =
                        new ImprovedBullet(new Vector2(position.X, position.Y),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 8.0f);

                GameGlobals.PassBullet(bullet);
                shootEffect.Play();
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
                        GameGlobals.playerJet.position.Y), rotation, 6.0f);

                Bullet2D rightMissileRight =
                        new Missile(new Vector2(rightFirstX, rightFirstY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 6.0f);

                Bullet2D leftMissileSecond =
                        new Missile(new Vector2(leftSecondX, leftSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 6.0f);

                Bullet2D rightMissileSecond =
                        new Missile(new Vector2(rightSecondX, rightSecondY),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 6.0f);

                GameGlobals.PassBullet(leftMissileLeft);
                GameGlobals.PassBullet(rightMissileRight);
                GameGlobals.PassBullet(leftMissileSecond);
                GameGlobals.PassBullet(rightMissileSecond);
                missileEffect.Play();
                missileShootCooldown.ResetToZero();
            }
        }
    }
}
