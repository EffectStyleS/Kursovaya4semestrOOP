using SFML.Graphics;
using System;
using System.IO;


namespace sf_c_sharp
{
	[Serializable]
	public class Entity 
	{
        protected float angle;
		protected float turnspeed;
		protected float acc;
		protected float stopping;
		protected int health;
		protected string file;
		[NonSerialized] protected Image image;
		[NonSerialized] protected Texture texture;
		[NonSerialized] protected Sprite sprite;
		[NonSerialized] protected RenderWindow window;

		public Entity(string sFILE, float x, float y, float TURNSPEED, float MAXSPEED, float ACC, float STOPPING, int w, int h)
		{
			X = x; Y = y; W = w; H = h;
			angle = 0; turnspeed = TURNSPEED; MaxSpeed = MAXSPEED;
			acc = ACC; stopping = STOPPING;
			Speed = 0; health = 100;
			Life = true;
			file = sFILE;
			string path = Directory.GetCurrentDirectory();
			if (path.IndexOf("Release") == -1)
			{
				path = path.Remove(path.Length - 5);
			}
			else path = path.Remove(path.Length - 7);
			image = new Image(path + "Content\\Textures\\" + file);
			texture = new Texture(image);
			sprite = new Sprite(texture);
			window = Source.Window;
		}

		public float X { get; set; }
		public float Y { get; set; }
		public float Speed { get; set; }
		public float MaxSpeed { get; set; }
		public int W { get; }
		public int H { get; }
		public bool Life { get; set; }
	}
}
