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
namespace JetWars.Source.Engine
{
    public class Physics
    {

        public static float RotateTowards(Vector2 source, Vector2 focus)
        {
            Vector2 distance = Vector2.Zero;

            distance.X = focus.X - source.X;
            distance.Y = focus.Y - source.Y;

            float angle = (float)Math.Atan2(distance.Y, distance.X) + ((1f * (float)Math.PI) / 2);
            return angle;
        }

        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }
    }
}
