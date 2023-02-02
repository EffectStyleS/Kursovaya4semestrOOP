
namespace sf_c_sharp
{
    class StartButton : Button
    {
        public delegate void MethodStart();
        public event MethodStart StartGame;

        public StartButton(string F) : base(F)
        { 
            IsClickable = true;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y - 240;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            StartGame();
        }
    }
}
