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
			main,
			future,
			market,
			resto,
			transport,
			waste
		}
		private GamePart gamePart;
		List<GUIElement> mainBuildings = new List<GUIElement>();
		List<GUIElement> BasicElements = new List<GUIElement>();

		public GameView ()
		{
			mainBuildings.Add (new GUIElement ("Main-Game/market"));
			mainBuildings.Add (new GUIElement ("Main-Game/future"));
			mainBuildings.Add (new GUIElement ("Main-Game/resto"));
			mainBuildings.Add (new GUIElement ("Main-Game/transport"));
			mainBuildings.Add (new GUIElement ("Main-Game/waste"));

			BasicElements.Add(new GUIElement("Main-Menu/done"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in mainBuildings) {
				element.LoadContent (content);
				element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}
			mainBuildings.Find (x => x.AssetName == "Main-Game/market").moveElement (-350, -200);
			mainBuildings.Find (x => x.AssetName == "Main-Game/future").moveElement (-50, -200);
			mainBuildings.Find (x => x.AssetName == "Main-Game/resto").moveElement (300, -200);
			mainBuildings.Find (x => x.AssetName == "Main-Game/transport").moveElement (-150, 200);
			mainBuildings.Find (x => x.AssetName == "Main-Game/waste").moveElement (250, 150);

			foreach (var element in BasicElements) {
				element.LoadContent (content);
				element.Center (gameObjects.gameBoundX, gameObjects.gameBoundY);
				element.clickEvent += OnClick;
			}

		}
		public void Update(GameObjects gameObjects)
		{
			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.market:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.future:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.resto:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.transport:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			case GamePart.waste:
				foreach (var element in BasicElements) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}

		}


		public void Draw(SpriteBatch spriteBatch)
		{
			

			switch (gamePart) {
			case GamePart.main:
				foreach (GUIElement element in mainBuildings) {
					element.Draw (spriteBatch,0.75f);
				}
				break;
			case GamePart.market:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.future:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.resto:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.transport:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			case GamePart.waste:
				foreach (var element in BasicElements) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}

		}
		public void OnClick(string element)
		{
			if (element=="Main-Game/market") {
				gamePart = GamePart.market;
			}
			if (element=="Main-Game/future") {
				gamePart = GamePart.future;
			}
			if (element=="Main-Game/resto") {
				gamePart = GamePart.resto;
			}
			if (element=="Main-Game/transport") {
				gamePart = GamePart.transport;
			}
			if (element=="Main-Game/waste") {
				gamePart = GamePart.waste;
			}
			if (element=="Main-Menu/done") {
				gamePart = GamePart.main;
			}
		}
	}
}

