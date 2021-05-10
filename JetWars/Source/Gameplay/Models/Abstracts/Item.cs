using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetWars.Source;
using JetWars.Source.Engine;
using JetWars.Source.Gameplay;
using JetWars.Source.Gameplay.Models;
using JetWars.Source.Gameplay.Models.Jets;
using JetWars.Source.Gameplay.Spawners;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JetWars.Source.Gameplay.Models.Abstracts
{
    public abstract class Item : Basic2D
    {
        private bool taken;
        PlayerJet jet;

        public bool Taken { get { return taken;  } }
    
        public Item(string path,Vector2 position, Vector2 dimension)
        : base(path,position,dimension)
        {
            jet = GameGlobals.playerJet;
            taken = false;
        }

        public override void Update()
        {
            if(IsItemClose)
            {
                taken = true;
                ItemTaken();
            }
        }

        private bool IsItemClose
            => Physics.GetDistance(position, jet.position) < jet.hitDistance;

        public abstract void ItemTaken();

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
