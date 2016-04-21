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
	public class GameView
	{

		public enum GamePart
		{
			future,
			market,
			resto,
			transport,
			waste
		}

		List<GUIElement> mainBuildings = new List<GUIElement>();

		public GameView ()
		{
			mainBuildings.Add (new GUIElement ("done"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in mainBuildings) {
				element.LoadContent (content);
				element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}
		}
		public void Update(GameObjects gameObjects)
		{
			foreach (GUIElement element in mainBuildings) {
				element.Update (gameObjects);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in mainBuildings) {
				element.Draw (spriteBatch);
			}
		}
		public void OnClick(string element)
		{
		}
	}
}

