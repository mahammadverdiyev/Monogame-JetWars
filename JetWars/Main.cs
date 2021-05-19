using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using JetWars.Source;
using JetWars.Source.Engine;

namespace JetWars
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;

        private GamePlay gamePlay;

        private Rectangle leftBound;
        private Rectangle rightBound;
        private Rectangle topBound;
        private Rectangle bottomBound;

        public Rectangle LeftBound => leftBound;
        public Rectangle RightBound => rightBound;
        public Rectangle TopBound => topBound;
        public Rectangle BottomBound => bottomBound;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.screenWidth = 900;
            Globals.screenHeight = 675;

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            InitializeGlobals();
            gamePlay = new GamePlay();
            Physics.Game = this;
            Globals.keyboard = new KeyBoardControl();

            leftBound = new Rectangle(18, 0, 1, Globals.screenHeight);
            rightBound = new Rectangle(Globals.screenWidth + 22, 0, 1, Globals.screenHeight);
            topBound = new Rectangle(0, 10, Globals.screenWidth, 1);
            bottomBound = new Rectangle(0, Globals.screenHeight + 22, Globals.screenWidth, 1);
        }

        private void InitializeGlobals()
        {
            Globals.content = Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.mouse = new MouseControl();
            Globals.screenWidth = GraphicsDevice.Viewport.Width;
            Globals.screenHeight = GraphicsDevice.Viewport.Height;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Globals.keyboard.GetPress("Escape"))
                Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();

            gamePlay.Update();

            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            gamePlay.Draw();


            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
