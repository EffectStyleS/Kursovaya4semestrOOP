using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace sf_c_sharp
{
	[Serializable] 
	public class Car : Entity, IDeserializationCallback
	{
		private bool up;
		private bool down;
		private bool right;
		private bool left;

		public delegate View MethodView(float x, float y);
		public event MethodView SetView;

		public Car(string sFILE, float X, float Y, int W, int H, float MAXSPEED, float ACC, float TURNSPEED, float STOPPING, int Currentlap) : base(sFILE, X, Y, TURNSPEED, MAXSPEED, ACC, STOPPING, W, H)
		{
			Checkpoint = 0;
			this.Currentlap = Currentlap;
		}

		public int Checkpoint { get; set; }
		public int Currentlap { get; set; }

		private void Control()
        {
			{
				left = false; right = false; up = false; down = false;
				if (Life)
				{
					if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A)) { left = true; }
					if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D)) { right = true; }
					if (Keyboard.IsKeyPressed(Keyboard.Key.Up) || Keyboard.IsKeyPressed(Keyboard.Key.W)) { up = true; }
					if (Keyboard.IsKeyPressed(Keyboard.Key.Down) || Keyboard.IsKeyPressed(Keyboard.Key.S)) { down = true; }
				}
			}
		}
		public void Update(float time)
        {
			Control();
			if (up && Speed < MaxSpeed)
				if (Speed < 0) Speed += stopping;
				else Speed += acc;

			if (down && Speed > -MaxSpeed)
				if (Speed > 0) Speed -= stopping;
				else Speed -= acc;

			if (!up && !down)
				if (Speed - stopping > 0) Speed -= stopping;
				else if (Speed + stopping < 0) Speed += stopping;
				else Speed = 0;

			if (right && Speed != 0) angle += turnspeed * Speed / MaxSpeed;
			if (left && Speed != 0) angle -= turnspeed * Speed / MaxSpeed;


			X += (float)(Math.Sin(angle) * Speed * time);
			Y -= (float)(Math.Cos(angle) * Speed * time);

			Vector2f vectorCarPos = new Vector2f(X, Y);

			sprite.Position = vectorCarPos;
			sprite.Rotation = angle * 180 / 3.141593f; 

			if(Life) { SetView(X, Y); }
		}

        public void Draw()
        {
            window.Draw(sprite);
        }

		void IDeserializationCallback.OnDeserialization(object sender)
		{
			window = Source.Window;
			string path = Directory.GetCurrentDirectory();
			if (path.IndexOf("Release") == -1)
			{
				path = path.Remove(path.Length - 5);
			}
			else path = path.Remove(path.Length - 7);
			image = new Image(path + "Content\\Textures\\" + file);
			texture = new Texture(image);
			sprite = new Sprite(texture);
		}
	}
}
