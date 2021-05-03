using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace JetWars.Source.Gameplay.Models
{
	public class Bullet : Basic2D
	{
		private PlayerJet jet;
		public float velocity;
		public Vector2 origin;
		public float bulletRotation;
		public Vector2 direction;

		public bool isVisible;

		public Bullet(string path, Vector2 positon, Vector2 dimension, PlayerJet jet,float rotation) : base(path, positon, dimension)
		{
			this.jet = jet;
			isVisible = false;
			velocity = 10f;
			bulletRotation = rotation;
		}

		public override void Update(GameTime gameTime)
		{
			position += direction * velocity;

			if(Vector2.Distance(position,jet.position) > Globals.screenWidth)
            {
				isVisible = false;
            }
		}

		public override void Draw(Vector2 offset)
		{
			Globals.spriteBatch.Draw(model,position,null,Color.White,bulletRotation,origin,1f,SpriteEffects.None,0);
		}
	}
}
