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
		public enum GameState {MainMenu,inGame,settings,factions}

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
			main.Add (new GUIElement ("Main-Menu/Background"));
			main.Add (new GUIElement ("Main-Menu/cloud"));
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
			main.Find (x => x.AssetName == "Main-Menu/Background").PutBg();

			main.Find (x => x.AssetName == "Main-Menu/MAS-background").moveElement (0,10);
			main.Find (x => x.AssetName == "Main-Menu/play").moveElement (730,835);
			main.Find (x => x.AssetName == "Main-Menu/Settings").moveElement (550,850);
			main.Find (x => x.AssetName == "Main-Menu/leaderboard").moveElement (1200,850);

		
		}
		int X=1,Y;
		public void Update(GameObjects Obj)
		{
			
			foreach (GUIElement element in main) {
				if (element.AssetName=="Main-Menu/cloud") {

					Y++;
					if (Y==1) {
						element.moveElement(X,0);
						Y = 0;
					}
					if (element.guiRect.X>1920) {
						element.moveElement(-3840,0);
					}

				} else {
					element.Update (Obj);

				}

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

			if (element=="Main-Menu/leaderboard") {
				gameState = GameState.factions;
			}
		}

	}
}

