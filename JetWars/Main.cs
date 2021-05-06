﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using JetWars.Source;
#endregion

namespace JetWars
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GamePlay gamePlay;

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
        }

        private void InitializeGlobals()
        {
            Globals.leftBound = new Rectangle(18, 0, 1, Globals.screenHeight);
            Globals.rightBound = new Rectangle(Globals.screenWidth + 22, 0, 1, Globals.screenHeight);
            Globals.topBound = new Rectangle(0, 10, Globals.screenWidth, 1);
            Globals.bottomBound = new Rectangle(0, Globals.screenHeight + 22, Globals.screenWidth, 1);
            Globals.content = Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.keyboard = new KeyboardControl();
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
