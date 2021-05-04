#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using JetWars.Source.Gameplay.Models.Jets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars.Source.Gameplay
{
    public class SpawnLocation : Basic2D
    {
        public METimer spawnTimer;
        public SpawnLocation(string path, Vector2 position, Vector2 dimension)
            :base(path,position,dimension)
        {
            spawnTimer = new METimer(2000);
        }

        public override void Update()
        {
            spawnTimer.UpdateTimer();
            
            if(spawnTimer.Test())
            {
                SpawnEnemy();
                spawnTimer.ResetToZero();
            }
        }

        public virtual void SpawnEnemy()
        {
            GameGlobals.PassEnemyJet(new BasicEnemyJet(new Vector2(position.X, position.Y)));
        }
    }
}
