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
		public enum GameState {MainMenu,inGame,settings}

		 public GameState gameState = GameState.MainMenu;

	
		public GameState State {
			get
			{
				return gameState;
			}
			set 
			{
				gameState = value;
			}
		}
		List<GUIElement>main = new List<GUIElement>();
		public MainMenu()
		{
			main.Add (new GUIElement ("Main-Menu/MAS-background"));
			main.Add (new GUIElement ("Main-Menu/play"));
			main.Add (new GUIElement ("Main-Menu/Settings"));
			main.Add (new GUIElement ("Main-Menu/leaderboard"));
		}
		public void LoadContent(ContentManager content , GameObjects Obj)
		{
			foreach (GUIElement element in main) {
				element.LoadContent (content,Obj);
				element.clickEvent += OnClick;
					
			}
			main.Find (x => x.AssetName == "Main-Menu/MAS-background").PutBg ();
			main.Find (x => x.AssetName == "Main-Menu/play").moveElement (765,850);
			main.Find (x => x.AssetName == "Main-Menu/Settings").moveElement (550,850);
			main.Find (x => x.AssetName == "Main-Menu/leaderboard").moveElement (1200,850);
		}
		public void Update(GameObjects Obj)
		{
			
				foreach (GUIElement element in main) {
					element.Update (Obj);
				}

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			
				foreach (GUIElement element in main) {
					element.Draw (spriteBatch);
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
				gameState = GameState.settings;
			}

			if (element=="Main-Menu/done") {
				gameState = GameState.MainMenu;
			}
		}

	}
}

