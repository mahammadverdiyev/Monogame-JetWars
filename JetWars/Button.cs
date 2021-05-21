using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public class Button : Basic2D
    {
        public bool isHovering;
        public Button(string PATH, Vector2 POSITION, Vector2 DIMENSION) : base(PATH, POSITION, DIMENSION) 
        {
            isHovering = false;
        }

        public override void Update()
        {
            base.Update();
            MouseState mouseState = Globals.mouse.newMouse;
            if (new Rectangle(mouseState.Position.X, mouseState.Position.Y, 1, 1).Intersects(ModelBox))
            {
                isHovering = true;
            }
            else
                isHovering = false;

        }

        public override void Draw(Vector2 OFFSET)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y,
                                            model.Width, model.Height);

            modelBox = destinationRectangle;

            Rectangle? sourceRectangle = null;
            Color color = isHovering ? new Color(195,195,195) : Color.White;
            float rotation = this.rotation;
            SpriteEffects effects = new SpriteEffects();
            float layerDepth = 0.0f;
            //Vector2 origin = new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2);
            Vector2 origin = Vector2.Zero;

            Globals.spriteBatch.Draw(model, destinationRectangle, sourceRectangle, color,
                                           rotation, origin, effects, layerDepth);
        }
    }
}
