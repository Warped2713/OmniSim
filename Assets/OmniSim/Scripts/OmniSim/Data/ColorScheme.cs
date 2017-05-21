using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OmniSim.Data {

	public class ColorScheme {

		[System.Serializable]
		public class Color {
			
			public string label;
			public int R;
			public int G;
			public int B;

			private Color32 color;

			public Color(string label, int r, int g, int b) {
				this.label = label;
				this.R = r;
				this.G = g;
				this.B = b;
				this.color = new UnityEngine.Color32((byte)r, (byte)g, (byte)b, (byte)255);
			}

			public void setColor32() {
				this.color = new Color32((byte)this.R, (byte)this.G, (byte)this.B, (byte)255);
			}

			public Color32 getColor32() {
				return this.color;
			}
		}

		[System.Serializable]
		public class Scheme {
			
			public string name;
			public string desc;
			public string series;
			public Color[] colors;

			public Scheme(string name, string desc, string series, Color[] colors) {
				this.name = name;
				this.desc = desc;
				this.series = series;
				this.colors = (colors != null) ? colors : new Color[] { new Color("Black", 0, 0, 0) };
			}

			public void setColor32() {
				if (this.colors != null) {
					for (int c = 0; c < this.colors.Length; c++) {
						this.colors [c].setColor32 ();
					}
				}
			}
		}

		[System.Serializable]
		public class ColorSchemeData {
			
			public Scheme[] schemes;

			public ColorSchemeData(Scheme[] schemes) { 
				this.schemes = (schemes != null) ? schemes : new Scheme[] { new Scheme(null, null, null, null) }; 
			}
		}

		public ColorSchemeData data; 

		public ColorScheme(ColorSchemeData data) {
			this.data = data;
		}

		public ColorScheme (string file, int maxColorSlot, int maxColorScheme) {
			TextAsset filedata = Resources.Load (file) as TextAsset;
			if (filedata) {
				this.data = JsonUtility.FromJson<ColorSchemeData> (filedata.text);

				if (this.data.schemes != null) {
					this.setColor32 ();
				} else {
					this.data = null;
				}
			} else {
				this.data = null;//new ColorSchemeData (null);
			}
		}

		private void setColor32() {
			for (int s = 0; s < this.data.schemes.Length; s++) {
				this.data.schemes [s].setColor32 ();
			}
		}

		public ColorScheme Copy() {
			Scheme[] schemes = new Scheme[this.data.schemes.Length];

			for (int s = 0; s < this.data.schemes.Length; s++) {
				schemes [s] = new Scheme ( 
					this.data.schemes[s].name, 
					this.data.schemes[s].desc, 
					this.data.schemes[s].series, 
					this.data.schemes[s].colors.Clone() as Color[]
				);
			}

			return new ColorScheme( new ColorSchemeData(schemes) );
		}

		public void SaveToFile(string file) {

			string json = JsonUtility.ToJson (data);

			file = "Assets/OmniSim/Resources/" + file + ".json";
			System.IO.File.WriteAllText (file, json, System.Text.Encoding.UTF8);

			/*if ( !System.IO.File.Exists (file) ) {
				file = "Assets/OmniSim/Resources/Data/ColorSchemes/Custom_Default.json";
				System.IO.File.WriteAllText (file, json, System.Text.Encoding.UTF8);
			} else {
				System.IO.File.WriteAllText (file, json, System.Text.Encoding.UTF8);
			}*/

		}

	}
}
