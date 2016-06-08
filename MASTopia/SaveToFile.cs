using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using System.IO;

namespace MASTopia
{
	public class SaveToFile
	{
		public SaveToFile ()
		{
		}
		public void Save(GameObjects obj)
		{
			try {
				FileStream fs = new FileStream( "content/test.txt", FileMode.OpenOrCreate);  
				StreamWriter sw = new StreamWriter(fs);  
				sw.WriteLine(obj.cluster1);
				sw.WriteLine(obj.cluster2); 
				sw.WriteLine(obj.cluster3); 
				sw.WriteLine(obj.cluster4); 
				sw.WriteLine(obj.Gekozen); 

				sw.WriteLine(obj.Fish);
				sw.WriteLine(obj.Grains);
				sw.WriteLine(obj.Meat);
				sw.WriteLine(obj.Vegies);
		
				sw.WriteLine(obj.Money);
				sw.WriteLine(obj.PLayerLevel);
				sw.WriteLine(obj.XP);

				sw.WriteLine(obj.waste);
				sw.WriteLine(obj.Chemwaste);

				sw.Close();  
				fs.Close();
			} catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}
		public void Load(GameObjects obj)
		{
			try {
				FileStream fs = new FileStream( "content/test.txt",FileMode.Open);  
				StreamReader loads = new StreamReader(fs);
			
				obj.cluster1= bool.Parse(loads.ReadLine());

				obj.cluster2=bool.Parse(loads.ReadLine());
				obj.cluster3=bool.Parse(loads.ReadLine());
				obj.cluster4=bool.Parse(loads.ReadLine());
				obj.Gekozen=bool.Parse(loads.ReadLine());

				obj.Fish=int.Parse(loads.ReadLine());
				obj.Grains=int.Parse(loads.ReadLine());
				obj.Meat=int.Parse(loads.ReadLine());
				obj.Vegies=int.Parse(loads.ReadLine());

				obj.Money=int.Parse(loads.ReadLine());
				obj.PLayerLevel=int.Parse(loads.ReadLine());
				obj.XP=int.Parse(loads.ReadLine());

				obj.waste=int.Parse(loads.ReadLine());
				obj.Chemwaste=int.Parse(loads.ReadLine());


				loads.Close();  
				fs.Close();
			} catch (Exception ex) {
				Console.WriteLine (ex);

			}
		}
	}
}

