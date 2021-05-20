using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JetWars
{
    public class World
    {
        private PlayerJet playerJet;
     
        private ScrollingBackground bg1;
        private ScrollingBackground bg2;

        private int destroyedJetCount;
        public int DestroyedJetCount => destroyedJetCount;
        
        private UserInterface ui;
            
        private Vector2 offset;

        private List<Bullet2D> bullets = new List<Bullet2D>();
        private List<Jet> enemies = new List<Jet>();
        private List<ModelSpawner> spawners = new List<ModelSpawner>();
        private List<Item> items = new List<Item>();

        private Globals.PassObject ResetWorld;

        public World(Globals.PassObject resetWorld)
        {
            ResetWorld = resetWorld;

            playerJet = new PlayerJet();
            GameGlobals.playerJet = playerJet;
            GameGlobals.playerBullets = new List<Bullet2D>();
            destroyedJetCount = 0;

            bg1 = new ScrollingBackground("star1",new Rectangle(0,0,900,675), 1);
            bg2 = new ScrollingBackground("star2", new Rectangle(0, -675,900,675), 1);
            GameGlobals.PassBullet = AddBullet;
            GameGlobals.PassEnemyJet = AddEnemyJet;
            offset = Vector2.Zero;
            spawners.Add(new SergeantSpawner(new Vector2(200, 200), new Vector2(35, 35), 100));
            ui = new UserInterface();
        }

        public void Update()
        {
            if(!playerJet.destroyed)
            {
                AdjustBackground();

                bg1.Update();
                bg2.Update();

                UpdateItems();
                UpdateSpawners();
                UpdateBullets();
                UpdateEnemyJets();
                playerJet.Update();
            }
            else
            {
                if(Globals.keyboard.GetPress("Enter"))
                {
                    ResetWorld(null);
                }
            }
            ui.Update(this);
        }
        private void UpdateItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Update();
                if (items[i].Taken)
                {
                    items.RemoveAt(i);
                }
            }
        }
        private void UpdateSpawners()
        {
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].Update();
                if(spawners[i].finished)
                {
                    spawners.RemoveAt(i);
                }
            }
        }

        private void UpdateBullets()
        {
            GameGlobals.playerBullets.Clear();
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(offset, enemies);
                if (bullets[i].outOfArena)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
                else if(bullets[i].owner is PlayerJet)
                {
                    GameGlobals.playerBullets.Add(bullets[i]);
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
                    Item itemToThrow = RandomItemSpawner.GetRandomItem((EnemyJet)enemies[i]);
                    items.Add(itemToThrow);
                    destroyedJetCount++;
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddEnemyJet(object enemyJet)
        {
            enemies.Add((EnemyJet)enemyJet);
        }
        public virtual void AddBullet(object bullet)
        {
            bullets.Add((Bullet2D)bullet);
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

            spawners.ForEach(location => location.Draw(offset));
            items.ForEach(item => item.Draw(offset));
            enemies.ForEach(enemy => enemy.Draw(offset));

            ui.Draw(this);
        }
    }
}
