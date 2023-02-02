
namespace sf_c_sharp
{
    class ButtonMinus : Button
    {
        public delegate void MethodMinusLap();
        public event MethodMinusLap MinusLap;

        public ButtonMinus(string F) : base(F)
        {
            IsClickable = false;
            X = camera.Cam.Center.X - 235;
            Y = camera.Cam.Center.Y + 20;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
           MinusLap();
        }

    }
}
