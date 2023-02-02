using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf_c_sharp
{
	[Serializable]
    class StopBonus : Tile
    {
		public StopBonus(string F, char TILESYMBOL) : base(F, TILESYMBOL) { }

		public override void Work(Car car)
		{
			car.Speed = 0.1f;
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
