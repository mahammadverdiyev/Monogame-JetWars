using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace JetWars
{
	public class ItemSpawner
	{
		Random random = new Random();
		CustomTimer spawnTimer;
		private Item lastSpawnedItem;

		List<Type> spawnableItemTypes = new List<Type>();
			
		public ItemSpawner()
		{
			spawnableItemTypes.Add(typeof(MedKit));
			spawnableItemTypes.Add(typeof(JetSpeedIncreaser));
			spawnableItemTypes.Add(typeof(FireSpeedIncreaser));
			spawnableItemTypes.Add(typeof(AccuracyIncreaser));
			spawnableItemTypes.Add(typeof(Shield));
		
			spawnTimer = new CustomTimer(2000);
		}

		public void Update()
        {
			spawnTimer.UpdateTimer();
			if (lastSpawnedItem != null && lastSpawnedItem.Taken)
            {
				spawnTimer.ResetToZero();
				lastSpawnedItem = null;
			}
        }
		private Item GetItemAccordingType(Type type)
		{
			if (type == typeof(MedKit))
				return new MedKit(Vector2.Zero);
			else if (type == typeof(JetSpeedIncreaser))
				return new JetSpeedIncreaser(Vector2.Zero);
			else if (type == typeof(FireSpeedIncreaser))
				return new FireSpeedIncreaser(Vector2.Zero);
			else if (type == typeof(AccuracyIncreaser))
				return new AccuracyIncreaser(Vector2.Zero);
			else
				return new Shield(Vector2.Zero);
		}

		public Item GetRandomItem()
		{
			Item item;

			if (spawnTimer.Test())
			{
				int randIndex = random.Next(0, spawnableItemTypes.Count);
				
				item = GetItemAccordingType(spawnableItemTypes[randIndex]);

				if (lastSpawnedItem != null && !lastSpawnedItem.Taken)
					return null;

				int randX = random.Next(50, (int)(Globals.screenWidth - item.dimension.X - 50));
				int randY = random.Next(50, (int)(Globals.screenHeight - item.dimension.Y - 50));

				item.position = new Vector2(randX, randY);
				item.jet = GameGlobals.playerJet;
				lastSpawnedItem = item;

				Debug.WriteLine("SPAWNEDDD");

				spawnTimer.ResetToZero();
				return item;
			}
			else
				return null;
		}



        public Item GetRandomItem(EnemyJet enemyJet)
		{
			Random random = new Random();

			int randomIndex = random.Next(0, enemyJet.Items.Count);

			Item randomItem = enemyJet.Items[randomIndex];

			return randomItem;
		}
	}
}
