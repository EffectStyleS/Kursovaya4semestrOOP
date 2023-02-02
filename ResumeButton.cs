

namespace sf_c_sharp
{
    class ResumeButton : Button
    {
        public delegate void MethodResume();
        public event MethodResume ResumeGame;

        public ResumeButton(string F) : base(F)
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
            ResumeGame();
        }
    }
}
