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

		public enum Acties
		{
			main,
			upgrade,
			vraag,
			error


		}
		private Acties acties;
		private Acties vragen;
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
		private int storage = 400;
		public int Storage {
			get
			{
				return storage;
			}
			set{
				storage=value;
			}
		}
		public int Marketlvl {
			get;
			set;
		}



		List<GUIElement>MarketScreen1 = new List<GUIElement>();
		List<GUIElement>MarketScreen2 = new List<GUIElement>();
		List<GUIElement>MarketScreen3 = new List<GUIElement>();
		List<GUIElement>Buttons = new List<GUIElement>();
		private Question2 quest = new Question2();
		private SpriteFont font;
		private int totalrecourc;
		private int aGrain=0;
		private int aFish=0;
		private int aVege=0;
		private int aMeat=0;
		private Drawerror error;

		public DrawMarket ()
		{
			error = new Drawerror ();

			MarketScreen1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			MarketScreen1.Add (new GUIElement ("Market/storage-bg"));
			MarketScreen1.Add (new GUIElement ("Cross-Screen/X"));

			MarketScreen1.Add (new GUIElement ("storage/grains_bar"));
			MarketScreen1.Add (new GUIElement ("storage/grain-sym"));

			MarketScreen1.Add (new GUIElement ("storage/Bar-vegie"));
			MarketScreen1.Add (new GUIElement ("storage/vege-sym"));

			MarketScreen1.Add (new GUIElement ("storage/Bar-fish"));
			MarketScreen1.Add (new GUIElement ("storage/fish-sym"));

			MarketScreen1.Add (new GUIElement ("storage/Bar-meat"));
			MarketScreen1.Add (new GUIElement ("storage/meat-sym"));


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

			MarketScreen3.Add (new GUIElement ("Market/bar"));
			MarketScreen3.Add (new GUIElement ("Market/bar-next"));

		
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");
			quest.LoadContent (content, gameObjects);
			if (quest.Vraag1==false) {
				vragen = Acties.vraag;
				gameObjects.cluster1 = false;

			}
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


			MarketScreen3.Find (x => x.AssetName == "Market/bar").moveElement(169,895);
			MarketScreen3.Find (x => x.AssetName == "Market/bar-next").moveElement(1233,895);

			error.LoadContent (content,gameObjects);

		}
		public void Update(GameObjects gameObjects)
		{	
			switch (vragen) {
			case Acties.vraag:
				quest.Update (gameObjects);
				if (quest.Vraag1) {
					vragen = Acties.main;
					screen = Screens.Screen1;
					gameObjects.cluster2 = true;
				}
				break;
			case Acties.main:
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
						if (element.AssetName=="Market/bar") {
							element.drawParial (gameObjects.TotalRecource, storage);
							totalrecourc = gameObjects.TotalRecource;

						}
						if (element.AssetName=="Market/bar-next") {
							element.drawParial (Marketlvl+1,16);
						}

					}
					if (acties==Acties.upgrade) {
						Upgradelvl (gameObjects);
					}
					if (acties == Acties.error) {
						error.Update (gameObjects);
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
				break;
			default:
				break;
			}




		}
		public void Draw(SpriteBatch spriteBatch , GameObjects obj)
		{
			int x=0;
			switch (vragen) {
			case Acties.vraag:
				quest.Draw (spriteBatch);
				break;
			case Acties.main:
				switch (screen) {
				case Screens.Screen1:
					foreach (GUIElement element in MarketScreen1) {
						if (element.AssetName == "storage/grains_bar" || element.AssetName == "storage/Bar-vegie" || element.AssetName == "storage/Bar-fish" || element.AssetName == "storage/Bar-meat"||
							element.AssetName == "storage/grain-sym"||element.AssetName == "storage/vege-sym"||element.AssetName == "storage/fish-sym"||element.AssetName == "storage/meat-sym") {

							if (element.AssetName == "storage/grains_bar") {
								Rectangle rect = element.returnRect (obj.Grains, storage);
								rect.X = 140;
								rect.Y = 883;
								element.Draw (spriteBatch, rect);
								x = 140+rect.Width;
							}
							if (element.AssetName == "storage/grain-sym") { //symbol
								Rectangle rect = element.guiRect;
								rect.X = x;
								rect.Y = 760;
								element.Draw (spriteBatch, rect);
								spriteBatch.DrawString(font, obj.Grains.ToString(),new Vector2(rect.X-20,770), Color.Black,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

							}
							if (element.AssetName == "storage/Bar-vegie") {
								Rectangle rect = element.returnRect (obj.Vegies, storage);
								rect.X = x;
								rect.Y = 883;
								element.Draw (spriteBatch, rect);
								x += rect.Width;

							}
							if (element.AssetName == "storage/vege-sym") {//symbol
								Rectangle rect = element.guiRect;
								rect.X = x;
								rect.Y = 760;
								element.Draw (spriteBatch, rect);
								spriteBatch.DrawString(font, obj.Vegies.ToString(),new Vector2(rect.X-20,770), Color.Black,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

							}
							if (element.AssetName == "storage/Bar-fish") {
								Rectangle rect = element.returnRect (obj.Fish, storage);
								rect.X = x;
								rect.Y = 883;
								element.Draw (spriteBatch, rect);
								x += rect.Width;
							}
							if (element.AssetName == "storage/fish-sym") {//symbol
								Rectangle rect = element.guiRect;
								rect.X = x;
								rect.Y = 760;
								element.Draw (spriteBatch, rect);
								spriteBatch.DrawString(font, obj.Fish.ToString(),new Vector2(rect.X-20,770), Color.Black,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

							}
							if (element.AssetName == "storage/Bar-meat") {
								Rectangle rect = element.returnRect (obj.Meat, storage);
								rect.X = x;
								rect.Y = 883;
								element.Draw (spriteBatch, rect);
								x += rect.Width;
							}
							if (element.AssetName == "storage/meat-sym") {//symbol
								Rectangle rect = element.guiRect;
								rect.X = x;
								rect.Y = 760;
								element.Draw (spriteBatch, rect);
								spriteBatch.DrawString(font, obj.Meat.ToString(),new Vector2(rect.X-20,770), Color.Black,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

							}
						} else {
							element.Draw (spriteBatch);

						}

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
					if (acties == Acties.error) {
						error.Draw (spriteBatch, Drawerror.Acties.market);
					}


					spriteBatch.DrawString(font, "Current "+ totalrecourc.ToString()+"/"+storage.ToString(),new Vector2(174,898), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
					spriteBatch.DrawString(font, "next Level: "+(Marketlvl+2).ToString(),new Vector2(1237,898), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
					spriteBatch.DrawString(font, ((Marketlvl+1)*80).ToString(),new Vector2(1080,950), Color.White,0,new Vector2(0,0),3f,SpriteEffects.None,0f);

					break;
				default:
					break;
				}

				break;
			default:
				break;
			}


		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X" && acties==Acties.error) {
				acties = Acties.main;
			}
			else if (element== "Cross-Screen/X") {
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
				acties = Acties.upgrade;
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
		public void Upgradelvl(GameObjects Presource)
		{
			//=90*Level
			if (Presource.Money >= (Marketlvl+1 * 90))
			{
				Marketlvl++;
				Presource.Money -= ((Marketlvl+1) * 80);
				storage = (int)(400 * Math.Pow ((1 + 0.26), Marketlvl));
			} 
			else {
				acties = Acties.error;

			}

		}
	}
}

