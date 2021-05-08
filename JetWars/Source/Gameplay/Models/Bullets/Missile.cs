using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JetWars.Source.Gameplay.Models.Bullets
{
    public class Missile : Bullet2D
    {
        public Missile(Vector2 position, Jet owner, Vector2 target, float rotation, float speed)
            : base("missile", position, new Vector2(60, 60), owner, target, speed, 10)
        {
            this.rotation = rotation;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
