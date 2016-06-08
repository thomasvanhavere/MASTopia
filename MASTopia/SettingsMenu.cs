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
	public class SettingsMenu
	{
		public enum Acties
		{
			main,
			soundOn,
			soundOff,
			musicOn,
			musicOff,
			Nederlands,
			Engels,
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
		List<GUIElement> Settings = new List<GUIElement>();

		public SettingsMenu ()
		{
			Settings.Add (new GUIElement ("Main-Menu/Background"));

			Settings.Add (new GUIElement ("Main-Menu/MAS-background"));
			Settings.Add (new GUIElement ("settings/settings-bg"));
			Settings.Add (new GUIElement ("settings/contact"));
			Settings.Add (new GUIElement ("settings/english"));
			Settings.Add (new GUIElement ("settings/facebook"));
			//Settings.Add (new GUIElement ("settings/music-off"));
			Settings.Add (new GUIElement ("settings/music-on"));
			//Settings.Add (new GUIElement ("settings/nederlands"));
			//Settings.Add (new GUIElement ("settings/sound-off"));
			Settings.Add (new GUIElement ("settings/sound-on"));

			Settings.Add (new GUIElement ("Cross-Screen/X"));
		}


		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in Settings) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			Settings.Find (x => x.AssetName == "Main-Menu/MAS-background").PutBg ();
			Settings.Find (x => x.AssetName == "settings/settings-bg").moveElement (65,25);
			Settings.Find (x => x.AssetName == "settings/contact").moveElement (985,595);
			Settings.Find (x => x.AssetName == "settings/music-on").moveElement (985,400);
			Settings.Find (x => x.AssetName == "settings/english").moveElement (175,595);
			Settings.Find (x => x.AssetName == "settings/sound-on").moveElement (175,400);
			Settings.Find (x => x.AssetName == "settings/facebook").moveElement (660,815);


			Settings.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1740,65);

		}
		public void Update(GameObjects gameObjects)
		{	
			foreach (GUIElement element in Settings) {
				if (element.AssetName=="settings/music-on"&&gameObjects.Music) {
					element.Update (gameObjects);
				}
				if (element.AssetName=="settings/music-off"&&gameObjects.Music==false) {
					element.Update (gameObjects);

				}
				element.Update (gameObjects);
			}

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in Settings) {
				element.Draw (spriteBatch);
			}

		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
				Console.WriteLine ("Exit x");
			}
			if (element=="settings/music-on") {
				acties = Acties.musicOff;
			}
		

		}
	}
}

