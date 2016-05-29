using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;
using System.Threading;

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
		Matrix Scale;

		//Timer timer = new Timer (callback,"some state",TimeSpan.FromSeconds(1),TimeSpan.FromSeconds(1));


		private MainMenu mainMenu = new MainMenu();
		private GameView gameView = new GameView();
		private DrawBarracks barrack = new DrawBarracks();
		private DrawHarbour harbour = new DrawHarbour();
		private DrawMarket market = new DrawMarket();
		private DrawResto resto = new DrawResto();
		private DrawFarm farm = new DrawFarm();
		private DrawWastePlant waste = new DrawWastePlant();
		private SettingsMenu settings = new SettingsMenu();
		private DrawProfile profile = new DrawProfile();
		private DrawFactions factions = new DrawFactions();
		private BaseLogics baselogics = new BaseLogics();
		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";

		}
		private static void callback(object state)
		{
			Console.WriteLine("Called back with state = ");

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



			mainMenu.LoadContent (Content,gameObjects);

			gameView.LoadContent (Content, gameObjects);
			barrack.LoadContent (Content, gameObjects);
			harbour.LoadContent (Content, gameObjects);
			market.LoadContent (Content, gameObjects);
			resto.LoadContent (Content, gameObjects);
			farm.LoadContent (Content, gameObjects);
			waste.LoadContent (Content, gameObjects);
			settings.LoadContent (Content, gameObjects);
			profile.LoadContent (Content, gameObjects);
			factions.LoadContent (Content, gameObjects);


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
			if (mainMenu.State == MainMenu.GameState.MainMenu) {
				mainMenu.Update (gameObjects);
			}
			if (mainMenu.State==MainMenu.GameState.settings) {
				settings.Update (gameObjects);
				if (settings.State==SettingsMenu.Acties.Exit) {
					mainMenu.State = MainMenu.GameState.MainMenu;
					settings.State = SettingsMenu.Acties.main;
				}
			}
			if (mainMenu.State==MainMenu.GameState.factions) {
				factions.Update (gameObjects);
				if (factions.State==DrawFactions.Acties.Exit) {
					mainMenu.State = MainMenu.GameState.MainMenu;
					factions.State = DrawFactions.Acties.main;
				}
			}
			if (mainMenu.State==MainMenu.GameState.inGame) {
				gameView.Update (gameObjects);

				if (gameView.State == MASTopia.GameView.GamePart.barracks) {
					barrack.Update (gameObjects);
					if (barrack.scherm == DrawBarracks.screens.Exit) {
						gameView.State = GameView.GamePart.main;
						barrack.scherm = DrawBarracks.screens.Screen1;

					}

				}
				if (gameView.State==MASTopia.GameView.GamePart.harbour) {
					harbour.Update (gameObjects);
					if (harbour.State==DrawHarbour.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						harbour.State = DrawHarbour.Acties.main;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.market) {
					market.Update (gameObjects);
					if (market.scherm==DrawMarket.Screens.Exit) {
						gameView.State = GameView.GamePart.main;
						market.scherm = DrawMarket.Screens.Screen1;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.resto) {
					resto.Update (gameObjects);
					if (resto.State==DrawResto.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						resto.State = DrawResto.Acties.main;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.farm) {
					farm.Update (gameObjects);
					if (farm.State==DrawFarm.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						farm.State = DrawFarm.Acties.main;
					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.waste) {
					waste.Update (gameObjects);
					if (waste.State==DrawWastePlant.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						waste.State = DrawWastePlant.Acties.main;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.profile) {
					profile.Update (gameObjects);
					if (profile.State==DrawProfile.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						profile.State = DrawProfile.Acties.main;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.faction) {
					factions.Update (gameObjects);
					if (factions.State==DrawFactions.Acties.Exit) {
						gameView.State = GameView.GamePart.main;
						factions.State = DrawFactions.Acties.main;

					}
				}
				if (gameView.State==MASTopia.GameView.GamePart.mainMenu) {
					gameView.State = GameView.GamePart.main;
					mainMenu.State = MainMenu.GameState.MainMenu;
				}
				if (gameView.State==MASTopia.GameView.GamePart.settings) {
					settings.Update (gameObjects);
					if (settings.State==SettingsMenu.Acties.Exit) {
						settings.State = SettingsMenu.Acties.main;
						gameView.State = GameView.GamePart.main;

					}
				}
					
			}
			baselogics.fillProp(gameTime,farm,harbour,gameObjects, market);
			baselogics.update (gameTime, resto, gameObjects);
			base.Update(gameTime);
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
            
			gameObjects.gameTime = gameTime;
			spriteBatch.Begin (SpriteSortMode.Immediate, null, null, null, null,null, Scale);

			if (mainMenu.State==MainMenu.GameState.MainMenu) {
				mainMenu.Draw(spriteBatch);

			}

			if (mainMenu.State==MainMenu.GameState.settings) {
				settings.Draw (spriteBatch);

			}
			if (mainMenu.State==MainMenu.GameState.factions) {
				factions.Draw (spriteBatch);

			}
			if (mainMenu.State==MainMenu.GameState.inGame) {
				gameView.Draw (spriteBatch,gameObjects);

				if (gameView.State == MASTopia.GameView.GamePart.barracks) {
					barrack.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.harbour) {
					harbour.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.market) {
					market.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.resto) {
					resto.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.farm) {
					farm.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.waste) {
					waste.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.profile) {
					profile.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.faction) {
					factions.Draw (spriteBatch);
				}
				if (gameView.State==MASTopia.GameView.GamePart.settings) {
					settings.Draw (spriteBatch);
				}
			}

			spriteBatch.End ();

			base.Draw (gameTime);
		}

	}
} 

