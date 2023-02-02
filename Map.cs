using System;


namespace sf_c_sharp
{
	[Serializable]
	public class Map
	{

		private int numberOfMap;
		private int heightMap;
		private int widthMap;
		private string[] TileMap;
		private Tile[,] tiles;
		public int NumberOfLaps { get; set; }

		public delegate void MethodInteraction(Car car);
		public event MethodInteraction Touch;

		public Map(int numberOfMap, int numberOfLaps) : base()
		{
			this.NumberOfLaps = numberOfLaps;

			this.numberOfMap = numberOfMap;
			switch (numberOfMap)
			{
				case 1:
					heightMap = 42;
					widthMap = 52;
					break;
				case 2:
					heightMap = 87;
					widthMap = 100;
					break;
					//параметры других карт
			}
			TileMap = new string[heightMap];

		}

		public void MakeTileMap()
		{
			switch (numberOfMap)
			{
				case 1:
					TileMap[0] =  "1111111111111111111111111111111111111111111111111111";
					TileMap[1] =  "1000000000000000000000000000000000000000000000000001";
					TileMap[2] =  "10                                                01";
					TileMap[3] =  "10 RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR 01";
					TileMap[4] =  "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[5] =  "10 YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[6] =  "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[7] =  "10 RAAAAARRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRAAAAAR 01";
					TileMap[8] =  "10 YAAAAAR                                RAAAAAY 01";
					TileMap[9] =  "10 YAAAAAY                                YAAAAAY 01";
					TileMap[10] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[11] = "10 RWBWBWR                                RAAAAAR 01";
					TileMap[12] = "10 YBWBWBY                                YAAAAAY 01";
					TileMap[13] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[14] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[15] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[16] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[17] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[18] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[19] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[20] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[21] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[22] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[23] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[24] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[25] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[26] = "10 RAAAAAR                                RCCCCCR 01";
					TileMap[27] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[28] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[29] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[30] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[31] = "10 RAAAAAR                                RAAAAAR 01";
					TileMap[32] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[33] = "10 YAAAAAY                                YAAAAAY 01";
					TileMap[34] = "10 RAAAAAYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYAAAAAR 01";
					TileMap[35] = "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[36] = "10 YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[37] = "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[38] = "10 RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR 01";
					TileMap[39] = "10                                                01";
					TileMap[40] = "1000000000000000000000000000000000000000000000000001";
					TileMap[41] = "1111111111111111111111111111111111111111111111111111";
					break;
				case 2:
					TileMap[0] =  "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
					TileMap[1] =  "1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
					TileMap[2] =  "10                                                                                                01";
					TileMap[3] =  "10 RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRY                                YRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR 01";
					TileMap[4] =  "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY                                YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[5] =  "10 YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR                                RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[6] =  "10 YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR                                RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[7] =  "10 RAAAAARRYYRRYYRRYYRRYYRRYYRAAAY                                YAAARRYYRRYYRRYYRRYYRRYYRRYAAAR 01";
					TileMap[8] =  "10 RAAAAAY                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[9] =  "10 YAAAAAY                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[10] = "10 YAAAAAR                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[11] = "10 RWBWBWR                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[12] = "10 YBWBWBY                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[13] = "10 YAAAAAY                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[14] = "10 RAAAAAR                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[15] = "10 RAAAAAR                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[16] = "10 YAAAAAY                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[17] = "10 YAAAAAY                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[18] = "10 RAAAAAR                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[19] = "10 RAAAAAR                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[20] = "10 YAAAAAY                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[21] = "10 YAAAAAY                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[22] = "10 RAAAAAR                   YAAAR                                RAAAY                     RAAAY 01";
					TileMap[23] = "10 RAAAAAR                   RAAAY                                YAAAR                     YAAAR 01";
					TileMap[24] = "10 YAAAAAY                   RAAAYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYAAAR                     YAAAR 01";
					TileMap[25] = "10 RAAAAAY                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY                     RAAAY 01";
					TileMap[26] = "10 RAAAAAR                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY                     RAAAY 01";
					TileMap[27] = "10 YAAAAAR                   RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR                     YAAAR 01";
					TileMap[28] = "10 YAAAAAY                   RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR                     YAAAR 01";
					TileMap[29] = "10 RAAAAAY                                                                                  RAAAY 01";
					TileMap[30] = "10 RAAAAAR                   000000000000000000000000000000000000000000                     RAAAY 01";
					TileMap[31] = "10 YAAAAAR                   RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYAAAR 01";
					TileMap[32] = "10 YAAAAAY                   RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[33] = "10 RAAAAAY                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[34] = "10 RAAAAAR                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[35] = "10 YAAAAAR                   RAAAYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR 01";
					TileMap[36] = "10 YAAAAAY                   RAAAY                                                                01";
					TileMap[37] = "10 RAAAAAY                   YAAAR                                                                01";
					TileMap[38] = "10 RAAAAAR                   YAAAR                                                                01";
					TileMap[39] = "10 YAAAAAR                   RAAAY                                                                01";
					TileMap[40] = "10 YAAAAAY                   RAAAY                                                                01";
					TileMap[41] = "10 RAAAAAY                   YAAAR                                                                01";
					TileMap[42] = "10 RAAAAAR                   YAAAR                                                                01";
					TileMap[43] = "10 YAAAAAR                   RAAAY                                                                01";
					TileMap[44] = "10 YAAAAAY                   RAAAYYRRYYRRYYRRYYRR           YRRRYYRRYYR                           01";
					TileMap[45] = "10 RAAAAAY                   YAAAAAAAAAAAAAAAAAAY           YAAAAAAAAAR                           01";
					TileMap[46] = "10 RAAAAAR                   YAAAAAAAAAAAAAAAAAAY           RAAAAAAAAAY                           01";
					TileMap[47] = "10 YAAAAAR                   RAAAAAAAAAAAAAAAAAAR           RAAAAAAAAAY                           01";
					TileMap[48] = "10 YAAAAAY                   RRYYRRYYRRYYRRYYAAARYYRRYYRRYYRRAAAYRYAAARRYYRRYYRRYYRRYYRRYYRRYYRRY 01";
					TileMap[49] = "10 RAAAAAY                   0              YAAAAAAAAAAAAAAAAAAAY RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[50] = "10 RAAAAAR                   0              RAAAAAAAAAAAAAAAAAAAR RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[51] = "10 YAAAAAR                   0              RYYRRYYRRYYRRYYRRYYRR YYRRYYRRYYRRYYRRYYRRYYRRYAAAAAR 01";
					TileMap[52] = "10 YAAAAAY                   0                                                            YAAAAAY 01";
					TileMap[53] = "10 RAAAAAY                   0000000000000000000000000000000000000000000000000000000000000RAAAAAY 01";
					TileMap[54] = "10 RAAAAAR                   RRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRAAAAAR 01";
					TileMap[55] = "10 YAAAAAR                   RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[56] = "10 RAAAAAY                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[57] = "10 RAAAAAY                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[58] = "10 YAAAAAR                   RAAAAYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRR 01";
					TileMap[59] = "10 YAAAAAR                   RAAAAY                                                               01";
					TileMap[60] = "10 RAAAAAY                   YAAAAR                                                               01";
					TileMap[61] = "10 YAAAAAR                   RAAAAY                                                               01";
					TileMap[62] = "10 YAAAAAY                   RAAAAY                                                               01";
					TileMap[63] = "10 RAAAAAY                   YAAAAR                                                               01";
					TileMap[64] = "10 RAAAAAY                   YAAAAR                                                               01";
					TileMap[65] = "10 RAAAAAR                   RAAAAR                                                               01";
					TileMap[66] = "10 YAAAAAR                   RAAAAYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYR 01";
					TileMap[67] = "10 YAAAAAY                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAY 01";
					TileMap[68] = "10 RAAAAAY                   RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAY 01";
					TileMap[69] = "10 RAAAAAR                   RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAR 01";
					TileMap[70] = "10 YAAAAAR                   YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAAAAAAR 01";
					TileMap[71] = "10 YAAAAAY                   YYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYAAY 01";
					TileMap[72] = "10 RAAAAAY                                                                                   YAAY 01";
					TileMap[73] = "10 RAAAAAR                                                                                   RAAR 01";
					TileMap[74] = "10 YAAAAAR                                                                                   RAAR 01";
					TileMap[75] = "10 YAAAAAY                                                                                   YAAY 01";
					TileMap[76] = "10 RAAAAAY                                                                                   YAAY 01";
					TileMap[77] = "10 RAAAAAR                                                                                   RAAR 01";
					TileMap[78] = "10 YAAAAAR                                                                                   YAAR 01";
					TileMap[79] = "10 YAAAAAYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRYYAAY 01";
					TileMap[80] = "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY 01";
					TileMap[81] = "10 RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[82] = "10 YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR 01";
					TileMap[83] = "10 YYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYYRRYY 01";
					TileMap[84] = "10                                                                                                01";
					TileMap[85] = "1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
					TileMap[86] = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
					break;
			}
		}

		public void MakeObjects()
		{
			tiles = new Tile[heightMap, widthMap];
			for (int i = 0; i < heightMap; i++)
				for (int j = 0; j < widthMap; j++)
				{
					switch (TileMap[i][j])
					{
						case 'A':
							tiles[i, j] = new Asphalt("asphalt.png", 'A');
							break;

						case 'C':
							tiles[i, j] = new Checkpoint("asphalt.png", 'C');
							break;

						case 'R':
							tiles[i, j] = new Kerb("red.png", 'R');
							break;

						case 'Y':
							tiles[i, j] = new Kerb("yellow.png", 'Y');
							break;

						case ' ':
							tiles[i, j] = new Grass("grass.png", ' ');
							break;

						case 'W':
							Finish finishw = new Finish("white.png", 'W');
							tiles[i, j] = finishw;
							finishw.ReturnMap += ReturnNumberOfLaps;
							break;

						case 'B':
							Finish finishb = new Finish("black.png", 'B');
							tiles[i, j] = finishb;
							finishb.ReturnMap += ReturnNumberOfLaps;
							break;

						case '0':
							tiles[i, j] = new Brick("brick.png", '0');
							break;

						case '1':
							tiles[i, j] = new Respawn("brick.png", '1');
							break;

						case 'E':
							tiles[i, j] = new LightBonus("lightbonus.png", 'E');
							break;
						case 'S':
							tiles[i, j] = new StopBonus("stopbonus.png", 'S');
							break;
						case 'Q':
							tiles[i, j] = new QuestBonusGood("questbonus.png", 'Q');
							break;
						case 'q':
							tiles[i, j] = new QuestBonusBad("questbonus.png", 'q');
							break;

					}

				}
		}

		public void Draw()
		{

			for (int i = 0; i < heightMap; i++)
				for (int j = 0; j < widthMap; j++)
				{
					tiles[i, j].DrawTile(i, j);
				}

		}

		public void RandomMapGenerate()
		{
			int randomElementX;
			int randomElementY;

			Random rand = new Random();

			int countBoost = 1;
			while (countBoost > 0)
			{
				randomElementX = rand.Next(0, widthMap - 3);
				randomElementY = rand.Next(0, heightMap - 3);

				if (tiles[randomElementY, randomElementX].TileSymbol == 'A')
				{
					Random which = new Random();
					int whichBonus = which.Next(0, 4);
					switch (whichBonus)
					{
						case 0:
							tiles[randomElementY, randomElementX] = new LightBonus("lightbonus.png", 'E');
							break;
						case 1:
							tiles[randomElementY, randomElementX] = new StopBonus("stopbonus.png", 'S');
							break;
						case 2:
							tiles[randomElementY, randomElementX] = new QuestBonusGood("questbonus.png", 'Q');
							break;
						case 3:
							tiles[randomElementY, randomElementX] = new QuestBonusBad("questbonus.png", 'q');
							break;
					}
					countBoost--;
				}
			}
		}

		public void InteractionWithMap(Car car)
        {
			for (int i = (int)car.Y / 40; i < (car.Y + car.H) / 40; i++)
				for (int j = (int)car.X / 40; j < (car.X + car.W) / 40; j++)
				{
					Touch += tiles[i, j].Work;
					Touch(car);
					if(tiles[i, j].TileSymbol == 'E' || tiles[i, j].TileSymbol == 'S'
						|| tiles[i, j].TileSymbol == 'Q' || tiles[i, j].TileSymbol == 'q') { tiles[i, j] = new Asphalt("asphalt.png", 'A'); }
				}
		}

		public void InteractionWithMapUnsubscribe()
        {
			Touch = null;
        }

		public int ReturnNumberOfLaps()
        {
			return NumberOfLaps;
        }
	}
}
