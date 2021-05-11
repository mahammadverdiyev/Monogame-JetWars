using System;
using Microsoft.Xna.Framework;

namespace JetWars.Source.Engine
{
    public class Physics
    {
        private static Main game;
        public static Main Game { set => game = value; }
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

        public static Vector2 RadialMovement(Vector2 target, Vector2 source, float speed)
        {
            float distance = GetDistance(source, target);

            if (distance <= speed)
                return target - source;
            else
                return (target - source) * speed / distance;
        }


        public static bool TouchesOneOfBounds(Rectangle rect)
        {
            return game.LeftBound.Intersects(rect) ||
                   game.RightBound.Intersects(rect) ||
                   game.TopBound.Intersects(rect) ||
                   game.BottomBound.Intersects(rect);
        }

        public static bool IsOutOfArena(Vector2 position)
        {
            if (position.X < 0 || position.X > Globals.screenWidth ||
                position.Y < 0 || position.Y > Globals.screenHeight)
                return true;
         
            return false;
        }
    }
}
