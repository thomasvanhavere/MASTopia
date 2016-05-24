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
		private SpriteFont font;

		private int aGrain=0;
		private int aFish=0;
		private int aVege=0;
		private int aMeat=0;

		public DrawMarket ()
		{
			MarketScreen1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen1.Add (new GUIElement ("Market/storage-bg"));
			MarketScreen1.Add (new GUIElement ("Cross-Screen/X"));

			MarketScreen2.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/buy-sell-bg"));
			MarketScreen2.Add (new GUIElement ("Cross-Screen/X"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/buy-button"));
			MarketScreen2.Add (new GUIElement ("Market/Buy/sell-button"));

		

			Buttons.Add (new GUIElement ("Market/Buy/plus-fish"));
			Buttons.Add (new GUIElement ("Market/Buy/plus-meat"));
			Buttons.Add (new GUIElement ("Market/Buy/plus-veg"));
			Buttons.Add (new GUIElement ("Market/Buy/plus-grain"));

			Buttons.Add (new GUIElement ("Market/Buy/minus-fish"));
			Buttons.Add (new GUIElement ("Market/Buy/minus-meat"));
			Buttons.Add (new GUIElement ("Market/Buy/minus-veg"));
			Buttons.Add (new GUIElement ("Market/Buy/minus-grain"));


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
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in MarketScreen1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen1.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen1.Find (x => x.AssetName == "Market/storage-bg").moveElement(65,25);
			MarketScreen1.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);


			foreach (GUIElement element in MarketScreen2) {
				
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			MarketScreen2.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/buy-sell-bg").moveElement(65,25);
			MarketScreen2.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/buy-button").moveElement (1575,780 );
			MarketScreen2.Find (x => x.AssetName == "Market/Buy/sell-button").moveElement (1575,885 );


			foreach (GUIElement element in Buttons) {

				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			Buttons.Find (x => x.AssetName == "Market/Buy/plus-grain").moveElement (370,750 );

			Buttons.Find (x => x.AssetName == "Market/Buy/plus-fish").moveElement (740,750 );

			Buttons.Find (x => x.AssetName == "Market/Buy/plus-veg").moveElement (1110,750 );

			Buttons.Find (x => x.AssetName == "Market/Buy/plus-meat").moveElement (1480,750 );

			Buttons.Find (x => x.AssetName == "Market/Buy/minus-grain").moveElement (370,900 );
			Buttons.Find (x => x.AssetName == "Market/Buy/minus-fish").moveElement (740,900 );
			Buttons.Find (x => x.AssetName == "Market/Buy/minus-veg").moveElement (1110,900 );
			Buttons.Find (x => x.AssetName == "Market/Buy/minus-meat").moveElement (1480,900 );

			Buttons.ElementAt (8).moveElement (370, 815);
			Buttons.ElementAt (9).moveElement (740, 815);
			Buttons.ElementAt (10).moveElement (1110, 815);
			Buttons.ElementAt (11).moveElement (1480, 815);


			foreach (GUIElement element in MarketScreen3) {
				
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;

			}
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			MarketScreen3.Find (x => x.AssetName == "Market/upgrade-screen").moveElement(65,25);
			MarketScreen3.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);
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
			if (screen == Screens.Screen1 || screen == Screens.Screen2 || screen == Screens.Screen3) {
				if (gameObjects.touchInput.swippedLeft) {
					if (screen == Screens.Screen1) {
						screen = Screens.Screen2;
					} else if (screen == Screens.Screen2) {
						screen = Screens.Screen3;
					}
				}
				if (gameObjects.touchInput.swippedRight) {
					if (screen == Screens.Screen3) {
						screen = Screens.Screen2;
					} else if (screen == Screens.Screen2) {
						screen = Screens.Screen1;
					}
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
				spriteBatch.DrawString(font, aGrain.ToString(),new Vector2(385,818), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, aFish.ToString(),new Vector2(755,818), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, aVege.ToString(),new Vector2(1125,818), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, aMeat.ToString(),new Vector2(1495,818), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);


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

			if (element =="Market/Buy/buy-button") {
				Console.WriteLine ("Pressed Buy");
			}
			if (element =="Market/Buy/sell-button") {
				Console.WriteLine ("Pressed sell");
			}
			if (element =="Cross-Screen/upgrade") {
				Console.WriteLine ("Pressed upgrade @ Market");
			}
			if (element=="Market/Buy/plus-fish" ) {
				if (aFish<100) {
					aFish++;
				}
			}
			if (element=="Market/Buy/plus-meat" ) {
				if (aMeat<100) {
					aMeat++;
				}
			}
			if (element=="Market/Buy/plus-veg" ) {
				if (aVege<100) {
					aVege++;
				}
			}
			if (element=="Market/Buy/plus-grain" ) {
				if (aGrain<100) {
					aGrain++;
				}
			}
			if (element=="Market/Buy/minus-fish" ) {
				if (aFish>0) {
					aFish--;
				}
			}
			if (element=="Market/Buy/minus-meat" ) {
				if (aMeat>0) {
					aMeat--;
				}
			}
			if (element=="Market/Buy/minus-veg" ) {
				if (aVege>0) {
					aVege--;
				}
			}
			if (element=="Market/Buy/minus-grain" ) {
				if (aGrain>0) {
					aGrain--;
				}
			}

		}
	}
}

