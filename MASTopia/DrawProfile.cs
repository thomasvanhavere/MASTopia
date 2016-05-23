
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
	public class DrawProfile
	{
		public enum Acties
		{
			main,
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
		List<GUIElement> profile = new List<GUIElement>();


		public DrawProfile ()
		{
			profile.Add (new GUIElement ("Cross-Screen/Island-bg"));
			profile.Add (new GUIElement ("Profile/profile-bg"));

			profile.Add (new GUIElement ("Cross-Screen/X"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in profile) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			profile.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			profile.Find (x => x.AssetName == "Profile/profile-bg").moveElement (65,25);
			profile.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1770, 75);

		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in profile) {
				element.Update (gameObjects);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in profile) {
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

