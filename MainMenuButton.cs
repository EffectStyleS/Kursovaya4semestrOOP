

namespace sf_c_sharp
{
    class MainMenuButton : Button
    {
        public delegate void MethodToMainMenu();
        public event MethodToMainMenu ToMainMenu;
        public MainMenuButton(string F) : base(F)
        {
            IsClickable = true;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y - 60;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            ToMainMenu();
        }
    }
}
