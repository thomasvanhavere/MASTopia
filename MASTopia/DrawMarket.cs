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
	public class DrawMarket
	{
		public enum Screens
		{
			Screen1,
			Screen2,
			Screen3,
			Exit
		}
		private Screens screen;
		public Screens scherm {
			get
			{
				return screen;
			}
			set{
				screen=value;
			}
		}
		List<GUIElement>MarketScreen1 = new List<GUIElement>();
		List<GUIElement>MarketScreen2 = new List<GUIElement>();
		List<GUIElement>MarketScreen3 = new List<GUIElement>();

		public DrawMarket ()
		{
		MarketScreen1.Add (new GUIElement ("Main-Game/island"));
		MarketScreen1.Add (new GUIElement ("Market/storage/storage-screen"));
		MarketScreen1.Add (new GUIElement ("Cross-Screen/X"));

		MarketScreen2.Add (new GUIElement ("Main-Game/island"));
		MarketScreen2.Add (new GUIElement ("Market/Buy/buy-sell-bg"));
		MarketScreen2.Add (new GUIElement ("Cross-Screen/X"));


		MarketScreen3.Add (new GUIElement ("Main-Game/island"));
		MarketScreen3.Add (new GUIElement ("Market/upgrade-screen"));
		MarketScreen3.Add (new GUIElement ("Cross-Screen/X"));

		
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in MarketScreen1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen1.Find (x => x.AssetName == "Main-Game/island").PutBg ();
			MarketScreen1.Find (x => x.AssetName == "Market/storage/storage-screen").moveElement(65,25);
			MarketScreen1.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);

			foreach (GUIElement element in MarketScreen2) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen2.Find (x => x.AssetName == "Main-Game/island").PutBg ();
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/buy-sell-bg").moveElement(65,25);
			MarketScreen2.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);

			foreach (GUIElement element in MarketScreen3) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen3.Find (x => x.AssetName == "Main-Game/island").PutBg ();
			MarketScreen3.Find (x => x.AssetName == "Market/upgrade-screen").moveElement(65,25);
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);

		}
		public void Update(GameObjects gameObjects)
		{	
			switch (screen) {
			case Screens.Screen1:
				foreach (GUIElement element in MarketScreen1) {
					element.Update (gameObjects);
				}
				break;
			case Screens.Screen2:
				foreach (GUIElement element in MarketScreen2) {
					element.Update (gameObjects);
				}
				break;
				case Screens.Screen3:
				foreach (GUIElement element in MarketScreen3) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}
			if (gameObjects.touchInput.swippedLeft) {
				if (screen==Screens.Screen1) {
					screen = Screens.Screen2;
				}
				else if(screen==Screens.Screen2)
				{
					screen = Screens.Screen3;
				}
			}
			if (gameObjects.touchInput.swippedRight) {
				if (screen==Screens.Screen3) {
					screen = Screens.Screen2;
				}
				else if(screen==Screens.Screen2)
				{
					screen = Screens.Screen1;
				}
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			switch (screen) {
			case Screens.Screen1:
				foreach (GUIElement element in MarketScreen1) {
					element.Draw (spriteBatch);
				}
				break;
			case Screens.Screen2:
				foreach (GUIElement element in MarketScreen2) {
					element.Draw (spriteBatch);
				}
				break;
			case Screens.Screen3:
				foreach (GUIElement element in MarketScreen3) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}


		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				screen = Screens.Exit;
				Console.WriteLine ("Exit X @ market");
			}

		}
	}
}

