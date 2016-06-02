using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;

namespace MASTopia
{
	public class Drawerror
	{
		public enum Acties
		{
			main,
			harbour,
			market,
			farm,
			resto,
			waste,
			Exit

		}
		private Acties acties;

		public Acties State {
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}
		List<GUIElement> error = new List<GUIElement>();
		public Drawerror ()
		{
			error.Add (new GUIElement ("Cross-Screen/Island-bg"));
			error.Add (new GUIElement ("error/farm-error-money"));
			error.Add (new GUIElement ("error/harbor-error-money"));
			error.Add (new GUIElement ("error/market-error-money"));
			error.Add (new GUIElement ("error/restaurant-error-money"));
			error.Add (new GUIElement ("error/waste-error-money"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in error) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
		}
		public void Update(GameObjects gameObjects)
		{			
			foreach (GUIElement element in error) {
				element.Update (gameObjects);
			}

		}
		public void Draw(SpriteBatch spriteBatch, Acties actie )
		{
				foreach (GUIElement element in error) {
					if (actie == Acties.farm && element.AssetName == "error/farm-error-money") {
						element.Draw (spriteBatch);
					}
					if (actie == Acties.harbour && element.AssetName == "error/harbor-error-money") {
						element.Draw (spriteBatch);

					}
					if (actie == Acties.market && element.AssetName == "error/market-error-money") {
						element.Draw (spriteBatch);

					}
					if (actie == Acties.resto && element.AssetName == "error/restaurant-error-money") {
						element.Draw (spriteBatch);

					}
					if (actie == Acties.waste && element.AssetName == "error/waste-error-money") {
						element.Draw (spriteBatch);

					}

			}
		}
		public void OnClick(string element)
		{
			if ((element== "error/farm-error-money"||element== "error/market-error-money"||
				element== "error/harbor-error-money"||element== "error/restaurant-error-money"||element== "error/waste-error-money"))
			{
				acties = Acties.Exit;
			}

		}
	}
}

