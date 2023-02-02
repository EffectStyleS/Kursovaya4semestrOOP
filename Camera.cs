using SFML.Graphics;
using SFML.System;




namespace sf_c_sharp
{
    class Camera
    {
        public Camera(View CAM)
        {
            Cam = CAM;
        }

        public View Cam { get; set; }

        public View SetCarCoordinateForView(float x, float y)
        {
            float tempX = x, tempY = y;

            if (x < Source.Window.Size.X / 2) tempX = Source.Window.Size.X / 2;
            if (y < Source.Window.Size.Y / 2) tempY = Source.Window.Size.Y / 2;

            Vector2f vectorView = new Vector2f(tempX, tempY);

            Cam.Center = vectorView;

            return Cam;
        }

    }
}
