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
        public EnemyJet(string path,Vector2 position,float speed,float _maxHealth) 
            : base(path, position, new Vector2(60,60),speed,_maxHealth)
        {
        }

        public override void Update()
        {
            base.Update();
            BehaveArtificially();
        }

        public abstract void BehaveArtificially();

        public abstract void Shoot();
    }
}
