using JetWars.Source.Gameplay.Models.Jets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetWars.Source.Gameplay.Spawners
{
    public class AdvancedEnemyJetSpawner : ModelSpawner
    {
        public AdvancedEnemyJetSpawner(Vector2 position, Vector2 dimension, int maxModelCount) : base("circle", position, dimension, maxModelCount)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SpawnModel()
        {
            GameGlobals.PassEnemyJet(new AdvancedEnemyJet(new Vector2(position.X, position.Y), 5.0f));

        }
    }
}
