using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MASTopia
{
	public class GameObjects
	{
		public TouchInput touchInput{ get; set;}

		public int gameBoundX{ get; set;}
		public int gameBoundY{ get; set;}

		public float WidthScale {
			get;
			set;
		}
		public float HeightScale {
			get;
			set;
		}
		public Enum State {
			get;
			set;
		}
		public GraphicsDeviceManager Graphics {
			get;
			set;
		}
	}
}

