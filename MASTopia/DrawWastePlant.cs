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
		List<GUIElement> waste = new List<GUIElement>();

		public DrawWastePlant ()
		{
			waste.Add (new GUIElement ("Cross-Screen/Island-bg"));
			waste.Add (new GUIElement ("WastePlant/wastePlant-bg"));
			waste.Add (new GUIElement ("Cross-Screen/upgrade"));
			waste.Add (new GUIElement ("Cross-Screen/X"));


		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in waste) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			waste.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			waste.Find (x => x.AssetName == "WastePlant/wastePlant-bg").moveElement (65,25);

			waste.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (135, 750);
			waste.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in waste) {
				element.Update (gameObjects);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in waste) {
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
				Console.WriteLine ("Upgrade @ wastePlant");
			}

		}
	}
}

