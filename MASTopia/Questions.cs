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
		
		private bool wrong4 = false;
		private bool wrong2 = false;
		private bool wrong3 = false;


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


		List<GUIElement> question = new List<GUIElement>();
		List<GUIElement> intro = new List<GUIElement>();
		List<GUIElement> end = new List<GUIElement>();


		public Questions ()
		{
			question.Add (new GUIElement ("Cross-Screen/Island-bg"));
			question.Add (new GUIElement ("cluster1/cluster1-questions"));

			question.Add (new GUIElement ("cluster1/answer1"));
			question.Add (new GUIElement ("cluster1/answer1-right"));
			question.Add (new GUIElement ("cluster1/answer2"));
			question.Add (new GUIElement ("cluster1/answer2-wrong"));
			question.Add (new GUIElement ("cluster1/answer3"));
			question.Add (new GUIElement ("cluster1/answer3-wrong"));
			question.Add (new GUIElement ("cluster1/answer4"));
			question.Add (new GUIElement ("cluster1/answer4-wrong"));

			end.Add (new GUIElement ("Cross-Screen/Island-bg"));
			end.Add (new GUIElement ("cluster1/congratulations"));
			intro.Add (new GUIElement ("Cross-Screen/Island-bg"));

			intro.Add (new GUIElement ("cluster1/sailor"));
		}
		public void LoadContent(ContentManager content , GameObjects gameObjects)
		{
			foreach (GUIElement element in intro) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}

			foreach (GUIElement element in question) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}

			question.Find (x => x.AssetName == "cluster1/answer1").moveElement (930,405);
			question.Find (x => x.AssetName == "cluster1/answer1-right").moveElement (930,405);
			question.Find (x => x.AssetName == "cluster1/answer2").moveElement (930,535);
			question.Find (x => x.AssetName == "cluster1/answer2-wrong").moveElement (930,535);
			question.Find (x => x.AssetName == "cluster1/answer3").moveElement(930,665);
			question.Find (x => x.AssetName == "cluster1/answer3-wrong").moveElement(930,665);
			question.Find (x => x.AssetName == "cluster1/answer4").moveElement (930,800);
			question.Find (x => x.AssetName == "cluster1/answer4-wrong").moveElement(930,800);

			foreach (GUIElement element in end) {
				element.LoadContent (content, gameObjects);
				element.clickEvent += OnClick;
			}
			end.Find (x => x.AssetName == "cluster1/congratulations").PutBg ();

		}

		public void Update(GameObjects gameObjects)
		{			
			switch (screens) {
			case Screen.Cluster_1I:
				foreach (GUIElement element in intro) {
					element.Update (gameObjects);
				}
				break;
			case Screen.Cluster_1Q:
				foreach (GUIElement element in question) {
					element.Update (gameObjects);
				}
				break;
			case Screen.Cluster_1E:
				foreach (GUIElement element in end) {
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
				foreach (GUIElement element in intro) {
					element.Draw (spriteBatch);
				}
				break;
			case Screen.Cluster_1Q:
				foreach (GUIElement element in question) {
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
				foreach (GUIElement element in end) {
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

