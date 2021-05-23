using Microsoft.Xna.Framework;

namespace JetWars
{
    public class Kamikaze : EnemyJet, IRotatable
    {
        public Kamikaze(Vector2 position, float speed)
        : base("kamikaze", position, speed, 2f)
        {
            itemChanceToSpawn = 30;
            items.Add(new FireSpeedIncreaser(position));
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
