#region Includes
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetWars.Source.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars.Source.Gameplay.Models
{
    public class PlayerJet : Jet
    {
		private MouseState mouseState;
		private MouseState lastMouseState;
		private Bullet currentBullet;
		private List<Bullet> bullets;
		private GameTime gameTime;
        public PlayerJet() : base("jet", new Vector2(300, 300), new Vector2(50, 50))
		{
			bullets = new List<Bullet>();
		}

        public override void Update(GameTime gameTime)
        {
			this.gameTime = gameTime;
            MoveJet(gameTime);
            RotateJet();

			mouseState = Mouse.GetState();

			if (lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
			{
				Shoot();
			}

			lastMouseState = mouseState;
        }

		public override void RotateJet()
        {
            rotation = Physics.RotateTowards(position, Globals.mouse.GetScreenPos(Globals.mouse.New));
        }

        private void MoveJet(GameTime gameTime)
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

			float movementForce = 600f;
			movement = new Vector2(horizontalInput, verticalInput) * (float)gameTime.ElapsedGameTime.TotalSeconds * movementForce;
			position += movement;

			Rectangle rect = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);

			if (IsInsideScreen(rect))
			{
				position -= movement;
			}
		}

		private static bool IsInsideScreen(Rectangle rect)
		{
			return Globals.leftBound.Intersects(rect) ||
				   Globals.rightBound.Intersects(rect) ||
				   Globals.topBound.Intersects(rect) ||
				   Globals.bottomBound.Intersects(rect);
		}

		public override void Draw(Vector2 OFFSET)
		{
			if (currentBullet == null) return;
			currentBullet.Draw(Vector2.Zero);
			base.Draw(OFFSET);
		}

		private void Shoot()
		{
			currentBullet = new Bullet("ammo", position, new Vector2(16, 16), this);
			
			foreach (Bullet bullet in bullets)
			{
				currentBullet.Update(gameTime);
			}

			bullets.Add(currentBullet);
		}
	}
}
