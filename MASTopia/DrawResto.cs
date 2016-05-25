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
		private int hotchpotch = 26;
		private int fishpasta = 34;
		private int herbcake = 23;
		private int bbq = 6;

		private int simmerTrout = 28;
		private int friet = 6;
		private int calamares = 6;
		private int waffel=11;

		private int restolevel = 0;

		List<GUIElement> resto = new List<GUIElement>();
		private SpriteFont font;

		public DrawResto ()
		{
			resto.Add (new GUIElement ("Cross-Screen/Island-bg"));
			resto.Add (new GUIElement ("Resto/resto-bg"));

			resto.Add (new GUIElement ("Cross-Screen/upgrade"));
			resto.Add (new GUIElement ("Cross-Screen/X"));

			resto.Add (new GUIElement ("Resto/down"));
			resto.Add (new GUIElement ("Resto/up"));
			//links
			resto.Add (new GUIElement ("Resto/prepare-46points")); //hotchpotch
			resto.Add (new GUIElement ("Resto/prepare-60points-blue"));//fishpasta
			resto.Add (new GUIElement ("Resto/prepare-40points-blue"));//herbcake
			resto.Add (new GUIElement ("Resto/prepare-10points-blue"));//bbq

			//rechts
			resto.Add (new GUIElement ("Resto/preapare-50points"));//simmerTrout
			resto.Add (new GUIElement ("Resto/prepare-10points-orange"));//friet
			resto.Add (new GUIElement ("Resto/prepare-10points-orange1"));//calamares
			resto.Add (new GUIElement ("Resto/preapare-50points"));//waffel

			resto.Add (new GUIElement ("Resto/bar-speed"));
			resto.Add (new GUIElement ("Resto/bar-upgrade"));


		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");

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
			resto.Find (x => x.AssetName == "Resto/prepare-46points").moveElement (645, 260);


			resto.Find (x => x.AssetName == "Resto/preapare-50points").moveElement(1475, 260) ;

			resto.Find (x => x.AssetName == "Resto/bar-speed").moveElement (198, 874);
			resto.Find (x => x.AssetName == "Resto/bar-upgrade").moveElement (1138, 875);


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
			spriteBatch.DrawString(font, hotchpotch.ToString(),new Vector2(213,317), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, fishpasta.ToString(),new Vector2(213,447), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, herbcake.ToString(),new Vector2(213,567), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, bbq.ToString(),new Vector2(213,687), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, simmerTrout.ToString(),new Vector2(1030,317), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, friet.ToString(),new Vector2(1030,447), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, calamares.ToString(),new Vector2(1030,567), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, waffel.ToString(),new Vector2(1030,687), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, restolevel.ToString(),new Vector2(1030,90), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);


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

