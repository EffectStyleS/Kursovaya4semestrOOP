

namespace sf_c_sharp
{
    class ButtonPlus : Button
    {

        public delegate void MethodPlusLap();
        public event MethodPlusLap PlusLap;

        public ButtonPlus(string F) : base(F)
        {
            IsClickable = true;
            X = camera.Cam.Center.X + 85;
            Y = camera.Cam.Center.Y + 20;
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            PlusLap();
        }
    }
}
