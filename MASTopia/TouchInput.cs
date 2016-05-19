using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace MASTopia
{
	public class TouchInput
	{
		public bool up{ get; set; }
		public bool down{ get; set; }
		public bool tapped{ get; set; }
		public bool swippedRight {
			get;
			set;
		}
		public bool swippedLeft {
			get;
			set;
		}
		public int X{ get; set; }
		public int Y{ get; set; }
	}
}

