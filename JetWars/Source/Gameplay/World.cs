using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetWars.Source;
using JetWars.Source.Gameplay;
using JetWars.Source.Gameplay.Models;
using JetWars.Source.Gameplay.Models.Jets;
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

        public List<Bullet2D> bullets = new List<Bullet2D>();
        public List<Jet> enemies = new List<Jet>();
        public List<SpawnLocation> spawnLocations = new List<SpawnLocation>();

        public World()
        {
            playerJet = new PlayerJet();
            GameGlobals.playerJet = playerJet;

            bg1 = new ScrollingBackground("star1",new Rectangle(0,0,900,675), 1);
            bg2 = new ScrollingBackground("star2", new Rectangle(0, -675,900,675), 1);
            GameGlobals.PassBullet = AddBullet;
            GameGlobals.PassEnemyJet = AddEnemyJet;
            offset = Vector2.Zero;
            spawnLocations.Add(new SpawnLocation("circle", new Vector2(50,50), new Vector2(35,35)));
           
            spawnLocations.Add(new SpawnLocation("circle", new Vector2(Globals.screenWidth / 2, 50), new Vector2(35, 35)));
            spawnLocations[spawnLocations.Count - 1].spawnTimer.AddToTimer(500);

            spawnLocations.Add(new SpawnLocation("circle", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));
            spawnLocations[spawnLocations.Count - 1].spawnTimer.AddToTimer(1000);

        }

        public void Update()
        {
            AdjustBackground();

            bg1.Update();
            bg2.Update();

            UpdateSpawnLocations();
            UpdateBullets();
            UpdateEnemyJets();
            playerJet.Update();
        }

        private void UpdateSpawnLocations()
        {
            for (int i = 0; i < spawnLocations.Count; i++)
            {
                spawnLocations[i].Update();
            }
        }

        private void UpdateBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(offset, enemies);
                if (bullets[i].outOfArena)
                {
                    bullets.RemoveAt(i);
                    i--;
                }

            }
        }

        public void UpdateEnemyJets()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();
                if (enemies[i].destroyed)
                {
                    enemies.RemoveAt(i);
                    i--;
                }

            }
        }

        public virtual void AddEnemyJet(object enemyJet)
        {
            enemies.Add((EnemyJet)enemyJet);
        }
        public virtual void AddBullet(object info)
        {
            bullets.Add((Bullet2D)info);
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
            bullets.ForEach(projectile => projectile.Draw(offset));

            spawnLocations.ForEach(location => location.Draw(offset));
            enemies.ForEach(enemy => enemy.Draw(offset));
        }
    }
}
