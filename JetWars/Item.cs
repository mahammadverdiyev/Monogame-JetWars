using Microsoft.Xna.Framework;

namespace JetWars
{
    public abstract class Item : Basic2D
    {
        private bool taken;
        public PlayerJet jet;

        public bool Taken { get { return taken;  } }
    
        public Item(string path,Vector2 position, Vector2 dimension)
        : base(path,position,new Vector2(30,30))
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
