using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MASTopia
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private GameObjects gameObjects;

		//Resolution Independence
		Vector2 virtualScreen = new Vector2(1920f, 1080f);
		//Vector3 ScalingFactor;
		Matrix Scale;

		private MainMenu mainMenu = new MainMenu();
		private GameView gameView = new GameView();
		private DrawBarracks barrack = new DrawBarracks();
		private DrawHarbour harbour = new DrawHarbour();

		//private GUIElement menu;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";

		}


		protected override void Initialize ()
		{
			IsMouseVisible = true;  


			TouchPanel.EnabledGestures = GestureType.VerticalDrag | GestureType.Flick | GestureType.Tap; 

			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			gameObjects = new GameObjects();
			CalculateGameBounds ();
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//gameObjects = new GameObjects{gameBoundX=Window.ClientBounds.Height,gameBoundY=Window.ClientBounds.Width};


			mainMenu.LoadContent (Content,gameObjects);
			gameView.LoadContent (Content, gameObjects);
			barrack.LoadContent (Content, gameObjects);
			harbour.LoadContent (Content, gameObjects);
		}
		public void CalculateGameBounds()
		{
			float widthScale = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / virtualScreen.X; 
			float heightScale = (float)GraphicsDevice.PresentationParameters.BackBufferHeight / virtualScreen.Y;
			gameObjects.gameBoundY = (int)(virtualScreen.X * widthScale);
			gameObjects.gameBoundX = (int)(virtualScreen.Y * heightScale);
			gameObjects.WidthScale = widthScale;
			gameObjects.HeightScale = heightScale;
			Scale = Matrix.CreateScale(widthScale,heightScale,1);
		}

		protected override void Update (GameTime gameTime)
		{
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
			gameObjects.touchInput = new TouchInput ();
			GetTouchInput ();

			mainMenu.Update (gameObjects);
			if (mainMenu.State==MainMenu.GameState.inGame) {
				gameView.Update (gameObjects);

				if (gameView.State == MASTopia.GameView.GamePart.barracks) {
					barrack.Update (gameObjects);
					if (barrack.scherm == DrawBarracks.screens.Exit) {
						gameView.State = GameView.GamePart.main;
						barrack.scherm = DrawBarracks.screens.Screen1;

					}
					if (gameView.State==MASTopia.GameView.GamePart.harbour) {
						harbour.Update (gameObjects);
						if (harbour.State==DrawHarbour.Acties.Exit) {
							gameView.State = GameView.GamePart.main;
							harbour.State = DrawHarbour.Acties.main;

						}
					}
				}
			}


			base.Update (gameTime);
		}

		private void GetTouchInput()
		{
			
			var TouchpannelState = TouchPanel.GetState ();
			while (TouchPanel.IsGestureAvailable) {
				var gesture = TouchPanel.ReadGesture ();
				if (gesture.GestureType==GestureType.Flick) {
					if (gesture.Delta.X<0) {
						gameObjects.touchInput.swippedLeft = true;
					}
					if (gesture.Delta.X>0) {
						gameObjects.touchInput.swippedRight = true;

					}
				}
			
				if (gesture.Delta.Y>0) {
					gameObjects.touchInput.down = true;
				}
				if (gesture.Delta.Y<0) {
					gameObjects.touchInput.up = true;
				}
				if (gesture.GestureType==GestureType.Tap) {
					gameObjects.touchInput.tapped = true;
				}

				if (TouchpannelState.Count>=1) {
					var touch = TouchpannelState [0];
					gameObjects.touchInput.X = (int)(touch.Position.X/gameObjects.WidthScale);
					gameObjects.touchInput.Y = (int)(touch.Position.Y/gameObjects.HeightScale);

				}

			}
		}
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//TODO: Add your drawing code here
            
			spriteBatch.Begin (SpriteSortMode.Texture, null, null, null, null,null, Scale);

			mainMenu.Draw(spriteBatch);
			if (mainMenu.State==MainMenu.GameState.inGame) {
				gameView.Draw (spriteBatch);

				if (gameView.State == MASTopia.GameView.GamePart.barracks) {
					barrack.Draw (spriteBatch);
				}

				if (gameView.State==MASTopia.GameView.GamePart.harbour) {
					harbour.Draw (spriteBatch);
				}

			}

			spriteBatch.End ();

			base.Draw (gameTime);
		}

	}
} 

