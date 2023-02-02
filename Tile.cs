using SFML.Graphics;
using System;
using System.IO;
using System.Runtime.Serialization;


namespace sf_c_sharp
{
    [Serializable]
    public class Tile : IDeserializationCallback
    {

        private readonly char tileSymbol;
        protected string file;
        [NonSerialized] protected Image image;
        [NonSerialized] protected Texture texture;
        [NonSerialized] protected Sprite sprite;

        [NonSerialized] protected RenderWindow window;

        public char TileSymbol { get => tileSymbol; }

        public Tile(string F, char TILESYMBOL)
        {
            file = F;
            string path = Directory.GetCurrentDirectory();
            if(path.IndexOf("Release") == -1)
            {
                path = path.Remove(path.Length - 5);
            }
            else path = path.Remove(path.Length - 7);
            image = new Image(path + "Content\\Textures\\" + file);
            texture = new Texture(image);
            sprite = new Sprite(texture);
            window = Source.Window;
            tileSymbol = TILESYMBOL;
        }

        public virtual void Work(Car car) { }
        public virtual void DrawTile(int i, int j) { }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            window = Source.Window;
            string path = Directory.GetCurrentDirectory();
            if (path.IndexOf("Release") == -1)
            {
                path = path.Remove(path.Length - 5);
            }
            else path = path.Remove(path.Length - 7);
            image = new Image(path + "Content\\Textures\\" + file);
            texture = new Texture(image);
            sprite = new Sprite(texture);
        }

    }
}
