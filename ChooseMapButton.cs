

namespace sf_c_sharp
{
    class ChooseMapButton : Button
    {
        public delegate void MethodChooseMap();
        public event MethodChooseMap ChooseMap;

        private int numberOfButton;
        public ChooseMapButton(string F, int numberOfButton) : base(F)
        {
            IsClickable = true;
            this.numberOfButton = numberOfButton;
            switch(this.numberOfButton)
            {
                case (0): X = camera.Cam.Center.X - 165; break;
                case (1): X = camera.Cam.Center.X + 5; break;
            }
            Y = camera.Cam.Center.Y - 60;
        }

        public override void Work()
        {
            ChooseMap();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
