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
			Screen2,
			Exit
		}

		private screens screen;
		public screens scherm
		{
			get{
				return screen;
			}
			set{
				screen = value;
			}
		}
		public enum Acties
		{
			upgrade,
			Attack,
			Defense,
			Enemes

		}
		private Acties acties;

		public Acties State
		{
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
	

		List<GUIElement> Screen1 = new List<GUIElement>();
		List<GUIElement> Screen2 = new List<GUIElement>();
		public DrawBarracks ()
		{
			Screen1.Add (new GUIElement ("Main-Game/island"));
			Screen1.Add (new GUIElement ("barracks/barrack-bg"));
			Screen1.Add (new GUIElement ("Cross-Screen/upgrade"));
			Screen1.Add (new GUIElement ("Cross-Screen/X"));

			Screen2.Add (new GUIElement ("Main-Game/island"));
			Screen2.Add (new GUIElement ("barracks/barracks-bg2"));
			Screen2.Add (new GUIElement ("Cross-Screen/X"));
			Screen2.Add (new GUIElement ("barracks/attack"));
			Screen2.Add (new GUIElement ("barracks/target"));
			Screen2.Add (new GUIElement ("barracks/defense"));
		}

		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in Screen1) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}
			Screen1.Find(x=>x.AssetName=="Main-Game/island").PutBg();
			Screen1.Find(x=>x.AssetName=="barracks/barrack-bg").PutBg();
			Screen1.Find(x=>x.AssetName=="Cross-Screen/upgrade").moveElement(835,750);
			Screen1.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1770,75);


			foreach (GUIElement element in Screen2) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			Screen2.Find(x=>x.AssetName=="Main-Game/island").PutBg();
			Screen2.Find(x=>x.AssetName=="barracks/barracks-bg2").PutBg();

			Screen2.Find(x=>x.AssetName=="barracks/attack").moveElement(150,740);
			Screen2.Find(x=>x.AssetName=="barracks/target").moveElement(660,740);
			Screen2.Find(x=>x.AssetName=="barracks/defense").moveElement(1230,740);
			Screen2.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1770,75);
		}
		public void Update(GameObjects gameObjects)
		{
			
			switch (screen) {
			case screens.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Update (gameObjects);
				}
				break;

			case screens.Screen2:
				foreach (GUIElement element in Screen2) {
					element.Update (gameObjects);
				}

				break;
			default:
				break;
			}

			if (gameObjects.touchInput.swippedLeft) {
				screen = screens.Screen2;
			}
			if(gameObjects.touchInput.swippedRight){
				screen = screens.Screen1;
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
			case screens.Screen2:
				foreach (GUIElement element in Screen2) {
							element.Draw (spriteBatch);
				}

			break;
			default:
				break;
			}

		}


		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X") {
				screen = screens.Exit;
				Console.WriteLine ("Exit x");
			}
//			if (element== "Cross-Screen/X1") {
//				screen = screens.Exit;
//				Console.WriteLine ("Exit X1");
//
//			}

		}
	}
}

