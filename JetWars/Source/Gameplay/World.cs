using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetWars.Source;
using JetWars.Source.Gameplay.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars
{
    public class World
    {

        public PlayerJet playerJet;
        public ScrollingBackground bg1;
        public ScrollingBackground bg2;

        public Vector2 offset;
        public List<Bullet2D> projectiles = new List<Bullet2D>();

        public World()
        {
            playerJet = new PlayerJet();
            bg1 = new ScrollingBackground("star1",new Rectangle(0,0,900,675), 1);
            bg2 = new ScrollingBackground("star2", new Rectangle(0, -675,900,675), 1);
            
            GameGlobals.PassBullet = AddBullet;
            offset = Vector2.Zero;
        }

        public void Update()
        {
            AdjustBackground();

            bg1.Update();
            bg2.Update();

            UpdateProjectiles();

            playerJet.Update();
        }

        private void UpdateProjectiles()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);
                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }

            }
        }

        public virtual void AddBullet(object info)
        {
            projectiles.Add((Bullet2D)info);
        }

        private void AdjustBackground()
        {
            if (bg1.backgroundBox.Y >= Globals.screenHeight)
                bg1.backgroundBox.Y = bg2.backgroundBox.Y - bg2.backgroundBox.Height;

            if (bg2.backgroundBox.Y >= Globals.screenHeight)
                bg2.backgroundBox.Y = bg1.backgroundBox.Y - bg1.backgroundBox.Height;
        }

        public void Draw(Vector2 OFFSET)
        {
            bg1.Draw(Vector2.Zero);
            bg2.Draw(Vector2.Zero);
            playerJet.Draw(OFFSET);
            projectiles.ForEach(projectile => projectile.Draw(offset));
        }
    }
}
