using JetWars.Source.Gameplay.Models.Abstracts;
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

namespace JetWars.Source.Gameplay.Models.Items
{
    public class AccuracyIncreaser : Item
    {
        public AccuracyIncreaser(Vector2 position)
        : base("accuracy", position, new Vector2(25, 25))
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void ItemTaken()
        {
            GameGlobals.playerJet.IncreaseAccuracy();
        }
    }
}
