﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JetWars
{
    public class Basic2D
    {
        public float rotation;
        public Vector2 position, dimension;
        protected Texture2D model;
        protected Rectangle modelBox;

        public Rectangle ModelBox => modelBox;

        public Basic2D(string PATH,Vector2 POSITION, Vector2 DIMENSION)
        {
            position = POSITION;
            dimension = DIMENSION;
            modelBox = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);
            model = Globals.content.Load<Texture2D>(PATH);
        }
        public virtual void Update() { }


        public virtual void Draw(Vector2 OFFSET)
        {
            if(model != null)
            {
                Rectangle destinationRectangle = new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y),
                                                               (int)dimension.X, (int)dimension.Y);

                modelBox = destinationRectangle;

                Rectangle? sourceRectangle = null;
                Color color = Color.White;
                float rotation = this.rotation;
                SpriteEffects effects = new SpriteEffects();
                float layerDepth = 0.0f;
                Vector2 origin = new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2);

                Globals.spriteBatch.Draw(model, destinationRectangle, sourceRectangle, color,
                                               rotation, origin, effects, layerDepth);
            }
        }
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN,Color color)
        {
            if (model != null)
            {
                Rectangle destinationRectangle = new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y),
                                                               (int)dimension.X, (int)dimension.Y);
                modelBox = destinationRectangle;
                Rectangle? sourceRectangle = null;
                float rotation = this.rotation;
                SpriteEffects effects = new SpriteEffects();
                float layerDepth = 0.0f;
                Vector2 origin = new Vector2(ORIGIN.X,ORIGIN.Y);

                Globals.spriteBatch.Draw(model, destinationRectangle, sourceRectangle, color,
                                               rotation, origin, effects, layerDepth);
            }
        }
    }
}
