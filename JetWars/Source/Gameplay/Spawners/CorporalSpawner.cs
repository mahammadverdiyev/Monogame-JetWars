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
    public class CorporalSpawner : ModelSpawner
    {
        public CorporalSpawner(Vector2 position, Vector2 dimension, int maxModelCount)
        : base("circle", position, dimension, maxModelCount, 1000)
        {
            spawnTimer = new METimer(3000);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new CorporalEnemyJet(new Vector2(position.X, position.Y), 2.0f));
        }
    }
}
