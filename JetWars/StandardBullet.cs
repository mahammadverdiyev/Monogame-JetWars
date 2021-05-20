using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JetWars
{
    public class StandardBullet : Bullet2D
    {
        public StandardBullet(Vector2 position, Jet owner,Vector2 target, float rotation,float speed) 
            : base("ammo", position, new Vector2(20,20),owner,target,speed,1.0f)
        {
            this.rotation = rotation;
        }

        public override void Update()
        {
        }

        public override void Update(Vector2 offset, List<Jet> jets)
        {
            base.Update(offset, jets);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
