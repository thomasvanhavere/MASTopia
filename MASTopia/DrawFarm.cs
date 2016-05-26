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

		List<GUIElement> farm = new List<GUIElement>();
		public int FarmLevel { get; set; }

		public DrawFarm ()
		{
			farm.Add (new GUIElement ("Cross-Screen/Island-bg"));
			farm.Add (new GUIElement ("Farm/farm-bg"));
			farm.Add (new GUIElement ("Farm/Place-tiles"));
			farm.Add (new GUIElement ("Cross-Screen/upgrade"));
			farm.Add (new GUIElement ("Cross-Screen/X"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in farm) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			farm.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			farm.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (135, 750);
			farm.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);
			farm.Find (x => x.AssetName == "Farm/Place-tiles").moveElement (1560, 750);

		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in farm) {
				element.Update (gameObjects);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in farm) {
				element.Draw (spriteBatch);
			}

		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}
			if (element== "Cross-Screen/upgrade") {
				Console.WriteLine ("upgrade @ farm x");
			}
			if (element== "Farm/Place-tiles") {
				Console.WriteLine ("Place tiles");
			}
		}
		public void Upgradelvl(GameObjects Presource)
		{
			//=100*Level
			if (Presource.Money >= (FarmLevel * 100))
			{
				FarmLevel++;
				Presource.Money -= (FarmLevel * 100);
			}

		}
	}
}

