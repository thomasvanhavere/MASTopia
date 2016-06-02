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
	public class DrawBarracks
	{
		public enum screens
		{
			Screen1,
			Screen2,
			Attack,
			Defense,
			Target,
			DetailBunny,
			Exit
		}

		private screens screen;
		public screens scherm
		{
			get{
				return screen;
			}
			set{
				screen = value;
			}
		}
		public enum Acties
		{
			upgrade,
			Attack,
			Defense,
			Enemes

		}
		private Acties acties;

		public Acties State
		{
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
		public int barrackLevel {
			get;
			set;
		}
		public int troops {
			get;
			set;
		}

		List<GUIElement> Screen1 = new List<GUIElement>();
		List<GUIElement> Screen2 = new List<GUIElement>();
		List<GUIElement> Attack = new List<GUIElement>();
		List<GUIElement> detailBunny = new List<GUIElement>();

		private SpriteFont font;

		public DrawBarracks ()
		{
			Screen1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Screen1.Add (new GUIElement ("barracks/barrack-bg"));
			Screen1.Add (new GUIElement ("Cross-Screen/upgrade"));
			Screen1.Add (new GUIElement ("Cross-Screen/X"));

			Screen1.Add (new GUIElement ("barracks/bar-nextspeed"));
			Screen1.Add (new GUIElement ("barracks/bar-nexttroops"));
			Screen1.Add (new GUIElement ("barracks/bar-troops"));
			Screen1.Add (new GUIElement ("barracks/bar-speed"));

			Screen2.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Screen2.Add (new GUIElement ("barracks/barracks-bg2"));
			Screen2.Add (new GUIElement ("Cross-Screen/X"));
			Screen2.Add (new GUIElement ("barracks/attack"));
			Screen2.Add (new GUIElement ("barracks/target"));
			Screen2.Add (new GUIElement ("barracks/Defense"));

			Attack.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Attack.Add (new GUIElement ("Attack/attack-bg"));
			Attack.Add (new GUIElement ("Attack/evil-bunny"));
			Attack.Add (new GUIElement ("Attack/kamikazee-rats"));
			Attack.Add (new GUIElement ("Attack/nija-pig"));
			Attack.Add (new GUIElement ("Attack/nucleair-snail"));
			Attack.Add (new GUIElement ("Cross-Screen/X"));
		
			detailBunny.Add (new GUIElement("Cross-Screen/Island-bg"));
			detailBunny.Add (new GUIElement ("barracks/Detail/bg-detail"));
			detailBunny.Add (new GUIElement ("barracks/Detail/buy"));
			detailBunny.Add (new GUIElement ("barracks/Detail/min"));
			detailBunny.Add (new GUIElement ("barracks/Detail/plus"));
			detailBunny.Add (new GUIElement ("Cross-Screen/X"));

		}

		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in Screen1) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}
			Screen1.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Screen1.Find(x=>x.AssetName=="barracks/barrack-bg").PutBg();
			Screen1.Find(x=>x.AssetName=="Cross-Screen/upgrade").moveElement(835,750);
			Screen1.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			Screen1.Find(x=>x.AssetName=="barracks/bar-troops").moveElement(238,837);
			Screen1.Find(x=>x.AssetName=="barracks/bar-speed").moveElement(238,904);
			Screen1.Find(x=>x.AssetName=="barracks/bar-nexttroops").moveElement(1205,837);
			Screen1.Find(x=>x.AssetName=="barracks/bar-nextspeed").moveElement(1205,904);

			foreach (GUIElement element in Screen2) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			Screen2.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Screen2.Find(x=>x.AssetName=="barracks/barracks-bg2").PutBg();

			Screen2.Find(x=>x.AssetName=="barracks/attack").moveElement(150,740);
			Screen2.Find(x=>x.AssetName=="barracks/target").moveElement(660,740);
			Screen2.Find(x=>x.AssetName=="barracks/Defense").moveElement(1230,740);
			Screen2.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			foreach (GUIElement element in Attack) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}
			Attack.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Attack.Find(x=>x.AssetName=="Attack/evil-bunny").moveElement(140,200);
			Attack.Find(x=>x.AssetName=="Attack/kamikazee-rats").moveElement(540,250);
			Attack.Find(x=>x.AssetName=="Attack/nija-pig").moveElement(940,300);
			Attack.Find(x=>x.AssetName=="Attack/nucleair-snail").moveElement(1340,300);
			Attack.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			foreach (GUIElement element in detailBunny) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}
			detailBunny.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			detailBunny.Find(x=>x.AssetName=="barracks/Detail/buy").moveElement(1540,750);
			detailBunny.Find(x=>x.AssetName=="barracks/Detail/min").moveElement(1420,910);
			detailBunny.Find(x=>x.AssetName=="barracks/Detail/plus").moveElement(1420,750);

			detailBunny.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);


		}
		public void Update(GameObjects gameObjects)
		{
			
			switch (screen) {
			case screens.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Update (gameObjects);

				}
				break;

			case screens.Screen2:
				foreach (GUIElement element in Screen2) {
					element.Update (gameObjects);
				}
			
				break;
			case screens.Attack:
				foreach (GUIElement element in Attack) {
					element.Update (gameObjects);
				}
				break;
			case screens.DetailBunny:
				foreach (GUIElement element in detailBunny) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}
			if (screen == screens.Screen2 || screen == screens.Screen1) {	
				if (gameObjects.touchInput.swippedLeft) {
					screen = screens.Screen2;
				}
				if(gameObjects.touchInput.swippedRight){
					screen = screens.Screen1;
				}
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{			
			switch (screen) {
			case screens.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Draw (spriteBatch);

				}
				spriteBatch.DrawString(font, "Amount of Troops : 129",new Vector2(250,842), Color.White,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "speed : 20 min",new Vector2(250,907), Color.White,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Amount of Troops : 159",new Vector2(1215,842), Color.White,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font,"Speed : 15 min",new Vector2(1215,907), Color.White,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, ((barrackLevel+1)*200).ToString(),new Vector2(1020,950), Color.White,0,new Vector2(0,0),3f,SpriteEffects.None,0f);

				break;
			case screens.Screen2:
				foreach (GUIElement element in Screen2) {
							element.Draw (spriteBatch);
				}

			break;
			case screens.Attack:
				foreach (GUIElement element in Attack) {
					element.Draw (spriteBatch);
				}

				break;
			case screens.DetailBunny:
				foreach (GUIElement element in detailBunny) {
					element.Draw (spriteBatch);
				}

				break;
			default:
				break;
			}
			spriteBatch.DrawString(font, barrackLevel.ToString(),new Vector2(1030,90), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

		}


		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X" && screen==screens.Attack) {
				screen = screens.Screen2;
				Console.WriteLine ("Exit x @ attack");
			}
			else if (element== "Cross-Screen/X" && screen==screens.DetailBunny) {
				screen = screens.Attack;
			}
			else if (element== "Cross-Screen/X") {
				screen = screens.Exit;
				Console.WriteLine ("Exit x");
			}

			if (element== "Cross-Screen/upgrade") {
				Console.WriteLine ("Upgrade @ Barrack");
			}
			if (element== "barracks/attack") {
				Console.WriteLine ("Attack !!!");
				screen = screens.Attack;
			}

			if (element=="barracks/target" ) {
				Console.WriteLine ("Target !!!");
			}
			if (element== "barracks/Defense") {
				Console.WriteLine ("Defense");
			}
			if (element== "Attack/evil-bunny") {
				screen = screens.DetailBunny;
			}

		}
	}
}

