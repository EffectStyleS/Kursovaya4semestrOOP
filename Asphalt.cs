using SFML.Graphics;
using SFML.System;
using System;


namespace sf_c_sharp
{
	[Serializable]
	class Asphalt : Tile
	{
		public Asphalt(string F, char TILESYMBOL) : base(F, TILESYMBOL) { }

		public override void Work(Car car)
		{
			car.MaxSpeed = 0.5f;
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
