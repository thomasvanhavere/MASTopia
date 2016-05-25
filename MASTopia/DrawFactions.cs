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
	public class DrawFactions
	{
		public enum Acties
		{
			main,
			Screen1,
			Screen2,
			Screen3,
			Exit

		}
		private Acties acties = Acties.main;

		public Acties State {
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
		List<GUIElement> faction = new List<GUIElement>();
		List<GUIElement> Screen1 = new List<GUIElement>();
		List<GUIElement> Screen2 = new List<GUIElement>();
		List<GUIElement> Screen3 = new List<GUIElement>();


		public DrawFactions ()
		{
		//	faction.Add (new GUIElement ("Cross-Screen/Island-bg"));
			faction.Add (new GUIElement ("Factions/factions bg"));
			faction.Add (new GUIElement ("Factions/augmentulitaria"));
			faction.Add (new GUIElement ("Factions/rhizome"));
			faction.Add (new GUIElement ("Factions/transhumania"));
			faction.Add (new GUIElement ("Cross-Screen/X"));


			//Screen1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Screen1.Add (new GUIElement ("Factions/factions bg"));
			Screen1.Add (new GUIElement ("Factions/augmentulitaria-screen"));
			Screen1.Add (new GUIElement ("Cross-Screen/X"));

			//Screen2.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Screen2.Add (new GUIElement ("Factions/factions bg"));
			Screen2.Add (new GUIElement ("Factions/rhizome-screen"));
			Screen2.Add (new GUIElement ("Cross-Screen/X"));

		//	Screen3.Add (new GUIElement ("Cross-Screen/Island-bg"));
			Screen3.Add (new GUIElement ("Factions/factions bg"));
			Screen3.Add (new GUIElement ("Factions/transhumania-screen"));
			Screen3.Add (new GUIElement ("Cross-Screen/X"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in faction) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			//faction.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			faction.Find(x=>x.AssetName=="Factions/factions bg").PutBg();
			faction.Find(x=>x.AssetName=="Factions/augmentulitaria").moveElement(1310,240);
			faction.Find(x=>x.AssetName=="Factions/rhizome").moveElement(820,165);
			faction.Find(x=>x.AssetName=="Factions/transhumania").moveElement(265,240);
			faction.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			foreach (GUIElement element in Screen1) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			//Screen1.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Screen1.Find(x=>x.AssetName=="Factions/factions bg").PutBg();
			Screen1.Find(x=>x.AssetName=="Factions/augmentulitaria-screen").PutBg();
			Screen1.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			foreach (GUIElement element in Screen2) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			//Screen2.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Screen2.Find(x=>x.AssetName=="Factions/factions bg").PutBg();
			Screen2.Find(x=>x.AssetName=="Factions/rhizome-screen").PutBg();
			Screen2.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);

			foreach (GUIElement element in Screen3) {
				element.LoadContent (content,gameObjects);
				element.clickEvent += OnClick;
			}

			//Screen3.Find(x=>x.AssetName=="Cross-Screen/Island-bg").PutBg();
			Screen3.Find(x=>x.AssetName=="Factions/factions bg").PutBg();
			Screen3.Find(x=>x.AssetName=="Factions/transhumania-screen").PutBg();
			Screen3.Find(x=>x.AssetName=="Cross-Screen/X").moveElement(1750,65);


		}
		public void Update(GameObjects gameObjects)
		{

			switch (acties) {
			case Acties.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Update (gameObjects);
				}
				break;

			case Acties.Screen2:
				foreach (GUIElement element in Screen2) {
					element.Update (gameObjects);
				}

				break;
			case Acties.Screen3:
				foreach (GUIElement element in Screen3) {
					element.Update (gameObjects);
				}
				break;
			case Acties.main:
				foreach (GUIElement element in faction) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}

		}
		public void Draw(SpriteBatch spriteBatch)
		{			
			switch (acties) {
			case Acties.Screen1:
				foreach (GUIElement element in Screen1) {
					element.Draw (spriteBatch);
				}
				break;
			case Acties.Screen2:
				foreach (GUIElement element in Screen2) {
					element.Draw (spriteBatch);
				}

				break;
			case Acties.Screen3:
				foreach (GUIElement element in Screen3) {
					element.Draw (spriteBatch);
				}

				break;
			case Acties.main:
				foreach (GUIElement element in faction) {
					element.Draw (spriteBatch);
				}

				break;
			default:
				break;
			}

		}
		public void OnClick(string element)
		{
			if (element== "Cross-Screen/X" && (acties==Acties.Screen1||acties==Acties.Screen2||acties==Acties.Screen3)) {
				acties = Acties.main;
			}
			else if (element== "Cross-Screen/X") {
				acties = Acties.Exit;
			}
			if (element=="Factions/augmentulitaria") {
				acties = Acties.Screen1;
			}
			if (element=="Factions/rhizome") {
				acties = Acties.Screen2;
			}
			if (element=="Factions/transhumania") {
				acties = Acties.Screen3;
			}

		}
	}
}

