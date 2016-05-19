using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace MASTopia
{
	public class GUIElement
	{
		private Texture2D GUITexture;

		private Rectangle GUIRect;

		private Vector2 position;

		private string assetName;

		public string AssetName {
			get {
				return assetName;
			}
			set {
				assetName = value;
			}
		}
		public delegate void ElementClicked(string element);

		public event ElementClicked clickEvent;

		public GUIElement(string assetName)
		{
			this.assetName = assetName;
		}
		public void LoadContent(ContentManager content, GameObjects Obj)
		{
			GUITexture = content.Load<Texture2D> (assetName);
			GUIRect = new Rectangle (0, 0, (GUITexture.Width), (GUITexture.Height));

		}
		public void Update(GameObjects gameObjects)
		{

			if (GUIRect.Contains(new Point(gameObjects.touchInput.X,gameObjects.touchInput.Y))&&gameObjects.touchInput.tapped ){

				clickEvent (assetName);
			}


		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (GUITexture, GUIRect, Color.White);

		}

		public void Draw(SpriteBatch spriteBatch , float scale)
		{
			position = new Vector2(GUIRect.X,GUIRect.Y);

			spriteBatch.Draw(GUITexture, position, null, Color.White, 0f, 
				Vector2.Zero, scale, SpriteEffects.None, 0f);
			
			GUIRect = new Rectangle(0,0,(int)(GUITexture.Width*scale),(int)(GUITexture.Height*scale));
		}
		public void Center(int height, int width)
		{
			GUIRect = new Rectangle ((width / 2) - (this.GUITexture.Width / 2), (height / 2) - (this.GUITexture.Height / 2), this.GUITexture.Width, this.GUITexture.Height);
		}
		public void moveElement(int x, int y)
		{
			
			GUIRect = new Rectangle (GUIRect.X += x, GUIRect.Y += y, GUIRect.Width, GUIRect.Height);
		}
		public void PutBg()
		{
			GUIRect = new Rectangle (0, 0, this.GUITexture.Width, this.GUITexture.Height);
		}
	}
}

