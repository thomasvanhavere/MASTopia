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
	public class DrawBarracks
	{
		public enum screens
		{
			Screen1,
			Screen2
		}
		public enum Actions
		{
			upgrade,
			Attack,
			Defense,
			Enemes
		}
		private screens screen;
		List<GUIElement> Screen1 = new List<GUIElement>();
		List<GUIElement> Screen2 = new List<GUIElement>();

		public DrawBarracks ()
		{
			Screen1.Add (new GUIElement ("barracks/barrack-bg"));
			Screen1.Add (new GUIElement ("barracks/upgrade"));
		}

		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in Screen1) {
				element.LoadContent (content,gameObjects);
				//element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}
		//	mainBuildings.Find (x => x.AssetName == "Main-Game/money-button").moveElement (-550, -400);

			Screen1.Find(x=>x.AssetName=="barracks/barrack-bg").PutBg();
			

		}
		public void Update(GameObjects gameObjects)
		{
			switch (screen) {
			case screens.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}


		}
		public void Draw(SpriteBatch spriteBatch)
		{
			switch (screen) {
			case screens.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}
		}


		public void OnClick(string element)
		{
//			if (element=="Main-Game/market") {
//				gamePart = GamePart.market;
			//}

		}
	}
}

