#region Includes
using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
#endregion

namespace JetWars.Source.Gameplay.Models.Jets
{
    public class AdvancedEnemyJet : EnemyJet, IRotatable
    {
        private bool movesLeft, movesRight;
        private METimer moveTimer;
        int left, right;
        public AdvancedEnemyJet(Vector2 position,float speed)
        :base("advanced-enemy",position,speed,10f)
        {
            right = (int)(Globals.screenWidth - position.X + dimension.X);
            left = (int)position.X;
            shootTimer = new METimer(500);
            int moveTimerInterval;

            if(rand.Next(0,2) == 1)
            {
                movesRight = true;
                movesLeft = false;
                moveTimerInterval = (int)(right / speed) * 15;
            }
            else
            {
                movesRight = false;
                movesLeft = true;
                moveTimerInterval = (int)(left / speed) * 15;
            }
            moveTimer = new METimer(moveTimerInterval);
        }


        public override void Update()
        {
            left = (int)position.X;
            right = (int)(Globals.screenWidth - position.X + dimension.X);
            base.Update();
        }
        public override void BehaveArtificially()
        {
            shootTimer.UpdateTimer();
            moveTimer.UpdateTimer();

            if (position.Y < Globals.screenHeight / 4)
            {
                position += Physics.RadialMovement(GameGlobals.playerJet.position, position, speed);
            }

            if(moveTimer.Test())
            {
                Debug.WriteLine("TEST");
                movesLeft = !movesLeft;
                movesRight = !movesRight;
                int time;
                if (movesRight)
                    time = (int)(right / speed) * 15;
                else
                    time = (int)(left / speed) * 15;
                moveTimer.Reset(time);
            }

            if (movesLeft)
            {
                position.X -= speed;
            }
            if(movesRight)
            {
                position.X += speed;
            }

            //if (position.X + ModelBox.Width < Globals.screenWidth && movesRight)
            //    position.X += speed;

            //if (position.X > 0 && movesLeft)
            //    position.X -= speed;

            //if(position.X + ModelBox.Width >= Globals.screenWidth)
            //{
            //    movesRight = false;
            //    movesLeft = true;
            //}
            //if(position.X <= 0)
            //{
            //    movesLeft = false;
            //    movesRight = true;
            //}

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
                int deflection = rand.Next(0, (int)Physics.GetDistance(position, GameGlobals.playerJet.position) / 8);

                if (rand.Next(0, 2) == 0)
                    deflection = -deflection;

                Bullet2D bullet =
                        new StandardBullet(new Vector2(position.X, position.Y),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 8.0f);

                GameGlobals.PassBullet(bullet);
                shootTimer.ResetToZero();
            }
        }
    }
}
