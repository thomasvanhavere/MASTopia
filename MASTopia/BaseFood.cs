using System;

namespace MASTopia
{
	abstract class BaseFood
	{
		public BaseFood ()
		{
		}
		public abstract int Money
		{
			get;
			set;
		}

		public abstract int Experience
		{
			get;
			set;
		}

		public abstract int Waste
		{
			get;
			set;
		}


		public abstract int TotalRecource
		{
			get;
			set;
		}
		public abstract double Time {
			get;
			set;
		}
		public abstract int endTick { get; set; }

	}
}

