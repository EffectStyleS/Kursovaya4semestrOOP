
namespace sf_c_sharp
{
    class ExitButton : Button
    {
        public delegate void MethodExit();
        public event MethodExit ExitGame;

        public ExitButton(string F) : base(F)
        {
            IsClickable = true;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y + 150;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            ExitGame();
        }
    }
}
