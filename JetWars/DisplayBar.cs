#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars
{
    public class DisplayBar
    {
        public int border;

        public Basic2D bar, barBackground;

        public Color color;

        public DisplayBar(Vector2 dimension, int border,Color color)
        {
            this.border = border;
            this.color = color;

            bar = new Basic2D("solid",new Vector2(0,0),new Vector2(dimension.X-border*2,dimension.Y-border*2));
            barBackground = new Basic2D("shade", new Vector2(0, 0), new Vector2(dimension.X, dimension.Y));
        }

        public virtual void Update(float currentQuantity, float maxQuantity)
        {
            bar.dimension = new Vector2(currentQuantity / maxQuantity * (barBackground.dimension.X - border*2), bar.dimension.Y);
        }

        public virtual void Draw(Vector2 offset)
        {
            barBackground.Draw(offset, new Vector2(0, 0), Color.Blue);
            bar.Draw(offset + new Vector2(border, border), Vector2.Zero, color);
        }
    }
}
