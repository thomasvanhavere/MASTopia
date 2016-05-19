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
			harbour.Add (new GUIElement ("Main-Game/island"));
			harbour.Add (new GUIElement ("Boat/boat-screen"));
			harbour.Add (new GUIElement ("Boat/go-fishing"));
			harbour.Add (new GUIElement ("Cross-Screen/upgrade"));
			harbour.Add (new GUIElement ("Cross-Screen/X1"));


		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in harbour) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			harbour.Find (x => x.AssetName == "Main-Game/island").PutBg ();
			harbour.Find (x => x.AssetName == "Boat/boat-screen").PutBg();

			harbour.Find (x => x.AssetName == "Boat/go-fishing").moveElement (150, 800);
			harbour.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (1615, 800);
			harbour.Find (x => x.AssetName == "Cross-Screen/X1").moveElement (1770, 75);
		}
		public void Update(GameObjects gameObjects)
		{
			
				foreach (GUIElement element in harbour) {
					element.Update (gameObjects);
				}
	


		}
		public void Draw(SpriteBatch spriteBatch)
		{
			

				foreach (GUIElement element in harbour) {
					element.Draw (spriteBatch);
				}

		}


		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X1") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}

		}
	}
}

