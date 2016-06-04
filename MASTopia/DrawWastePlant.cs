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
	public class DrawWastePlant
	{
		public enum Acties
		{
			main,
			Upgrade,
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
		public int Biowaste {
			get;
			set;
		}
		public int Chemwaste {
			get;
			set;
		}
		public int wastelevel {
			get;
			set;
		}
		private int maxChem;
		private int maxBio;
		List<GUIElement> waste = new List<GUIElement>();
		private Drawerror error;
		private SpriteFont font;
		private question4 quest = new question4();

		public DrawWastePlant ()
		{
			error = new Drawerror ();

			waste.Add (new GUIElement ("Cross-Screen/Island-bg"));
			waste.Add (new GUIElement ("WastePlant/wastePlant-bg"));
			waste.Add (new GUIElement ("Cross-Screen/upgrade"));
			waste.Add (new GUIElement ("Cross-Screen/X"));

			waste.Add (new GUIElement ("WastePlant/bar-bio"));
			waste.Add (new GUIElement ("WastePlant/bar-cap"));
			waste.Add (new GUIElement ("WastePlant/bar-chem"));
			waste.Add (new GUIElement ("WastePlant/bar-nextcap"));
			waste.Add (new GUIElement ("WastePlant/bar-nextratio"));
			waste.Add (new GUIElement ("WastePlant/bar-nextspeed"));
			waste.Add (new GUIElement ("WastePlant/bar-ratio"));
			waste.Add (new GUIElement ("WastePlant/bar-speed"));


		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");
			error.LoadContent (content,gameObjects);
			quest.LoadContent (content, gameObjects);
			if (quest.Vraag1==false) {
				vragen = Acties.vraag;
				gameObjects.cluster4 = false;

			}
			foreach (GUIElement element in waste) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			waste.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			waste.Find (x => x.AssetName == "WastePlant/wastePlant-bg").moveElement (65,25);

			waste.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (135, 750);
			waste.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

			waste.Find (x => x.AssetName == "WastePlant/bar-bio").moveElement (120,592);
			waste.Find (x => x.AssetName == "WastePlant/bar-chem").moveElement (1223,591);

			waste.Find (x => x.AssetName == "WastePlant/bar-speed").moveElement (565,737);
			waste.Find (x => x.AssetName == "WastePlant/bar-cap").moveElement (565,823);
			waste.Find (x => x.AssetName == "WastePlant/bar-ratio").moveElement (565,904);

			waste.Find (x => x.AssetName == "WastePlant/bar-nextspeed").moveElement (1264,737);
			waste.Find (x => x.AssetName == "WastePlant/bar-nextcap").moveElement (1264,823);
			waste.Find (x => x.AssetName == "WastePlant/bar-nextratio").moveElement (1264,904);


		}
		public void Update(GameObjects gameObjects)
		{		
			switch (vragen) {
			case Acties.vraag:
				quest.Update (gameObjects);
				if (quest.Vraag1) {
					vragen = Acties.main;
					gameObjects.cluster4 = true;
				}
				break;
			case Acties.main:
				maxBio= (80*gameObjects.amountTiles);
				maxChem = (70 * gameObjects.amountTiles);
				foreach (GUIElement element in waste) {
					element.Update (gameObjects);
					if (element.AssetName=="WastePlant/bar-bio") {
						element.drawParial (gameObjects.waste,maxBio);
					}
					if (element.AssetName=="WastePlant/bar-chem") {
						element.drawParial (gameObjects.Chemwaste,(70*gameObjects.amountTiles));
					}
					if (element.AssetName=="WastePlant/bar-cap") {
						element.drawParial (gameObjects.Chemwaste+gameObjects.waste,(maxBio+maxChem));
					}
					if (element.AssetName=="WastePlant/bar-nextcap") {
						element.drawParial (gameObjects.Chemwaste+gameObjects.waste,(maxBio+160+maxChem+160));
					}
					if (element.AssetName=="WastePlant/bar-ratio") {
						element.drawParial (gameObjects.Chemwaste,gameObjects.waste);
					}
					if (element.AssetName=="WastePlant/bar-nextratio") {
						element.drawParial (gameObjects.Chemwaste,gameObjects.waste);
					}

					if (element.AssetName=="WastePlant/bar-speed") {
						element.drawParial (wastelevel+1,16);
					}
					if (element.AssetName=="WastePlant/bar-nextspeed") {
						element.drawParial (wastelevel+2,16);
					}
				}
				if (acties==Acties.Upgrade) {
					acties = Acties.main;
					Upgradelvl (gameObjects);
				}
				if (acties == Acties.error) {
					error.Update (gameObjects);
				}
				Chemwaste = gameObjects.Chemwaste;
				Biowaste = gameObjects.waste;
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
				foreach (GUIElement element in waste) {
					element.Draw (spriteBatch);
				}
				spriteBatch.DrawString(font, (80*(wastelevel+1)).ToString(),new Vector2(360,950), Color.Black,0,new Vector2(0,0),2f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, wastelevel.ToString(),new Vector2(1000,84), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);

				spriteBatch.DrawString(font, "Biochemical W.: "+Biowaste.ToString() ,new Vector2(128,595), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Chemical W.: " +Chemwaste.ToString() ,new Vector2(1231,595), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);


				spriteBatch.DrawString(font, "Speed: " +((wastelevel+1)*100).ToString()+"L/H" ,new Vector2(575,740), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Capacity: " +(Biowaste+Chemwaste).ToString()+"/"+(maxBio+maxChem).ToString(),new Vector2(575,826), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "BW/CW: "+ (Biowaste).ToString()+"/"+(Chemwaste).ToString() ,new Vector2(575,907), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);

				spriteBatch.DrawString(font, "Speed: " +((wastelevel+2)*100).ToString()+"L/H",new Vector2(1275,740), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "Capacity: "+(Biowaste+Chemwaste).ToString()+"/"+(maxBio+maxChem+320).ToString() ,new Vector2(1275,826), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
				spriteBatch.DrawString(font, "CW/BW:"+ Chemwaste.ToString()+ "/" +Biowaste.ToString()  ,new Vector2(1275,907), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);

				if (acties == Acties.error) {
					error.Draw (spriteBatch, Drawerror.Acties.waste);
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
			if (element== "Cross-Screen/upgrade") {
				acties = Acties.Upgrade;			}

		}
		public void Upgradelvl(GameObjects Presource)
		{
			//=100*Level
			int next = (((80*(wastelevel+1))*2)/10);
				if (Presource.Money >= next)
			{
				Presource.Money -= next;

			} else {
				acties = Acties.error;
			}
		}
	}
}

