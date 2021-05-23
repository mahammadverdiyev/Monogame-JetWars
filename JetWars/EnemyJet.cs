using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace JetWars
{
    public abstract class EnemyJet : Jet
    {
        protected Random rand;
        public Jet target;
        public int itemChanceToSpawn;
        protected List<Item> items = new List<Item>();

        public List<Item> Items => items;

        public EnemyJet(string path, Vector2 position, float speed, float _maxHealth)
            : base(path, position, new Vector2(60,60), speed, _maxHealth)
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

        private bool HitsPlayerJet => Physics.GetDistance(position, target.position) <= target.hitDistance;

        public abstract void BehaveArtificially();

        public abstract void Shoot();
    }
}
