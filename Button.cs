using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Window;


namespace sf_c_sharp
{
    class Button
    {

        protected string file;
        protected Image image;
        protected Texture texture;
        protected Sprite sprite;

        protected RenderWindow window;
        protected Camera camera;

        public bool IsClickable { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float W { get; set; }
        public float H { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public bool IsClicked { get; set; }

        public Button(string F)
        {
            file = F;
            string path = Directory.GetCurrentDirectory();
            if (path.IndexOf("Release") == -1)
            {
                path = path.Remove(path.Length - 5);
            }
            else path = path.Remove(path.Length - 7);
            image = new Image(path + "Content\\Buttons\\" + file);
            texture = new Texture(image);
            sprite = new Sprite(texture);
            window = Source.Window;
            camera = Source.camera;
            offsetX = 325;
            offsetY = 205;
            W = 150;
            H = 40;
        }

        public virtual void Draw() 
        {
            Vector2f vectorPos = new Vector2f(X, Y);
            sprite.Position = vectorPos;
            if(IsClicked == true)
            {
                IntRect textureRect = new IntRect(0, 80, 150, 40);
                sprite.TextureRect = textureRect;
            }
            else 
                if (IsClickable)
                {
                    if (Mouse.GetPosition().X > X + offsetX && Mouse.GetPosition().X < X + offsetX + W
                        && Mouse.GetPosition().Y > Y + offsetY && Mouse.GetPosition().Y < Y + offsetY + H && Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        IntRect textureRect = new IntRect(0, 80, 150, 40);
                        sprite.TextureRect = textureRect;
                    }
                    else
                        if (Mouse.GetPosition().X > X + offsetX && Mouse.GetPosition().X < X + offsetX + W
                            && Mouse.GetPosition().Y > Y + offsetY && Mouse.GetPosition().Y < Y + offsetY + H)
                        {
                            IntRect textureRect = new IntRect(0, 40, 150, 40);
                            sprite.TextureRect = textureRect;
                        }
                    else
                    {
                        IntRect textureRect = new IntRect(0, 0, 150, 40);
                        sprite.TextureRect = textureRect;
                    }
                }
                else
                {
                    IntRect textureRect = new IntRect(0, 120, 150, 40);
                    sprite.TextureRect = textureRect;

                }
            window.Draw(sprite);
        }
        public virtual void Work() { }
        public virtual void SaveLoad(ref World world) { }

    }
}
