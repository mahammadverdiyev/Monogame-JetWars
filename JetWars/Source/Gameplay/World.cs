using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public class World
    {
        public Jet jet;
        public World()
        {
            jet = new Jet("jet", new Vector2(300, 300), new Vector2(50, 50));
        }
        public virtual void Update()
        {
            jet.Update();
        }
        public virtual void Draw(Vector2 OFFSET)
        {
            jet.Draw(OFFSET);
        }
    }
}
