using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using System.Linq;

namespace MASTopia
{
	public class MainMenu
	{
		public enum GameState {MainMenu,enterName,inGame}

		 public GameState gameState;

		private bool inGame = false;

		public bool InGame{
			get{return inGame;}
			set{ inGame = value;}
		}


	
		List<GUIElement>main = new List<GUIElement>();
		List<GUIElement>EnterName = new List<GUIElement>();

		private Keys[] lastPressedKeys = new Keys[5];

	//	private SpriteFont sf;

	
		private string myName = string.Empty;
		public MainMenu()
		{
			main.Add (new GUIElement ("Main-Menu/MAS-background"));
			main.Add (new GUIElement ("Main-Menu/play"));
			main.Add (new GUIElement ("Main-Menu/Settings"));
			main.Add (new GUIElement ("Main-Menu/leaderboard"));

			//EnterName.Add (new GUIElement ("Main-Menu/name"));
			EnterName.Add (new GUIElement ("Main-Menu/done"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			//sf = content.Load<SpriteFont> ("MyFont");
			foreach (GUIElement element in main) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
					
			}
			main.Find (x => x.AssetName == "Main-Menu/MAS-background").PutBg ();

			main.Find (x => x.AssetName == "Main-Menu/play").moveElement (720,900);
			main.Find (x => x.AssetName == "Main-Menu/Settings").moveElement (0,350);
			main.Find (x => x.AssetName == "Main-Menu/leaderboard").moveElement (300,350);


			foreach (GUIElement element in EnterName) {
				element.LoadContent (content,gameObjects);
				element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}
			EnterName.Find (x => x.AssetName == "Main-Menu/done").moveElement (0, 60);

		}
		public void Update(GameObjects gameObjects)
		{
			switch (gameState) {
			case GameState.MainMenu:
				foreach (GUIElement element in main) {
					element.Update (gameObjects);
				}
				break;
			case GameState.enterName:
				foreach (GUIElement element in EnterName) {
					element.Update (gameObjects);

				}
				GetKeys ();
				break;
			case GameState.inGame:
				break;
			default:
				break;
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			switch (gameState) {
			case GameState.MainMenu:
				foreach (GUIElement element in main) {
					element.Draw (spriteBatch);
				}
				break;
			case GameState.enterName:
				foreach (GUIElement element in EnterName) {
					element.Draw (spriteBatch);
				}
				break;
			case GameState.inGame:
				inGame = true;
				break;
			default:
				break;
			}


		}
		public void OnClick(string element)
		{
			if (element=="Main-Menu/play") {
				//play the game
				Console.WriteLine("You pressed Play");
				gameState = GameState.inGame;
				//inGame = true;
			}
			if (element =="Main-Menu/Settings") {
				gameState = GameState.enterName;
			}

			if (element=="Main-Menu/done") {
				gameState = GameState.MainMenu;
			}
		}
		public void GetKeys()
		{
			KeyboardState kbState = Keyboard.GetState ();
			Keys[] pressedKeys = kbState.GetPressedKeys ();

			foreach (Keys key in lastPressedKeys) {
				if (!pressedKeys.Contains(key)) {
					//key is no longer pressed
					OnKeyUp(key);
				}
			}
			foreach (Keys key in pressedKeys) {
				if (!lastPressedKeys.Contains(key)) {
					OnKeyDown (key);	
				}
			}
			lastPressedKeys = pressedKeys;
		}
		public void OnKeyUp(Keys key)
		{
		}
		public void OnKeyDown(Keys key)
		{
			if (key==Keys.Back && myName.Length>0) {
				myName = myName.Remove (myName.Length - 1);
			}
			else {
				myName += key.ToString ();
			}

			myName += key.ToString ();
		}

	}
}

