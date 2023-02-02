
namespace sf_c_sharp
{
    class SaveButton : Button
    {

        public delegate void MethodSave(ref World world);
        public event MethodSave SaveGame;

        public SaveButton(string F) : base(F)
        {
            IsClickable = false;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y - 180;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Work()
        {
            //SaveGame();
        }

        public override void SaveLoad(ref World world)
        {
            SaveGame(ref world);
        }

    }
}
