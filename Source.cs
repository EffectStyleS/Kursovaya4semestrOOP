using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics;
using System.IO;



namespace sf_c_sharp
{
	class Source
	{
        public static RenderWindow Window { get; set; }
		public static Camera camera { get; set; }

		private static Font font;
		private static Text text;

		private static Stopwatch stopwatch;
		private static Stopwatch gameTimeStopwatch;

		private static int gameTime = 0;
		private static int createObjectForMapTime = 0;

		private static World world;
		private static void Main(string[] args)
		{
			Window = new RenderWindow(new VideoMode(1280, 720), "2D RACER");
			Window.SetVerticalSyncEnabled(true);
			Window.SetFramerateLimit(30);

			View Cam = new View();
			camera = new Camera(Cam);

			camera.Cam.Reset(new FloatRect(0, 0, Window.Size.X, Window.Size.Y));

			stopwatch = new Stopwatch();
			gameTimeStopwatch = new Stopwatch();

			string path = Directory.GetCurrentDirectory();
			if (path.IndexOf("Release") == -1)
			{
				path = path.Remove(path.Length - 9);
			}
			else path = path.Remove(path.Length - 11);

			font = new Font(path + "MusticaproSemibold.otf");

			text = new Text("", font, 32)
			{
				Style = Text.Styles.Bold
			};
			Vector2f vectorTextPos;

			world = new World(1, 1);
			world.map.MakeTileMap();
			world.map.MakeObjects();

			Menu menu = new Menu("background.png");
			menu.MakeWorld += MakeWorld;
			menu.TakeText += ReturnText;
			menu.TakeTime += ReturnTime;

			Window.Closed += WinClosed;

			gameTimeStopwatch.Start();

			while (Window.IsOpen)
			{
				
				while(menu.IsOpen)
                {
					stopwatch.Stop();
					gameTimeStopwatch.Stop();
					camera.Cam.Reset(new FloatRect(0, 0, Window.Size.X, Window.Size.Y));
					camera.Cam.Center = new Vector2f(Window.Size.X / 2, Window.Size.Y / 2);
					Window.SetView(camera.Cam);
					Window.DispatchEvents();
					Window.Clear();
					menu.MakeMenu();
					menu.Draw();

					
					Window.Display();
					menu.SaveLoad(ref world);
					menu.Work();
				}
				stopwatch.Start();
				gameTimeStopwatch.Start();

				world.pc.SetView += camera.SetCarCoordinateForView;
				
				float time = (float)stopwatch.Elapsed.TotalSeconds;
				if (world.pc.Life)
					gameTime = (int)gameTimeStopwatch.Elapsed.TotalSeconds;
				else
				{
					gameTimeStopwatch.Stop();
					gameTime = (int)gameTimeStopwatch.Elapsed.TotalSeconds;
					menu.IsMenuMaked = false;
					menu.IsOpen = true;
					menu.MenuType = 2;
				}
				stopwatch.Restart();
				time /= 0.0008f;
			
				Window.DispatchEvents();

				if (world.pc.Life)
				{

					createObjectForMapTime += (int)time;
					if (createObjectForMapTime > 10000)
					{
						world.map.RandomMapGenerate();
						createObjectForMapTime = 0;
					}
				}
				
				world.map.InteractionWithMap(world.pc);
				world.pc.Update(time);
				
				world.map.InteractionWithMapUnsubscribe();
				
				Window.SetView(camera.Cam);
				Window.Clear(Color.Cyan);

				world.map.Draw();
				text.Color = new Color(255, 255, 255);
				text.CharacterSize = 32;
				text.DisplayedString = "Lap: " + world.pc.Currentlap;
				vectorTextPos = new Vector2f(camera.Cam.Center.X - (Window.Size.X / 2 - 20), camera.Cam.Center.Y - (Window.Size.Y / 2 - 10));
				text.Position = vectorTextPos;
				Window.Draw(text);

				world.pc.Draw();
				
				Window.Display();
				world.pc.SetView -= camera.SetCarCoordinateForView;

				if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
				{
					menu.IsMenuMaked = false;
					menu.IsOpen = true;
					menu.MenuType = 1;
				}
			}
		}

        private static void WinClosed(object sender, EventArgs e)
		{
			Window.Close();
		}

		private static void MakeWorld(int whichMap, int numberOfLaps)
		{
			world = new World(whichMap, numberOfLaps);
			world.map.MakeTileMap();
			world.map.MakeObjects();
			gameTimeStopwatch.Restart();
        }

		private static Text ReturnText()
        {
			return text;
        }

		private static int ReturnTime()
		{
			return gameTime;
		}
	}
}
