#region Includes
using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
#endregion


namespace JetWars.Source.Gameplay.Models.Jets
{
    public class Kamikaze : EnemyJet, IRotatable
    {
        public Kamikaze(Vector2 position, float speed)
        : base("kamikaze", position, speed, 2f)
        {
        }

        public override void BehaveArtificially()
        {
            position += Physics.RadialMovement(target.position, position, speed);
            if(!GameGlobals.playerJet.destroyed)
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
