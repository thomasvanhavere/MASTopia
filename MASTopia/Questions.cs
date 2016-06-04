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
	public class Questions
	{
		public enum Acties
		{
			harbour,
			farm,
			market,
			resto,
			faction,
			exit

		}
		private bool wrong4 = false;
		private bool wrong2 = false;
		private bool wrong3 = false;

		private Acties acties;

		public enum Screen {
			Cluster_1I,
			Cluster_1Q,
			Cluster_1E,
		}
		private	bool vraag1 = false;
		public bool Vraag1 {
			get{return vraag1;}
			set{vraag1 = value;}
		}
		private Screen screens = Screen.Cluster_1I;
		public Acties State {
			get
			{
				return acties;
			}
			set{
				acties=value;
			}
		}

		List<GUIElement> question1 = new List<GUIElement>();
		List<GUIElement> intro1 = new List<GUIElement>();
		List<GUIElement> end1 = new List<GUIElement>();


		public Questions ()
		{
			question1.Add (new GUIElement ("Cross-Screen/Island-bg"));
			question1.Add (new GUIElement ("cluster1/cluster1-questions"));

			question1.Add (new GUIElement ("cluster1/answer1"));
			question1.Add (new GUIElement ("cluster1/answer1-right"));
			question1.Add (new GUIElement ("cluster1/answer2"));
			question1.Add (new GUIElement ("cluster1/answer2-wrong"));
			question1.Add (new GUIElement ("cluster1/answer3"));
			question1.Add (new GUIElement ("cluster1/answer3-wrong"));
			question1.Add (new GUIElement ("cluster1/answer4"));
			question1.Add (new GUIElement ("cluster1/answer4-wrong"));

			end1.Add (new GUIElement ("Cross-Screen/Island-bg"));

			end1.Add (new GUIElement ("cluster1/congratulations"));
			intro1.Add (new GUIElement ("Cross-Screen/Island-bg"));

			intro1.Add (new GUIElement ("cluster1/sailor"));

//			question4.Add (new GUIElement ("cluster4/answer1"));
//			question4.Add (new GUIElement ("cluster4/answer1-right"));
//			question4.Add (new GUIElement ("cluster4/answer2"));
//			question4.Add (new GUIElement ("cluster4/answer2-wrong"));
//			question4.Add (new GUIElement ("cluster4/answer3"));
//			question4.Add (new GUIElement ("cluster4/answer3-wrong"));
//			question4.Add (new GUIElement ("cluster4/answer4"));
//			question4.Add (new GUIElement ("cluster4/answer4-wrong"));

		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in intro1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			intro1.Find (x => x.AssetName == "cluster1/sailor").PutBg ();

			foreach (GUIElement element in question1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}

			question1.Find (x => x.AssetName == "cluster1/answer1").moveElement (930,405);
			question1.Find (x => x.AssetName == "cluster1/answer1-right").moveElement (930,405);
			question1.Find (x => x.AssetName == "cluster1/answer2").moveElement (930,535);
			question1.Find (x => x.AssetName == "cluster1/answer2-wrong").moveElement (930,535);
			question1.Find (x => x.AssetName == "cluster1/answer3").moveElement(930,665);
			question1.Find (x => x.AssetName == "cluster1/answer3-wrong").moveElement(930,665);
			question1.Find (x => x.AssetName == "cluster1/answer4").moveElement (930,800);
			question1.Find (x => x.AssetName == "cluster1/answer4-wrong").moveElement(930,800);

			foreach (GUIElement element in end1) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			end1.Find (x => x.AssetName == "cluster1/congratulations").PutBg ();

		}

		public void Update(GameObjects gameObjects)
		{			
			switch (screens) {
			case Screen.Cluster_1I:
				foreach (GUIElement element in intro1) {
					element.Update (gameObjects);
				}
				break;
			case Screen.Cluster_1Q:
				foreach (GUIElement element in question1) {
					element.Update (gameObjects);
				}
				break;
			case Screen.Cluster_1E:
				foreach (GUIElement element in end1) {
					element.Update (gameObjects);
				}
				break;
			default:
				break;
			}
			if (screens==Screen.Cluster_1Q||screens==Screen.Cluster_1I) {
				if (gameObjects.touchInput.swippedLeft) {
					screens = Screen.Cluster_1Q;
				}
				if(gameObjects.touchInput.swippedRight){
					screens = Screen.Cluster_1I;
				}
			}

		}
		public void Draw(SpriteBatch spriteBatch)
		{
			switch (screens) {
			case Screen.Cluster_1I:
				foreach (GUIElement element in intro1) {
					element.Draw (spriteBatch);
				}
				break;
			case Screen.Cluster_1Q:
				foreach (GUIElement element in question1) {
					if (element.AssetName=="Cross-Screen/Island-bg"||element.AssetName=="cluster1/cluster1-questions"||element.AssetName=="cluster1/answer1") {
						element.Draw (spriteBatch);
					}

					if (element.AssetName=="cluster1/answer2"&&wrong2==false) {
						element.Draw (spriteBatch);
					}
					if (element.AssetName=="cluster1/answer2-wrong"&&wrong2) {
						element.Draw (spriteBatch);
					}

					if (element.AssetName=="cluster1/answer3"&&wrong3==false) {
						element.Draw (spriteBatch);
					}
					if (element.AssetName=="cluster1/answer3-wrong"&&wrong3) {
						element.Draw (spriteBatch);
					}

					if (element.AssetName=="cluster1/answer4"&&wrong4==false) {
						element.Draw (spriteBatch);
					}
					if (element.AssetName=="cluster1/answer4-wrong"&&wrong4) {
						element.Draw (spriteBatch);
					}

				}
				break;
			case Screen.Cluster_1E:
				foreach (GUIElement element in end1) {
					element.Draw (spriteBatch);
				}
				break;
			default:
				break;
			}
		}

		public void OnClick(string element)
		{
			if (element=="cluster1/answer1") {
				screens = Screen.Cluster_1E;
			}
			if (element=="cluster1/answer2") {
				wrong2 = true;
			}
			if (element=="cluster1/answer3") {
				wrong3 = true;
			}
			if (element=="cluster1/answer4") {
				wrong4 = true;
			}
			if (element=="cluster1/congratulations") {
				vraag1 = true;
			}
		}
	}
}

