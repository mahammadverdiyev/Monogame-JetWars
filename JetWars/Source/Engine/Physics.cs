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
using System.Diagnostics;
#endregion
namespace JetWars.Source.Engine
{
    public class Physics
    {

        public static float RotateTowards(Vector2 source, Vector2 focus)
        {
            Vector2 distance = Vector2.Zero;

            distance = focus - source;

            float angle = (float)Math.Atan2(distance.Y, distance.X) + ((1f * (float)Math.PI) / 2);
            return angle;
        }

        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }

        public static Vector2 GetDirection(Vector2 source, Vector2 target)
        {
            Vector2 direction = target - source;
            if (direction != Vector2.Zero)
                direction.Normalize();

            return direction;
        }
        public static bool TouchesOneOfBounds(Rectangle rect)
        {
            return Globals.leftBound.Intersects(rect) ||
                   Globals.rightBound.Intersects(rect) ||
                   Globals.topBound.Intersects(rect) ||
                   Globals.bottomBound.Intersects(rect);
        }
    }
}
