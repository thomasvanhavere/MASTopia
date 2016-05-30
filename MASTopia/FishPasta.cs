﻿using System;

namespace MASTopia
{
	 class FishPasta : BaseFood
	{
		private  int money = 60;

		public override int Money
		{
			get { return money; }
			set { money = value; }
		}
		private  int XP = 38;

		public override int Experience
		{
			get { return XP; }
			set { XP = value; }
		}
		private int waste = 3;

		public override int Waste
		{
			get { return waste; }
			set { waste = value; }
		}
		private int totalResource = 25;

		public override int TotalRecource
		{
			get { return totalResource; }
			set { totalResource = value; }
		}
		public override double Time {
			get;
			set;
		}
		public override int endTick { get; set; }

		public FishPasta(int restoLevel, GameObjects obj,int next)
		{
			//Tijd =(SOM(resources)/2)*2,25

			 Time = ((totalResource / 2) * (2.25 - (restoLevel * 0.15))) + 1;
			if (next>(int)obj.gameTime.TotalGameTime.TotalSeconds) {
				this.endTick = next+ (int)TimeSpan.FromSeconds(Time).TotalSeconds+1;

			} 
			else {
				this.endTick = (int)obj.gameTime.TotalGameTime.TotalSeconds+(int)TimeSpan.FromSeconds(Time).TotalSeconds;

			}
			obj.Fish -= 15;
			obj.Vegies -= 5;
			obj.Grains -= 10;
		}
		public FishPasta()
		{

		}
	}
}

