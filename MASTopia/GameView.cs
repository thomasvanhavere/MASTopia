using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;

namespace MASTopia
{
	public class GameView
	{

		public enum GamePart
		{
			main,
			faction,
			market,
			waste,
			harbour,
			profile,
			settings,
			Xp,
			Monney,
			barracks
		}

		private GamePart gamePart;
		List<GUIElement> mainBuildings = new List<GUIElement>();
		List<GUIElement> BasicElements = new List<GUIElement>();
		public GamePart State {
			get
			{
				return gamePart;
			}
			set 
			{
				gamePart = value;
			}
		}

		public GameView ()
		{
			mainBuildings.Add (new GUIElement ("Main-Game/island"));
			mainBuildings.Add (new GUIElement ("Main-Game/barracks"));
			mainBuildings.Add (new GUIElement ("Main-Game/Flag"));
			mainBuildings.Add (new GUIElement ("Main-Game/market"));
			mainBuildings.Add (new GUIElement ("Main-Game/boat"));
			mainBuildings.Add (new GUIElement ("Main-Game/money-button"));
			mainBuildings.Add (new GUIElement ("Main-Game/profile"));
			mainBuildings.Add (new GUIElement ("Main-Game/settings"));
			mainBuildings.Add (new GUIElement ("Main-Game/wastePlant"));
			mainBuildings.Add (new GUIElement ("Main-Game/Xp-Level"));

			BasicElements.Add(new GUIElement("Main-Menu/done"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in mainBuildings) {
				element.LoadContent (content,gameObjects);
				//element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}
			mainBuildings.Find (x => x.AssetName == "Main-Game/island").PutBg ();


			mainBuildings.Find (x => x.AssetName == "Main-Game/money-button").moveElement (-550, -400);
			mainBuildings.Find (x => x.AssetName == "Main-Game/Xp-Level").moveElement (-150, -400);
			mainBuildings.Find (x => x.AssetName == "Main-Game/profile").moveElement (600, -350);

			mainBuildings.Find (x => x.AssetName == "Main-Game/barracks").moveElement (-130, -300);
			mainBuildings.Find (x => x.AssetName == "Main-Game/Flag").moveElement (-425, -150);
			mainBuildings.Find (x => x.AssetName == "Main-Game/market").moveElement (200, -175);

			mainBuildings.Find (x => x.AssetName == "Main-Game/settings").moveElement (600, 350);
			mainBuildings.Find (x => x.AssetName == "Main-Game/wastePlant").moveElement (200, 100);
			mainBuildings.Find (x => x.AssetName == "Main-Game/boat").moveElement (-550, 300);

			foreach (var element in BasicElements) {
				element.LoadContent (content,gameObjects);
				element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}

		}
		public void Update(GameObjects gameObjects)
		{
			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.market:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.faction:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.harbour:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.profile:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.waste:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.settings:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.Monney:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.Xp:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}

		}


		public void Draw(SpriteBatch spriteBatch)
		{
			

			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.market:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.faction:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.harbour:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.profile:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.waste:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.settings:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.Monney:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.Xp:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			
			default:
				break;
			}

		}
		public void OnClick(string element)
		{
			if (element=="Main-Game/market") {
				gamePart = GamePart.market;
			}
			if (element=="Main-Game/Flag") {
				gamePart = GamePart.faction;
			}
			if (element=="Main-Game/boat") {
				gamePart = GamePart.harbour;
			}
			if (element=="Main-Game/profile") {
				gamePart = GamePart.profile;
			}
			if (element=="Main-Game/wastePlant") {
				gamePart = GamePart.waste;
			}
			if (element=="Main-Game/settings") {
				gamePart = GamePart.settings;
			}
			if (element=="Main-Game/money-button") {
				gamePart = GamePart.Monney;
			}
			if (element=="Main-Game/Xp-Level") {
				gamePart = GamePart.Xp;
			}
			if (element=="Main-Game/barracks") {
				gamePart = GamePart.barracks;
			}
			if (element=="Main-Menu/done") {
				gamePart = GamePart.main;
			}
		}
	}
}

