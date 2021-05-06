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
        private bool movesLeft = false, movesRight = true;
        private METimer moveTimer;

        public AdvancedEnemyJet(Vector2 position,float speed)
        :base("advanced-enemy",position,speed,10f)
        {
            shootTimer = new METimer(500);
            moveTimer = new METimer(1500);
        }


        public override void Update()
        {
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
                moveTimer.ResetToZero();
                movesLeft = !movesLeft;
                movesRight = !movesRight;
            }

            if(movesLeft)
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
