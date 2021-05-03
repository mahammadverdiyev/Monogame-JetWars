﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public abstract class Basic2D
    {
        protected float rotation;
        public Vector2 position, dimension;
        protected Texture2D model;

        public Basic2D(string PATH,Vector2 POSITION, Vector2 DIMENSION)
        {
            position = POSITION;
            dimension = DIMENSION;

            model = Globals.content.Load<Texture2D>(PATH);
        }
        public abstract void Update(GameTime gameTime);

        public virtual void Draw(Vector2 OFFSET)
        {
            if(model != null)
            {
                Rectangle destinationRectangle = new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y),
                                                               (int)dimension.X, (int)dimension.Y);
                Rectangle? sourceRectangle = null;
                Color color = Color.White;
                float rotation = this.rotation;
                SpriteEffects effects = new SpriteEffects();
                float layerDepth = 0.0f;
                Vector2 origin = new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2);

                Globals.spriteBatch.Draw(model,destinationRectangle,sourceRectangle,color,
                                               rotation, origin, effects,layerDepth);
            }
        }
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if (model != null)
            {
                Rectangle destinationRectangle = new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y),
                                                               (int)dimension.X, (int)dimension.Y);
                Rectangle? sourceRectangle = null;
                Color color = Color.White;
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
