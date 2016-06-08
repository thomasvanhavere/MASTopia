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
	public class chooseFaction
	{
		public enum Faction{
			Transhumania,
			Rhizome,
			Augmentulitaria
		}
		public Faction faction {
			get;
			set;
		}
		public enum Screens{
			Trans,
			Rhiz,
			Aug,
			choose
		}
		private bool kies = false;
//		public bool Gekozen {
//			get{ return kies;}
//			set{kies=value;}
//		}
		private Screens schem = Screens.choose;
		public Screens screen {
			get{ return schem; }
			set{ schem = value; }
		}
		List<GUIElement> choose = new List<GUIElement>();
		List<GUIElement> rhizome = new List<GUIElement>();
		List<GUIElement> transhumania = new List<GUIElement>();
		List<GUIElement> augmenturia = new List<GUIElement>();


		public chooseFaction ()
		{
			choose.Add (new GUIElement ("Cross-Screen/Island-bg"));
			choose.Add (new GUIElement ("cluster5/choose-bg"));
			choose.Add (new GUIElement ("cluster5/aug-button"));
			choose.Add (new GUIElement ("cluster5/rhizome-button"));
			choose.Add (new GUIElement ("cluster5/trans-button"));

			rhizome.Add (new GUIElement ("Cross-Screen/Island-bg"));
			rhizome.Add (new GUIElement ("cluster5/rhizome-bg"));
			rhizome.Add (new GUIElement ("cluster5/join-rhiz"));

			transhumania.Add (new GUIElement ("Cross-Screen/Island-bg"));
			transhumania.Add (new GUIElement ("cluster5/transhumania-bg"));
			transhumania.Add (new GUIElement ("cluster5/join-trans"));

			augmenturia.Add (new GUIElement ("Cross-Screen/Island-bg"));
			augmenturia.Add (new GUIElement ("cluster5/aug-bg"));
			augmenturia.Add (new GUIElement ("cluster5/join-aug"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in choose) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			choose.Find (x => x.AssetName == "cluster5/rhizome-button").moveElement (525,320);
			choose.Find (x => x.AssetName == "cluster5/trans-button").moveElement (850,320);
			choose.Find (x => x.AssetName == "cluster5/aug-button").moveElement (1165,320);

			foreach (GUIElement element in rhizome) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			rhizome.Find (x => x.AssetName == "cluster5/join-rhiz").moveElement (205,760);

			foreach (GUIElement element in transhumania) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			transhumania.Find (x => x.AssetName == "cluster5/join-trans").moveElement (205,760);

			foreach (GUIElement element in augmenturia) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			augmenturia.Find (x => x.AssetName == "cluster5/join-aug").moveElement (205,760);

		}
		public void Update(GameObjects gameObjects)
		{
			switch (screen) {
			case Screens.choose:
				foreach (GUIElement element in choose) {
					element.Update (gameObjects);
				}
				break;
			case Screens.Rhiz:
				foreach (GUIElement element in rhizome) {
					element.Update (gameObjects);
				}
				break;
			case Screens.Trans:
				foreach (GUIElement element in transhumania) {
					element.Update (gameObjects);
				}
				break;
			case Screens.Aug:
				foreach (GUIElement element in augmenturia) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}
			if (kies) {
				gameObjects.Gekozen = true;
			}
			if (screen !=Screens.choose) {
				if (gameObjects.touchInput.swippedRight) {
					screen = Screens.choose;
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			switch (screen) {
			case Screens.choose:
				foreach (GUIElement element in choose) {
					element.Draw (spriteBatch);
				}
				break;
			case Screens.Rhiz:
				foreach (GUIElement element in rhizome) {
					element.Draw (spriteBatch);
				}
				break;
			case Screens.Trans:
				foreach (GUIElement element in transhumania) {
					element.Draw (spriteBatch);
				}
				break;
			case Screens.Aug:
				foreach (GUIElement element in augmenturia) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}
		}

		public void OnClick(string element)
		{
			if (element=="cluster5/rhizome-button") {
				screen = Screens.Rhiz;
			}
			if (element=="cluster5/trans-button") {
				screen = Screens.Trans;
			}
			if (element=="cluster5/aug-button") {
				screen = Screens.Aug;
			}
			if (element=="cluster5/join-rhiz"||element=="cluster5/join-aug"||element=="cluster5/join-trans") {
				kies = true;
			}
		}
	}
}