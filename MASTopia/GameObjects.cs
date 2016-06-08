using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

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

		public SpriteFont Font {
			get;
			set;
		}

		private int vegies=50;
		private int meat=50;
		private int grains=50;
		private int fish=50;
		private int playerLevel = 0;

		public int Vegies
		{
			get { return vegies; }
			set { vegies = value; }
		}
		public int Meat
		{
			get { return meat; }
			set { meat = value; }
		}
		public int Grains
		{
			get { return grains; }
			set { grains = value; }
		}
		public int Fish
		{
			get { return fish; }
			set { fish = value; }
		}
		public int Money { get; set; }
		public int XP { get; set; }

		public int NextTick { get; set; }


		public int PLayerLevel
		{
			get { return playerLevel ; }
			set { playerLevel  = value; }
		}
		private int nextLevel = 100;

		public int NextLevel
		{
			get { return nextLevel; }
			set { nextLevel = value; }
		}

		public bool cluster1 {
			get;
			set;
		}
		public bool cluster2 {
			get;
			set;
		}
		public bool cluster3 {
			get;
			set;
		}
		public bool cluster4 {
			get;
			set;
		}


		public GameTime gameTime {
			get;
			set;
		}
		public int TotalRecource {
			get;
			set;
		}
		public int waste {
			get;
			set;
		}

		public int Chemwaste {
			get;
			set;
		}
		public int amountTiles {
			get;
			set;
		}
		public bool Music {
			get;
			set;
		}
		public void CheckLevelPlayer()
		{
			// y = 100(1 + 0.26) ^ x


			if (XP>=nextLevel)
			{
				playerLevel++;
				double next = (100 * Math.Pow((double)(1 + 0.26), (double)playerLevel));
				nextLevel += (int)next;



			}
		}

	}
}

