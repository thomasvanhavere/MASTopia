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
	public class DrawResto
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
		List<GUIElement> resto = new List<GUIElement>();

		public DrawResto ()
		{
			resto.Add (new GUIElement ("Cross-Screen/Island-bg"));
			resto.Add (new GUIElement ("Resto/resto-bg"));

			resto.Add (new GUIElement ("Cross-Screen/upgrade"));
			resto.Add (new GUIElement ("Cross-Screen/X"));

			resto.Add (new GUIElement ("Resto/down"));
			resto.Add (new GUIElement ("Resto/up"));

			resto.Add (new GUIElement ("Resto/prepare-r"));
			resto.Add (new GUIElement ("Resto/prepare-b"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in resto) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			resto.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			resto.Find (x => x.AssetName == "Resto/resto-bg").moveElement (65,25);

			resto.Find (x => x.AssetName == "Cross-Screen/upgrade").moveElement (820, 780);
			resto.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

			resto.Find (x => x.AssetName == "Resto/down").moveElement (1735, 625);
			resto.Find (x => x.AssetName == "Resto/up").moveElement (1735,260 );
			resto.Find (x => x.AssetName == "Resto/prepare-r").moveElement (1475, 260);
			resto.Find (x => x.AssetName == "Resto/prepare-b").moveElement (645, 260);


		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in resto) {
				element.Update (gameObjects);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in resto) {
				element.Draw (spriteBatch);
			}

		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}


		}

	}
}

