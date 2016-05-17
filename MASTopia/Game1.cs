﻿using System;

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
		Vector3 ScalingFactor;
		Matrix Scale;

		private MainMenu mainMenu = new MainMenu();
		private GameView gameView = new GameView();
		private DrawBarracks barrack = new DrawBarracks();


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
		}
		public void CalculateGameBounds()
		{
			float widthScale = (float)GraphicsDevice.PresentationParameters.BackBufferWidth / virtualScreen.X; 
			float heightScale = (float)GraphicsDevice.PresentationParameters.BackBufferHeight / virtualScreen.Y;
			gameObjects.gameBoundY = (int)(virtualScreen.X * widthScale);
			gameObjects.gameBoundX = (int)(virtualScreen.Y * heightScale);
			gameObjects.WidthScale = widthScale;
			gameObjects.HeightScale = heightScale;
			Console.WriteLine (gameObjects.gameBoundX);
			Console.WriteLine (gameObjects.gameBoundY);

			Scale = Matrix.CreateScale(widthScale,heightScale,1);
		}

		protected override void Update (GameTime gameTime)
		{
			//Calculate ScalingFactor



			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif

			gameObjects.touchInput = new TouchInput ();
			GetTouchInput ();

			mainMenu.Update (gameObjects);
			if (mainMenu.InGame) {
				gameView.Update (gameObjects);
				if (gameView.State==MASTopia.GameView.GamePart.barracks) {
					barrack.Update (gameObjects);
				}
			}
			base.Update (gameTime);
		}

		private void GetTouchInput()
		{
			
			var TouchpannelState = TouchPanel.GetState ();

			while (TouchPanel.IsGestureAvailable) {
				var gesture = TouchPanel.ReadGesture ();
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
//					Console.WriteLine (touch.Position.X);
//					Console.WriteLine (touch.Position.X/gameObjects.WidthScale);

				}

			}
		}
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//TODO: Add your drawing code here
            
			spriteBatch.Begin (SpriteSortMode.Texture, null, null, null, null,null, Scale);

			//spriteBatch.Begin();
			mainMenu.Draw(spriteBatch);
			if (mainMenu.InGame) {
				gameView.Draw (spriteBatch);
				if (gameView.State==MASTopia.GameView.GamePart.barracks) {
					barrack.Draw (spriteBatch);
				}
			}

			spriteBatch.End ();

			base.Draw (gameTime);
		}

	}
} 

