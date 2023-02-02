
namespace sf_c_sharp
{
    class LoadButton : Button
    {
        public delegate void MethodLoad(ref World world);
        public event MethodLoad LoadGame;

        public LoadButton(string F) : base(F)
        {
            //string path = Directory.GetCurrentDirectory();
            ////path += "CarData.dat";
            //if (File.Exists(path + "CarData.dat"))
            //{
            //    IsClickable = true;
            //}
            //else 
                IsClickable = true;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y - 120;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            //LoadGame();
        }

        public override void SaveLoad(ref World world)
        {
            LoadGame(ref world);
        }
    }
}
