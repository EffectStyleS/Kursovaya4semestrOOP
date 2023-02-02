using SFML.Graphics;
using SFML.System;


namespace sf_c_sharp
{
    class ChooseLapsButton : Button
    {
        public delegate int MethodReturnNumberOfLapsOfMap();
        public event MethodReturnNumberOfLapsOfMap ReturnNumberOfLapsOfMap;

        private int numberOfLapsOfMap;
        public ChooseLapsButton(string F) : base(F)
        {
            IsClickable = false;
            X = camera.Cam.Center.X - 75;
            Y = camera.Cam.Center.Y + 20;
        }

        public override void Draw()
        {
            Vector2f vectorPos = new Vector2f(X, Y);
            sprite.Position = vectorPos;
            numberOfLapsOfMap = ReturnNumberOfLapsOfMap();
            IntRect textureRect;
            switch (numberOfLapsOfMap)
            {
                case 1:
                    textureRect = new IntRect(0, 0, 150, 40);
                    sprite.TextureRect = textureRect;
                    break;
                case 2:
                    textureRect = new IntRect(0, 40, 150, 40);
                    sprite.TextureRect = textureRect;
                    break;
                case 3:
                    textureRect = new IntRect(0, 80, 150, 40);
                    sprite.TextureRect = textureRect;
                    break;
                case 4:
                    textureRect = new IntRect(0, 120, 150, 40);
                    sprite.TextureRect = textureRect;
                    break;
                case 5:
                    textureRect = new IntRect(0, 160, 150, 40);
                    sprite.TextureRect = textureRect;
                    break;
            }
            window.Draw(sprite);
        }
    }
}
