﻿using System.Collections.Generic;

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
	 class DrawResto
	{
		public enum Acties
		{
			main,
			Upgrade,
			GoFish,
			Exit

		}
		private Acties acties;

		public Acties State {
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
		public int RestoLevel {
			get;
			set;
		}


		private int hotchpotch = 26;
		private int fishpasta = 34;
		private int herbcake = 23;
		private int bbq = 6;

		private int simmerTrout = 28;
		private int friet = 6;
		private int calamares = 6;
		private int waffel=11;

		private int restolevel = 0;

		private GameObjects obj;
		List<GUIElement> resto = new List<GUIElement>();
		public List<BaseFood> food = new List<BaseFood>();

		private SpriteFont font;


		public DrawResto ()
		{
			resto.Add (new GUIElement ("Cross-Screen/Island-bg"));
			resto.Add (new GUIElement ("Resto/resto-bg"));

			resto.Add (new GUIElement ("Cross-Screen/upgrade-small"));
			resto.Add (new GUIElement ("Cross-Screen/X"));

			resto.Add (new GUIElement ("Resto/down"));
			resto.Add (new GUIElement ("Resto/up"));
			//links
			resto.Add (new GUIElement ("Resto/prepare-46points")); //hotchpotch
			resto.Add (new GUIElement ("Resto/preapare-60points-blue"));//fishpasta
			resto.Add (new GUIElement ("Resto/prepare-40pints-blue"));//herbcake
			resto.Add (new GUIElement ("Resto/prepare-10points-blue"));//bbq

			//rechts
			resto.Add (new GUIElement ("Resto/prepare-50points"));//simmerTrout
			resto.Add (new GUIElement ("Resto/prepare-10points-orange"));//friet
			resto.Add (new GUIElement ("Resto/prepare-10points-orange1"));//calamares
			resto.Add (new GUIElement ("Resto/prepare-40points-orange"));//waffel

			resto.Add (new GUIElement ("Resto/bar-speed"));
			resto.Add (new GUIElement ("Resto/bar-upgrade"));


		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in resto) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			resto.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			resto.Find (x => x.AssetName == "Resto/resto-bg").moveElement (65,25);

			resto.Find (x => x.AssetName == "Cross-Screen/upgrade-small").moveElement (830, 820);
			resto.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

			resto.Find (x => x.AssetName == "Resto/down").moveElement (1735, 625);
			resto.Find (x => x.AssetName == "Resto/up").moveElement (1735,260 );

			resto.Find (x => x.AssetName == "Resto/prepare-46points").moveElement (645, 260);
			resto.Find (x => x.AssetName == "Resto/preapare-60points-blue").moveElement (645, 380);
			resto.Find (x => x.AssetName == "Resto/prepare-40pints-blue").moveElement (645, 500);
			resto.Find (x => x.AssetName == "Resto/prepare-10points-blue").moveElement (645, 620);

			resto.Find (x => x.AssetName == "Resto/prepare-50points").moveElement(1475, 260) ;
			resto.Find (x => x.AssetName == "Resto/prepare-10points-orange").moveElement(1475, 380) ;
			resto.Find (x => x.AssetName == "Resto/prepare-10points-orange1").moveElement(1475, 500) ;
			resto.Find (x => x.AssetName == "Resto/prepare-40points-orange").moveElement(1475, 620) ;


			resto.Find (x => x.AssetName == "Resto/bar-speed").moveElement (198, 874);
			resto.Find (x => x.AssetName == "Resto/bar-upgrade").moveElement (1138, 875);


		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in resto) {
				element.Update (gameObjects);
			}
			obj = gameObjects;

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in resto) {
				element.Draw (spriteBatch);
			}
			spriteBatch.DrawString(font, hotchpotch.ToString(),new Vector2(213,317), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, fishpasta.ToString(),new Vector2(213,447), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, herbcake.ToString(),new Vector2(213,567), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, bbq.ToString(),new Vector2(213,687), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, simmerTrout.ToString(),new Vector2(1030,317), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, friet.ToString(),new Vector2(1030,447), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, calamares.ToString(),new Vector2(1030,567), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, waffel.ToString(),new Vector2(1030,687), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, restolevel.ToString(),new Vector2(1030,90), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);


		}
		public void OnClick(string element)
		{
			int next = 0;
			if (food.Count !=0) {
				next = food.ElementAt (food.Count-1).endTick;
			}
				
			if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}
			if (element== "Resto/prepare-46points") {//hotchpotch
				if (obj.Grains>=5 && obj.Vegies>=8&&obj.Meat>=10) {
					food.Add(new HotchPotch(RestoLevel,obj,next));
					Console.WriteLine ("//hotchpotch");
				}
			}
			if (element== "Resto/preapare-60points-blue") {//fishpasta
				if ((obj.Fish >= 15) && (obj.Vegies >= 5) && (obj.Grains >= 10)) {
					food.Add(new FishPasta(RestoLevel,obj,next));
					Console.WriteLine ("//fishpasta");

				}
			}
			if (element== "Resto/prepare-40pints-blue") {//herbcake
				if ((obj.Vegies >= 10) && (obj.Grains >= 10)) {
					Console.WriteLine ("//herbcake");
					food.Add (new HerbCake (RestoLevel, obj,next));
				}
			}
			if (element== "Resto/prepare-10points-blue") {//bbq
				if (obj.Meat >= 5) {
					Console.WriteLine ("//bbq");
					food.Add (new BBQ (RestoLevel, obj,next));
				}
			}
			if (element== "Resto/prepare-50points") {//simmerTrout
				if ((obj.Fish >= 15) && (obj.Vegies >= 10)) {
					Console.WriteLine ("simmerTrout x");
					food.Add(new SimmerTrout(RestoLevel, obj,next));
				}
			}
			if (element== "Resto/prepare-10points-orange") {//friet
				if (obj.Vegies>=5) {
					Console.WriteLine ("friet x");
					food.Add(new Frieten(RestoLevel, obj,next));

				}
			}
			if (element== "Resto/prepare-10points-orange1") {//calamares
				if (obj.Fish>=5) {
					Console.WriteLine ("calamares x");
					food.Add(new Calamares(RestoLevel, obj,next));
				}
			}
			if (element== "Resto/prepare-40points-orange") {//waffel
				if (obj.Grains>=5) {
					Console.WriteLine ("waffel x");
					food.Add(new Waffels(RestoLevel, obj,next));

				}
			}
				
		}
		public void Upgradelvl(GameObjects Presource)
		{
			//=130*Level
			if (Presource.Money>=(RestoLevel*130))
			{
				RestoLevel++;
				Presource.Money -= (RestoLevel * 130);
			}
		}

	}
}

