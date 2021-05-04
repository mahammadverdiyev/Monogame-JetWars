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
        public BasicEnemyJet(Vector2 position) : base("basic-enemy",position)
        {
            shootTimer = new METimer(1000);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void BehaveArtificially()
        {
            shootTimer.UpdateTimer();
            position += Physics.RadialMovement(GameGlobals.playerJet.position, position, speed);
            Rotate();
            //Shoot();
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
                Bullet2D bullet =
new StandardBullet(new Vector2(position.X, position.Y), this, new Vector2(GameGlobals.playerJet.position.X, GameGlobals.playerJet.position.Y), rotation);

                GameGlobals.PassBullet(bullet);
                shootTimer.ResetToZero();
            }
        }
    }
}
