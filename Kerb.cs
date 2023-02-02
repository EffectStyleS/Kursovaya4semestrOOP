using SFML.Graphics;
using SFML.System;
using System;

namespace sf_c_sharp
{
	[Serializable]
	class Kerb : Tile
	{

		public Kerb(string F, char TILESYMBOL) : base(F, TILESYMBOL) { }


		public override void Work(Car car)
		{
			car.MaxSpeed = 0.35f;
			float maxSpeed = car.MaxSpeed;
			float speed = car.Speed;
			if (speed > maxSpeed)
				car.Speed = maxSpeed;
			if (speed < -maxSpeed)
				car.Speed = -maxSpeed;
		}

        public override void DrawTile(int i, int j)
        {
			Vector2f vectorPos = new Vector2f(j * 40, i * 40);
			sprite.Position = vectorPos;
			IntRect textureRect = new IntRect(0, 0, 40, 40);
			sprite.TextureRect = textureRect;
			window.Draw(sprite);
		}
    }
}
