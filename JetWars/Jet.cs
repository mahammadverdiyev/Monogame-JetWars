#region Includes
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace JetWars
{
    public abstract class Jet : Basic2D
    {
        public bool destroyed;
        protected CustomTimer shootTimer;

        public bool isHit;
        protected bool canShoot;

        public float speed, hitDistance, health, maxHealth;
        protected Vector2 velocity;
        public CustomTimer hitTimer;
        protected Color jetColor;
        protected CustomTimer explosionTimer;
        protected SoundEffect shootEffect;
        protected SoundEffect explosionEffect;
        protected SoundEffect missileEffect;
        protected SoundEffect hitEffect;
        public Jet(string PATH, Vector2 POSITION, Vector2 DIMENSION,float speed,
                        float _maxHealth) : base(PATH,POSITION,DIMENSION)
        {
            shootEffect = Globals.content.Load<SoundEffect>("laser-shoot");
            explosionEffect = Globals.content.Load<SoundEffect>("explosion-effect");
            missileEffect = Globals.content.Load<SoundEffect>("missile-effect");
            hitEffect = Globals.content.Load<SoundEffect>("hit-effect");
            isHit = false;
            canShoot = true;
            this.speed = speed;
            hitDistance = 35f;

            jetColor = Color.White;
            health = _maxHealth;
            maxHealth = health;

            hitTimer = new CustomTimer(100);
            destroyed = false;
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            hitTimer.UpdateTimer();

            if(explosionTimer != null)
            {
                explosionTimer.UpdateTimer();
                if (explosionTimer.Test())
                {
                    destroyed = true;
                    explosionEffect.Play();
                }
            }

            if (hitTimer.Test() && isHit)
            {
                isHit = false;
                jetColor = Color.White;
                dimension.X -= 5;
                dimension.Y -= 5;
            }
        }

        public virtual void GetHit(float damage)
        {

            if (hitTimer.Test() && explosionTimer == null)
            {
                isHit = true;
                jetColor = Color.OrangeRed;
                dimension.X += 5;
                dimension.Y += 5;
                hitTimer.ResetToZero();
            }

            health -= damage;

            if(health > 0)
                hitEffect.Play();

            if (health <= 0 && explosionTimer == null)
            {
                speed = 0f;
                canShoot = false;
                model = Globals.content.Load<Texture2D>("explosion");
                explosionTimer = new CustomTimer(200);
            }
        }

        public override void Draw(Vector2 OFFSET)
        {
            Vector2 origin = new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2);
            base.Draw(OFFSET,origin,jetColor);
        }
    }
}
