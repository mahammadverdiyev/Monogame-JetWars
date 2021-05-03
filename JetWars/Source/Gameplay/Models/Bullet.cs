using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace JetWars.Source.Gameplay.Models
{
	public class Bullet : Basic2D
	{
		private PlayerJet jet;
		public Bullet(string path, Vector2 positon, Vector2 dimension, PlayerJet jet) : base(path, positon, dimension)
		{
			this.jet = jet;
		}

		public override void Update(GameTime gameTime)
		{
			Point mousePoint = Mouse.GetState().Position;
			Vector2 mousePosition = new Vector2(mousePoint.X, mousePoint.Y);
			Vector2 jetPosition = jet.position;
			Vector2 direction = mousePosition - jetPosition;

			position += new Vector2(direction.X, direction.Y) * 10f;
		}

		public override void Draw(Vector2 offset)
		{
			base.Draw(offset);
		}
	}
}
