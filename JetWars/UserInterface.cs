using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private Texture2D jetUITexture;
        private Texture2D titleUITexture;
        private Song mainMenuSound;

        public UserInterface()
        {
            font = Globals.content.Load<SpriteFont>("Arial");

            healthBar = new DisplayBar(new Vector2(200,20), 2, Color.Green);

            startButton = new Button("start_button", new Vector2(Globals.screenWidth / 2 + 150, Globals.screenHeight / 2 - 85), new Vector2(400, 150));
            exitButton = new Button("exit_button", new Vector2(Globals.screenWidth / 2 + 150, Globals.screenHeight / 2 + 15), new Vector2(400, 150));

            jetUITexture = Globals.content.Load<Texture2D>("background_jet");
            titleUITexture = Globals.content.Load<Texture2D>("title");
            
        }

        public void Update(World world)
        {
            healthBar.Update(GameGlobals.playerJet.health, GameGlobals.playerJet.maxHealth);
            startButton.Update();
            exitButton.Update();

            if(Globals.currentState == State.StartMenu)
                HandleMenuClicks();
        }
        public void Draw(World world)
        {
            string str = string.Empty;
            Vector2 strDimensions = Vector2.Zero;

            switch (Globals.currentState)
			{
				case State.StartMenu:
                    Globals.spriteBatch.Draw(jetUITexture, new Rectangle(
                        30, 
                        Globals.screenHeight / 2 - 200,
                        Globals.screenWidth / 2 + 80, 
                        Globals.screenHeight / 2 + 80), 
                        Color.White
                        );
                    Globals.spriteBatch.Draw(titleUITexture, new Rectangle(
                        Globals.screenWidth / 2 + 100,
                        50,
                        293,
                        172),
                        Color.White
                        );
                    startButton.Draw(Vector2.Zero);
                    exitButton.Draw(Vector2.Zero);
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
        }

		private void HandleMenuClicks()
		{
            if(Globals.mouse.LeftClick())
            {
                if (startButton.isHovering)
                {
                    Debug.WriteLine("Start Button Clicked");
                    Globals.oldState = Globals.currentState;
                    Globals.currentState = State.Playing;
                }

                else if (exitButton.isHovering)
                {
                    Debug.WriteLine("Exit Button Clicked");
                    Globals.currentState = State.ExitButtonClicked;
				}
                Debug.WriteLine(Globals.mouse.newMousePos.ToString());
                Debug.WriteLine(exitButton.position.ToString());
            }
		}
	}
}
