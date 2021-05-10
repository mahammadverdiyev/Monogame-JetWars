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

namespace JetWars.Source.Gameplay
{
    public abstract class ModelSpawner : Basic2D
    {
        public METimer spawnTimer;
        public int maxModelCount;
        public int modelCounter;
        public bool finished;

        public ModelSpawner(string path, Vector2 position, Vector2 dimension,int maxModelCount,int spawnInterval)
            :base(path,position,dimension)
        {
            finished = false;
            modelCounter = 0;
            this.maxModelCount = maxModelCount < 0 ? int.MaxValue : maxModelCount;
            spawnTimer = new METimer(spawnInterval);
        }

        public override void Update()
        {
            if(modelCounter < maxModelCount)
            {
                spawnTimer.UpdateTimer();

                if (spawnTimer.Test())
                {
                    modelCounter++;
                    SpawnModel();
                    spawnTimer.ResetToZero();
                }
            }
            else
            {
                finished = true;
            }

        }

        public abstract void SpawnModel();
    }
}
