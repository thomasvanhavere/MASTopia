using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace MASTopia
{
	public class BackGround
	{
		protected readonly Rectangle gameBoundaries;
		protected readonly Texture2D texture;
		public  Vector2 Location;

		public int Width
		{
			get{ return texture.Width; }
		}
		public int Height
		{
			get{ return texture.Height; }
		}

		public BackGround(Texture2D texture, Vector2 location)
		{
			this.texture = texture;
			Location = location;
		}
//		public override void Update(GameTime gameTime, GameObjects gameObjects)
//		{
//			return;
//		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (texture, Location);

		}
	}
}

