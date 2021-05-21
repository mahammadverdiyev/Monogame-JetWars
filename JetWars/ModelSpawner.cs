using Microsoft.Xna.Framework;

namespace JetWars
{
    public abstract class ModelSpawner : Basic2D
    {
        public CustomTimer spawnTimer;
        public int maxModelCount;
        public int modelCounter;
        public bool finished;

        public ModelSpawner(string path, Vector2 position, Vector2 dimension, int maxModelCount, int spawnInterval)
            :base(path,position,dimension)
        {
            finished = false;
            modelCounter = 0;
            this.maxModelCount = maxModelCount < 0 ? int.MaxValue : maxModelCount;
            spawnTimer = new CustomTimer(spawnInterval);
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
