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
    public class MajorEnemyJet : EnemyJet, IRotatable
    {
        private bool movesLeft, movesRight;
        private METimer moveTimer;
        int left, right;
        public MajorEnemyJet(Vector2 position,float speed)
        :base("major",position,speed,15f)
        {
            right = (int)(Globals.screenWidth - position.X + dimension.X);
            left = (int)position.X;
            shootTimer = new METimer(300);

            int moveTimerInterval;

            if(rand.Next(0,2) == 1)
            {
                movesRight = true;
                movesLeft = false;
                moveTimerInterval = (int)(right / speed) * 14;
            }
            else
            {
                movesRight = false;
                movesLeft = true;
                moveTimerInterval = (int)(left / speed) * 14;
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
                    time = (int)(right / speed) * 14;
                else
                    time = (int)(left / speed) * 14;
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

            if (!GameGlobals.playerJet.destroyed)
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
                        new ImprovedBullet(new Vector2(position.X, position.Y),
                        this, new Vector2(GameGlobals.playerJet.position.X + deflection,
                        GameGlobals.playerJet.position.Y), rotation, 12.0f);

                GameGlobals.PassBullet(bullet);
                shootTimer.ResetToZero();
            }
        }
    }
}
