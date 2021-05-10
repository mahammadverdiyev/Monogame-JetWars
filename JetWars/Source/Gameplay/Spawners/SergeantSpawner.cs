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

namespace JetWars.Source.Gameplay.Spawners
{
    public class SergeantSpawner : ModelSpawner
    {
        public SergeantSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
        : base("circle", position, dimension, maxModelCount,3000)
  
        {
            spawnTimer = new METimer(100);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new SergeantEnemyJet(new Vector2(position.X, position.Y),4.0f));
        }
    }
}
