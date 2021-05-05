using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using JetWars.Source.Gameplay.Models;

namespace JetWars
{
    public class GameGlobals
    {
        public static PlayerJet playerJet;
        public static Globals.PassObject PassBullet, PassEnemyJet;
    }
}
