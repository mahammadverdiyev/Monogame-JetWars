using System;

namespace JetWars
{
	public static class RandomItemSpawner
	{
		public static Item GetRandomItem(EnemyJet enemyJet)
		{
			Random random = new Random();

			int randomIndex = random.Next(0, enemyJet.Items.Count);

			Item randomItem = enemyJet.Items[randomIndex];

			return randomItem;
		}
	}
}
