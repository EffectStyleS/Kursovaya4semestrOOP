

namespace sf_c_sharp
{
    class FAQButton : Button
    {
        public delegate void MethodFAQ();
        public event MethodFAQ OpenFAQ;

        public FAQButton(string F) : base(F)
        {
            IsClickable = true;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y + 90;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            OpenFAQ();
        }
    }
}
