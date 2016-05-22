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
		List<GUIElement>Buttons = new List<GUIElement>();


		public DrawMarket ()
		{
			MarketScreen1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen1.Add (new GUIElement ("Market/storage-bg"));
			MarketScreen1.Add (new GUIElement ("Cross-Screen/X"));
			
//			MarketScreen1.Add(new GUIElement ("Market/storage/grains-curve-l"));
//			MarketScreen1.Add(new GUIElement ("Market/storage/grains-square"));
//			MarketScreen1.Add(new GUIElement ("Market/storage/symbol grains"));
//
//			MarketScreen1.Add(new GUIElement ("Market/storage/vegetables-square"));
//			MarketScreen1.Add(new GUIElement ("Market/storage/symbol vegetables"));
//
//			MarketScreen1.Add(new GUIElement ("Market/storage/fish-square"));
//			MarketScreen1.Add(new GUIElement ("Market/storage/fish-symbol"));
//
//			MarketScreen1.Add(new GUIElement ("Market/storage/meat-square"));
//			MarketScreen1.Add(new GUIElement ("Market/storage/meat-symbol"));


			MarketScreen2.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/buy-sell-bg"));
			MarketScreen2.Add (new GUIElement ("Cross-Screen/X"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/buy-button"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/sell-button"));

		
			for (int i = 0; i < 4; i++) {
				Buttons.Add (new GUIElement ("Market/Buy/plus"));
			}
			for (int J = 0; J < 4; J++) {
				Buttons.Add (new GUIElement ("Market/Buy/minus"));
			}
			for (int i = 0; i < 4; i++) {
				Buttons.Add (new GUIElement ("Market/Buy/dial-button"));

			}

			MarketScreen3.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen3.Add (new GUIElement ("Market/upgrade-screen"));
			MarketScreen3.Add (new GUIElement ("Cross-Screen/upgrade"));
			MarketScreen3.Add (new GUIElement ("Cross-Screen/X"));

		
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in MarketScreen1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen1.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen1.Find (x => x.AssetName == "Market/storage-bg").moveElement(65,25);

//			MarketScreen1.Find (x => x.AssetName == "Market/storage/grains-curve-l").moveElement (140, 884);
//			MarketScreen1.Find (x => x.AssetName == "Market/storage/symbol grains").moveElement (160, 800);
//			MarketScreen1.Find (x => x.AssetName == "Market/storage/grains-square").moveElement (150, 884);
			MarketScreen1.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);


			foreach (GUIElement element in MarketScreen2) {
				
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen2.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/buy-sell-bg").moveElement(65,25);
			MarketScreen2.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/buy-button").moveElement (1575,780 );
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/sell-button").moveElement (1575,885 );


			int X = 370;
			int Y = 750;
			int counter = 0;
			foreach (GUIElement element in Buttons) {

				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
				if (counter==4) {
					X = 370;
					Y = 910;
				}
				if (counter==8) {
					Y = 820;
					X = 370;
				}
				element.moveElement (X, Y);
				X+=360;
				element.Counter = counter;
				counter++;

			}

			foreach (GUIElement element in MarketScreen3) {
				
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;

			}
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen3.Find (x => x.AssetName == "Market/upgrade-screen").moveElement(65,25);
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (830, 735);

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
				foreach (GUIElement element in Buttons) {
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
				foreach (GUIElement element in Buttons) {
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
			if (element=="Market/Buy/plus" ) {
				Console.WriteLine ("Plus");
			}
			if (element =="Market/Buy/buy-button") {
				Console.WriteLine ("Pressed Buy");
			}
			if (element =="Market/Buy/sell-button") {
				Console.WriteLine ("Pressed sell");
			}
			if (element =="Cross-Screen/upgrade") {
				Console.WriteLine ("Pressed upgrade @ Market");
			}
		}
	}
}

