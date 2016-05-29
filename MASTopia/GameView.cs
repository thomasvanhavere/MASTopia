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
			resto,
			farm,
			Xp,
			BackMenu,
			mainMenu,
			settings,
			Monney,
			barracks
		}

		private GamePart gamePart;
		List<GUIElement> mainBuildings = new List<GUIElement>();
		List<GUIElement> backMenu = new List<GUIElement>();

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
		private SpriteFont font;

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
			mainBuildings.Add (new GUIElement ("Main-Game/grounds"));
			mainBuildings.Add (new GUIElement ("Main-Game/farm"));
			mainBuildings.Add (new GUIElement ("Main-Game/Foodtruck"));

			backMenu.Add (new GUIElement ("Back-Menu/screen"));
			backMenu.Add (new GUIElement ("Back-Menu/main-menu"));
			backMenu.Add (new GUIElement ("Back-Menu/settings-button"));
			backMenu.Add (new GUIElement ("Back-Menu/close-button"));

		}
		public void LoadContent(ContentManager content , GameObjects Obj)
		{
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in mainBuildings) {
				element.LoadContent (content,Obj);
				element.clickEvent += OnClick;
			}
			mainBuildings.Find (x => x.AssetName == "Main-Game/island").PutBg ();

			mainBuildings.Find (x => x.AssetName == "Main-Game/money-button").moveElement (50, 50);
			mainBuildings.Find (x => x.AssetName == "Main-Game/Xp-Level").moveElement  (350,50);
			mainBuildings.Find (x => x.AssetName == "Main-Game/settings").moveElement  (1700,50);

			mainBuildings.Find (x => x.AssetName == "Main-Game/barracks").moveElement  (850,100);
			mainBuildings.Find (x => x.AssetName == "Main-Game/Flag").moveElement  (450,220);
			mainBuildings.Find (x => x.AssetName == "Main-Game/market").moveElement  (1075,330);

			mainBuildings.Find (x => x.AssetName == "Main-Game/profile").moveElement  (1700,900);
			mainBuildings.Find (x => x.AssetName == "Main-Game/wastePlant").moveElement  (1100,580);

			mainBuildings.Find (x => x.AssetName == "Main-Game/boat").moveElement  (200,750);
			mainBuildings.Find (x => x.AssetName == "Main-Game/grounds").moveElement  (1185,240);

			mainBuildings.Find (x => x.AssetName == "Main-Game/farm").moveElement  (1250,390);
			mainBuildings.Find (x => x.AssetName == "Main-Game/Foodtruck").moveElement  (840,480);

			foreach (GUIElement element in backMenu) {
				element.LoadContent (content,Obj);
				element.clickEvent += OnClick;
			}
			backMenu.Find (x => x.AssetName == "Back-Menu/main-menu").moveElement  (680,380);
			backMenu.Find (x => x.AssetName == "Back-Menu/settings-button").moveElement  (680,580);
			backMenu.Find (x => x.AssetName == "Back-Menu/close-button").moveElement  (1743,280);


		}
		public void Update(GameObjects gameObjects)
		{
			

			if (gamePart==GamePart.BackMenu) {
				
			}

			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.BackMenu:
				
				foreach (GUIElement element in mainBuildings) {
					element.Update (gameObjects);
				}
				foreach (GUIElement element in backMenu) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}
		}


		public void Draw(SpriteBatch spriteBatch,GameObjects obj)
		{
			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Draw (spriteBatch);
				}

				break;
			case GamePart.BackMenu:
				foreach (GUIElement element in mainBuildings) {
					element.Draw (spriteBatch);
				}
				foreach (GUIElement element in backMenu) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}
			spriteBatch.DrawString(font, obj.XP.ToString()+"/"+obj.NextLevel.ToString(),new Vector2(480,55), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, obj.Money.ToString(),new Vector2(150,55), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, obj.PLayerLevel.ToString(),new Vector2(390,55), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);


		}
		public void OnClick(string element)
		{
			if (element=="Main-Game/market") {
				gamePart = GamePart.market;

			}
			if (element=="Main-Game/Flag") {
				gamePart = GamePart.faction;
				Console.WriteLine("clicked flag");
			}
			if (element=="Main-Game/boat") {
				gamePart = GamePart.harbour;
			}
			if (element=="Main-Game/profile") {
				gamePart = GamePart.profile;
				Console.WriteLine("clicked Profile");

			}
			if (element=="Main-Game/wastePlant") {
				gamePart = GamePart.waste;
			}
			if (element=="Main-Game/settings") {
				gamePart = GamePart.BackMenu;
				Console.WriteLine("clicked Settings");

			}
			if (element=="Main-Game/barracks") {
				gamePart = GamePart.barracks;
			}
			if (element=="Main-Menu/done") {
				gamePart = GamePart.main;
			}
			if (element=="Main-Game/Foodtruck") {
				gamePart = GamePart.resto;
			}
			if (element=="Main-Game/farm") {
				gamePart = GamePart.farm;
			}
			if (element=="Back-Menu/close-button") {
				gamePart = GamePart.main;
			}
			if (element=="Back-Menu/main-menu") {
				gamePart = GamePart.mainMenu;
			}
			if (element=="Back-Menu/settings-button") {
				gamePart = GamePart.settings;
			}
		}

	}
}

