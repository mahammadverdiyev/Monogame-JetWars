using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace JetWars
{
    public class PlayerJet : Jet, IRotatable
    {

        private Random rand = new Random();
        private int bulletFireSpeed;
        private int missileFireSpeed;
        private int accuracyValue;
        private CustomTimer shieldTimer;
        private bool isShieldActive;
        private CustomTimer missileShootCooldown;

        public int BulletFireSpeed => bulletFireSpeed;
        public int AccuracyValue => accuracyValue;

        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(60, 60), 2.5f, 20f)
        {
            accuracyValue = 12;
            bulletFireSpeed = 700;
            missileFireSpeed = 5000;
            isShieldActive = false;
            shootTimer = new CustomTimer(1000 - bulletFireSpeed);
            missileShootCooldown = new CustomTimer(10000 - missileFireSpeed);
        }

        public override void Update()
        {
            base.Update();

            if (destroyed)
            {
                Globals.oldState = Globals.currentState;
                Globals.currentState = State.StartMenu;
            }

            missileShootCooldown.UpdateTimer();
            shootTimer.UpdateTimer();

            UpdateShield();

            MoveJet();
            Rotate();


            if (Globals.mouse.LeftClick() && shootTimer.Test())
            {
                ShootRegularBullet();
                shootTimer.Reset(1000 - bulletFireSpeed);
            }
            if (Globals.mouse.RightClick() && missileShootCooldown.Test())
            {
                ShootMissile();
                missileShootCooldown.Reset();
            }
        }

        private void UpdateShield()
        {
            if (shieldTimer != null)
            {
                shieldTimer.UpdateTimer();
                if (shieldTimer.Test())
                {
                    jetColor = Color.White;
                    isShieldActive = false;
                    shieldTimer = null;
                }
            }
        }

        public void ActivateShield()
        {
            jetColor = Color.CornflowerBlue;
            isShieldActive = true;
            shieldTimer = new CustomTimer(5000);
        }

        public override void GetHit(float damage)
        {
            if(!isShieldActive)
                base.GetHit(damage);
        }

        private void ShootMissile()
        {
                Missile missile =
                 new Missile(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), rotation, 10);

                GameGlobals.PassBullet(missile);
                missileShootCooldown.ResetToZero();
        }

        public void MaximizeHealth()
        {
            health = maxHealth;
        }

        public void IncreaseFireSpeed()
        {
            if(bulletFireSpeed + 50 <= 1000)
                bulletFireSpeed += 50;
            if (missileFireSpeed + 100 <= 7000)
                missileFireSpeed += 100;
        }
        public void IncreaseAccuracy()
        {
            accuracyValue++;
        }

        public void IncreaseJetSpeed()
        {
            if(speed + 0.5f <= 6)
            {
                speed += 0.5f;
            }
        }
        public void IncreaseMaxHealth()
        {
            maxHealth += 10;
        }

        private void ShootRegularBullet()
        {
            int deflection = rand.Next(0, (int)Physics.GetDistance(position, Globals.mouse.newMousePos) / accuracyValue);

            if (rand.Next(0, 2) == 0)
                deflection = -deflection;

            Bullet2D bullet =
                new ImprovedBullet(new Vector2(position.X, position.Y), this, new Vector2(Globals.mouse.newMousePos.X + deflection, Globals.mouse.newMousePos.Y), rotation, 14.0f);

            GameGlobals.PassBullet(bullet);
        }

        private void MoveJet()
        {
            KeyboardState currentKey = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (currentKey.IsKeyDown(Keys.W))
            {
                verticalInput = -1f;
            }

            if (currentKey.IsKeyDown(Keys.S))
            {
                verticalInput = 1f;
            }

            if (currentKey.IsKeyDown(Keys.A))
            {
                horizontalInput = -1f;
            }

            if (currentKey.IsKeyDown(Keys.D))
            {
                horizontalInput = 1f;
            }

            float movementForce = 100f;
            float delta = (float)Globals.gameTime.ElapsedGameTime.TotalSeconds;
            movement = new Vector2(horizontalInput, verticalInput) * delta * movementForce * speed;
            position += movement;

            Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);

            if (Physics.TouchesOneOfBounds(rect))
            {
                position -= movement;
            }
        }



        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

        public void Rotate()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.newMousePos);
        }
    }
}
