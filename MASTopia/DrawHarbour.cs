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
	public class DrawHarbour
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
		List<GUIElement> harbour = new List<GUIElement>();

		public DrawHarbour ()
		{
			harbour.Add (new GUIElement ("Cross-Screen/Island-bg"));
			harbour.Add (new GUIElement ("Boat/boat-screen"));
			harbour.Add (new GUIElement ("Boat/go-fishing"));
			harbour.Add (new GUIElement ("Cross-Screen/upgrade-small"));
			harbour.Add (new GUIElement ("Cross-Screen/X"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in harbour) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			harbour.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();

			harbour.Find (x => x.AssetName == "Boat/boat-screen").moveElement(65,25);

			harbour.Find (x => x.AssetName == "Boat/go-fishing").moveElement (150, 800);
			harbour.Find (x => x.AssetName == "Cross-Screen/upgrade-small").moveElement (1610, 805);
			harbour.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

		}
		public void Update(GameObjects gameObjects)
		{			
				foreach (GUIElement element in harbour) {
					element.Update (gameObjects);
				}
			//Console.WriteLine ("Update harbour");
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in harbour) {
				element.Draw (spriteBatch);
				}

		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}
			if (element== "Boat/go-fishing") {
				Console.WriteLine ("go-fishing");
			}
			if (element== "Cross-Screen/upgrade-small") {
				Console.WriteLine ("Upgrade @ Harbour");
			}

		}
	}
}

