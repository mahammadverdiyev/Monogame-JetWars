using JetWars.Source.Engine;
using JetWars.Source.Gameplay.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetWars.Source.Gameplay.Models.Jets
{
    public abstract class EnemyJet : Jet
    {
        public EnemyJet(string path,Vector2 position) : base(path, position, new Vector2(60,60))
        {
        }

        public override void Update()
        {
            BehaveArtificially();
        }

        public abstract void BehaveArtificially();

        public abstract void Shoot();
    }
}
