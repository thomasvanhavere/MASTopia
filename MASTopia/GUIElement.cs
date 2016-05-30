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
		public Texture2D guiTexture {
			get{ return GUITexture;}
			set{ GUITexture=value; }
		}

		private Rectangle GUIRect;
		public Rectangle guiRect {
			get{ return GUIRect;}
			set{ GUIRect=value; }
		}


		private string assetName;
		public int Counter {
			get;
			set;
		}

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

		public GUIElement()
		{
		}

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
		public void drawParial(int Clvl, int X)
		{
			int scale = (guiTexture.Width / X);
			GUIRect = new Rectangle (GUIRect.X , GUIRect.Y , (scale*Clvl), GUIRect.Height);

		}
	}
}

