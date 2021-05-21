using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace JetWars
{
    public enum State
	{
        StartMenu,
        Playing,
        ExitButtonClicked,
	}

    public class UserInterface
    {
        public SpriteFont font;

        public DisplayBar healthBar;

        private Button startButton;
        private Button exitButton;

        public UserInterface()
        {
            font = Globals.content.Load<SpriteFont>("Arial");

            healthBar = new DisplayBar(new Vector2(200,20), 2, Color.Green);

            startButton = new Button("start_button", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 - 85), new Vector2(400, 150));
            exitButton = new Button("exit_button", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 15), new Vector2(400, 150));
        }

        public void Update(World world)
        {
            healthBar.Update(GameGlobals.playerJet.health, GameGlobals.playerJet.maxHealth);
        }
        public void Draw(World world)
        {
            string str = string.Empty;
            Vector2 strDimensions = Vector2.Zero;

            switch (Globals.state)
			{
				case State.StartMenu:
                    startButton.Draw(Vector2.Zero);
                    exitButton.Draw(Vector2.Zero);
                    HandleClick();
                    break;
                case State.Playing:
                    str = $"Destroyed: {world.DestroyedJetCount}";
                    strDimensions = font.MeasureString(str);
                    Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2, Globals.screenHeight - strDimensions.Y), Color.White);
                    healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));

                    int margin_right = 15;
                    str = $"Jet speed: {GameGlobals.playerJet.speed}";
                    strDimensions = font.MeasureString(str);
                    Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 4 * strDimensions.Y), Color.White);

                    str = $"Firing speed: {GameGlobals.playerJet.BulletFireSpeed}";
                    strDimensions = font.MeasureString(str);
                    Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 3 * strDimensions.Y), Color.White);

                    str = $"Accuracy: {GameGlobals.playerJet.AccuracyValue}";
                    strDimensions = font.MeasureString(str);
                    Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 2 * strDimensions.Y), Color.White);

                    str = $"Max health: {GameGlobals.playerJet.maxHealth}";
                    strDimensions = font.MeasureString(str);
                    Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth - strDimensions.X - margin_right, Globals.screenHeight - 1 * strDimensions.Y), Color.White);
                    break;
			}

            if (GameGlobals.playerJet.destroyed)
            {
                Globals.state = State.StartMenu;
                str = $"Press Enter to Restart";
                strDimensions = font.MeasureString(str);
                Globals.spriteBatch.DrawString(font, str, new Vector2(Globals.screenWidth / 2 - strDimensions.X / 2, Globals.screenHeight / 2), Color.White);
            }
        }

		private void HandleClick()
		{
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (Globals.mouse.newMousePos.X >= startButton.position.X &&
                    Globals.mouse.newMousePos.X <= startButton.position.X + startButton.dimension.X &&
                    Globals.mouse.newMousePos.Y >= startButton.position.Y &&
                    Globals.mouse.newMousePos.Y <= startButton.position.Y + startButton.dimension.Y
                    )
                {
                    Debug.WriteLine("Start Button Clicked");
                    Globals.state = State.Playing;
                }
                else if (Globals.mouse.newMousePos.X >= exitButton.position.X &&
                    Globals.mouse.newMousePos.X <= exitButton.position.X + exitButton.dimension.X &&
                    Globals.mouse.newMousePos.Y >= exitButton.position.Y &&
                    Globals.mouse.newMousePos.Y <= exitButton.position.Y + exitButton.dimension.Y
                    )
				{
                    Debug.WriteLine("Exit Button Clicked");
                    Globals.state = State.ExitButtonClicked;
				}
			}
		}
	}
}
