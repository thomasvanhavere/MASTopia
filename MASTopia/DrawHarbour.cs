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
	public class DrawHarbour
	{
		public enum Acties
		{
			main,
			Upgrade,
			GoFish,
			error,
			vraag,
			Exit

		}
		private Acties acties;
		private Acties vragen;
		public Acties State {
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
		private int amountOfShips=1;
		private int shipCapacity=15;
		public int AmountOfShips
		{
			get { return amountOfShips; }
			set { amountOfShips = value; }
		}
		public int ShipCapacity {
			get { return shipCapacity; }
			set { shipCapacity = value; }
		}
		public int HarbourLevel { get; set; }
		private Drawerror error;

		List<GUIElement> harbour = new List<GUIElement>();
		private SpriteFont font;
		private Questions quest;
		public DrawHarbour ()
		{
			error = new Drawerror ();

			harbour.Add (new GUIElement ("Cross-Screen/Island-bg"));
			harbour.Add (new GUIElement ("Boat/boat-screen"));
			harbour.Add (new GUIElement ("Boat/go-fishing"));
			harbour.Add (new GUIElement ("Cross-Screen/upgrade-small"));
			harbour.Add (new GUIElement ("Cross-Screen/X"));

			harbour.Add (new GUIElement ("Boat/bar-nextspeed"));
			harbour.Add (new GUIElement ("Boat/bar-nextcap"));
			harbour.Add (new GUIElement ("Boat/bar-cap"));
			harbour.Add (new GUIElement ("Boat/bar-speed"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");
			if (gameObjects.cluster1==false) {
				vragen = Acties.vraag;
				gameObjects.cluster1 = false;
				quest = new Questions ();
				quest.LoadContent (content, gameObjects);

			}
			foreach (GUIElement element in harbour) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			harbour.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			harbour.Find (x => x.AssetName == "Boat/boat-screen").moveElement(65,25);
			harbour.Find (x => x.AssetName == "Boat/go-fishing").moveElement (150, 800);
			harbour.Find (x => x.AssetName == "Cross-Screen/upgrade-small").moveElement (1610, 805);
			harbour.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

			harbour.Find (x => x.AssetName == "Boat/bar-speed").moveElement(407,842);
			harbour.Find (x => x.AssetName == "Boat/bar-cap").moveElement(407,910);
			harbour.Find (x => x.AssetName == "Boat/bar-nextspeed").moveElement(1011,842);
			harbour.Find (x => x.AssetName == "Boat/bar-nextcap").moveElement(1011,910);
			error.LoadContent (content,gameObjects);


		}
		public void Update(GameObjects gameObjects)
		{			
			switch (vragen) {
			case Acties.vraag:
				quest.Update (gameObjects);
				if (quest.Vraag1) {
					vragen = Acties.main;
					gameObjects.cluster1 = true;
				}
				break;
			case Acties.main :
				foreach (GUIElement element in harbour) {
					element.Update (gameObjects);
				}
				if (acties==Acties.Upgrade) {
					acties = Acties.main;
					Upgradelvl (gameObjects);
				}
				if (acties == Acties.error) {
					error.Update (gameObjects);
				}
				break;
			default:
				break;
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			switch (vragen) {
			case Acties.vraag:
				quest.Draw (spriteBatch);
				break;
			case Acties.main:
				foreach (GUIElement element in harbour) {
					element.Draw (spriteBatch);
					if (element.AssetName=="Boat/bar-speed") {
						element.drawParial (HarbourLevel+1,16);
					}
					if (element.AssetName=="Boat/bar-nextspeed") {
						element.drawParial (HarbourLevel+2,16);
					}
					if (element.AssetName=="Boat/bar-cap") {
						element.drawParial (shipCapacity,45);
					}
					if (element.AssetName=="Boat/bar-nextcap") {
						element.drawParial (shipCapacity+2,45);
					}
				}
				spriteBatch.DrawString(font, "Speed: "+ ((shipCapacity)/2).ToString()+" Per Min" ,new Vector2(415,838), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Speed: "+ ((shipCapacity+2)/2).ToString()+" Per Min" ,new Vector2(1020,838), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Capacity: "+shipCapacity.ToString(),new Vector2(415,915), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Capacity: "+(shipCapacity+2).ToString(),new Vector2(1020,915), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);

				spriteBatch.DrawString(font, HarbourLevel.ToString(),new Vector2(1000,80), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, ((HarbourLevel+1)*90).ToString(),new Vector2(1780,950), Color.Black,0,new Vector2(0,0),3f,SpriteEffects.None,0f);
				if (acties == Acties.error) {
					error.Draw (spriteBatch, Drawerror.Acties.harbour);
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
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}
			if (element== "Boat/go-fishing") {
				Console.WriteLine ("go-fishing");
			}
			if (element== "Cross-Screen/upgrade-small") {
				acties = Acties.Upgrade;
				Console.WriteLine ("Upgrade @ Harbour");
			}

		}

		public void Upgradelvl(GameObjects Presource)
		{
			//=90*Level
			if (Presource.Money >= ((HarbourLevel+1) * 90))
			{
				Presource.Money -=((HarbourLevel+1) * 90);
				shipCapacity += 2;
				HarbourLevel++;

			} else {
				acties = Acties.error;

			}

		}
	}
}

