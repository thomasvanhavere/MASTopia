
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
		private SpriteFont font;

		public DrawProfile ()
		{
			profile.Add (new GUIElement ("Cross-Screen/Island-bg"));
			profile.Add (new GUIElement ("Profile/profile-bg"));

			profile.Add (new GUIElement ("Cross-Screen/X"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			font = content.Load<SpriteFont> ("MyFont");

			foreach (GUIElement element in profile) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			profile.Find (x => x.AssetName == "Cross-Screen/Island-bg").PutBg ();
			profile.Find (x => x.AssetName == "Profile/profile-bg").moveElement (65,25);
			profile.Find (x => x.AssetName == "Cross-Screen/X").moveElement (1750,65);

		}
		private int aGrain=0;
		private int aFish=0;
		private int aVege=0;
		private int aMeat=0;

		private int rat=0;
		private int bunny=0;
		private int pig=0;
		private int snail=0;

		private int chees=0;
		private int wall=0;
		private int boemkool=0;
		private int egel=0;

		private int playerlevel;

		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in profile) {
				element.Update (gameObjects);
			}
			aGrain = gameObjects.Grains;
			aFish = gameObjects.Fish;
			aVege = gameObjects.Vegies;
			aMeat = gameObjects.Meat;
			playerlevel = gameObjects.PLayerLevel;
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (GUIElement element in profile) {
				element.Draw (spriteBatch);
			}
			spriteBatch.DrawString(font, aGrain.ToString(),new Vector2(690,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, aFish.ToString(),new Vector2(830,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, aVege.ToString(),new Vector2(690,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, aMeat.ToString(),new Vector2(830,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, rat.ToString(),new Vector2(1080,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, bunny.ToString(),new Vector2(1220,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, pig.ToString(),new Vector2(1080,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, snail.ToString(),new Vector2(1220,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, chees.ToString(),new Vector2(1465,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, wall.ToString(),new Vector2(1465,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, boemkool.ToString(),new Vector2(1605,945), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);
			spriteBatch.DrawString(font, egel.ToString(),new Vector2(1605,805), Color.White,0,new Vector2(0,0),1.3f,SpriteEffects.None,0f);

			spriteBatch.DrawString(font, playerlevel.ToString(),new Vector2(1000,80), Color.White,0,new Vector2(0,0),2f,SpriteEffects.None,0f);


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

