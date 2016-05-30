using System;

namespace MASTopia
{
	 class HerbCake : BaseFood
	{
		private int money = 40;

		public override int Money
		{
			get { return money; }
			set { money = value; }
		}
		private int XP = 25;

		public override int Experience
		{
			get { return XP; }
			set { XP = value; }
		}
		private int waste = 2;

		public override int Waste
		{
			get { return waste; }
			set { waste = value; }
		}

		private  int totalResource = 20;

		public override int TotalRecource
		{
			get { return totalResource; }
			set { totalResource = value; }
		}
		public override int endTick { get; set; }
		public override double Time {
			get;
			set;
		}
		public HerbCake(int restoLevel, GameObjects obj,int next)
		{
			//Tijd =(SOM(resources)/2)*2,25
			 Time = ((totalResource / 2) * (2.25 - (restoLevel * 0.15))) + 1;
			if (next>(int)obj.gameTime.TotalGameTime.TotalSeconds) {
				this.endTick = next+ (int)TimeSpan.FromSeconds(Time).TotalSeconds+1;

			} 
			else {
				this.endTick = (int)obj.gameTime.TotalGameTime.TotalSeconds+(int)TimeSpan.FromSeconds(Time).TotalSeconds;

			}
			obj.Grains -= 10;
			obj.Vegies -= 10;

		}
		public HerbCake()
		{

		}
	}
}

