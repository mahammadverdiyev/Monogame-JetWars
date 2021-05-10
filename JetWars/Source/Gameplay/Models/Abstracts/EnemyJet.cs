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
        protected Random rand;
        public Jet target;

        public EnemyJet(string path,Vector2 position,float speed,float _maxHealth) 
            : base(path, position, new Vector2(60,60),speed,_maxHealth)
        {
            target = GameGlobals.playerJet;
            rand = new Random();
        }

        public override void Update()
        {
            base.Update();
            if(HitsPlayerJet)
            {
                GetHit(maxHealth);
                target.GetHit(target.maxHealth);
            }
            BehaveArtificially();
        }

        private bool HitsPlayerJet =>
    Physics.GetDistance(position, target.position) <= target.hitDistance;

        public abstract void BehaveArtificially();

        public abstract void Shoot();
    }
}
