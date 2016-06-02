using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;
using System.Threading;

namespace MASTopia
{
	 class BaseLogics
	{
		public BaseLogics ()
		{
		}
		public BaseLogics (GameTime gameTime, GameObjects obj)
		{
			
		}
		public void fillProp(GameTime gameTime, DrawFarm farm,DrawHarbour harbour,GameObjects gameObjects, DrawMarket market)
		{
			if (gameObjects.TotalRecource<=market.Storage) {

				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%12==0)
				{
					gameObjects.Grains += farm.GrainTile;
					gameObjects.Vegies += farm.VegieTile;

				}
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%24==0)
				{
					gameObjects.Meat += farm.MeatTile;
				}
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%60==0)
				{
					gameObjects.Chemwaste += (int)((1 / 5) * (farm.GrainTile * 5));
					gameObjects.Chemwaste += (int)((1 / 5) * (farm.VegieTile * 5));
					gameObjects.Chemwaste += (int)((1 / 5) * (farm.MeatTile * 5));
				}
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%120==0)
				{
					gameObjects.Fish += (harbour.ShipCapacity*harbour.AmountOfShips);
					gameObjects.Chemwaste += (int)(1 / 5) * (harbour.ShipCapacity*harbour.AmountOfShips);
					gameObjects.waste -= gameObjects.amountTiles;
				}
				gameObjects.TotalRecource = gameObjects.Grains+gameObjects.Fish+gameObjects.Meat+gameObjects.Vegies;
			} else {
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%12==0)
				{
					gameObjects.waste += farm.GrainTile;
					gameObjects.waste += farm.VegieTile;

				}
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%24==0)
				{
					gameObjects.waste += farm.MeatTile;

				}
				if (Math.Round(gameTime.TotalGameTime.TotalSeconds,2)%120==0)
				{
					gameObjects.waste += (harbour.ShipCapacity*harbour.AmountOfShips);

				}
			}
		}
		public void update (GameTime gameTime, DrawResto resto, GameObjects obj)
		{
			int index = 0;
			foreach (BaseFood f in resto.food) {
				if (f.endTick<(int)gameTime.TotalGameTime.TotalSeconds) {
					obj.Money += f.Money;
					obj.XP += f.Experience;
					obj.waste += f.Waste;
					index = resto.food.IndexOf (f);
					resto.food.RemoveAt(index);
					return;
				}
			}
		}
	}
}

