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
	public class DrawFarm
	{
		public enum Acties
		{
			main,
			Upgrade,
			Tiles,
			error,
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

		private int meatTile=2;
		private int vegieTile=2;
		private int grainTile=2;

		public int MeatTile
		{
			get { return meatTile; }
			set { meatTile = value; }
		}
		public int VegieTile
		{
			get { return vegieTile; }
			set { vegieTile = value; }
		}
		public int GrainTile
		{
			get { return grainTile; }
			set { grainTile = value; }
		}
		private int tottiles = 6;
		public int totalTiles {
			get { return tottiles; }
			set { tottiles = value; }
		}
		List<GUIElement> farm = new List<GUIElement>();
		public int FarmLevel { get; set; }
		private SpriteFont font;
		private Drawerror error;

		public DrawFarm ()
		{
			error = new Drawerror ();

			farm.Add (new GUIElement ("Cross-Screen/Island-bg"));
			farm.Add (new GUIElement ("Farm/farm-bg"));
			farm.Add (new GUIElement ("Farm/Place-tiles"));
			farm.Add (new GUIElement ("Cross-Screen/upgrade"));
			farm.Add (new GUIElement ("Cross-Screen/X"));

			farm.Add (new GUIElement ("Farm/bar-speed"));
			farm.Add (new GUIElement ("Farm/bar-level"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in farm) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			farm.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			farm.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (135, 750);
			farm.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);
			farm.Find (x => x.AssetName == "Farm/Place-tiles").moveElement (1560, 750);

			farm.Find (x => x.AssetName == "Farm/bar-speed").moveElement (458, 844);
			farm.Find (x => x.AssetName == "Farm/bar-level").moveElement (1026, 849);
			error.LoadContent (content,gameObjects);
			gameObjects.amountTiles = totalTiles;


		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in farm) {
				element.Update (gameObjects);
			}
			if (acties==Acties.Upgrade) {
				acties = Acties.main;
				Upgradelvl (gameObjects);
			}
			if (acties == Acties.error) {
				error.Update (gameObjects);
			}
			gameObjects.amountTiles = totalTiles;

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in farm) {
				element.Draw (spriteBatch);
				if (element.AssetName=="Farm/bar-speed") {
					element.drawParial (tottiles,51);
				}
				if (element.AssetName=="Farm/bar-level") {
					element.drawParial (tottiles+3,51);
				}

			}

			spriteBatch.DrawString(font, "Tiles: " + tottiles.ToString() ,new Vector2(464,848), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, "Tiles: "+ (tottiles+3).ToString() ,new Vector2(1034,848), Color.Black,0,new Vector2(0,0),1.7f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, FarmLevel.ToString(),new Vector2(1000,80), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, ((FarmLevel+1)*100).ToString(),new Vector2(370,950), Color.White,0,new Vector2(0,0),3f,SpriteEffects.None,0f);

			if (acties == Acties.error) {
				error.Draw (spriteBatch, Drawerror.Acties.farm);
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
				acties = Acties.Upgrade;
				Console.WriteLine ("upgrade @ farm x");
			}
			if (element== "Farm/Place-tiles") {
				Console.WriteLine ("Place tiles");
			}
		}
		public void Upgradelvl(GameObjects Presource)
		{
			//=100*Level
			if (Presource.Money >= ((FarmLevel+1) * 100))
			{
				Presource.Money -= ((FarmLevel+1) * 100);
				FarmLevel++;
				tottiles += 3;
				meatTile++;
				vegieTile++;
				grainTile++;
			} else {
				acties = Acties.error;
			}
		}
	}
}

