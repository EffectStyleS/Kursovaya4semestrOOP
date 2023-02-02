using System;

namespace sf_c_sharp
{
    [Serializable]
    public class World
    {
        public Car pc;
        public Map map;
        public World(int whichMap, int numberOfLaps)
        {
            pc = new Car("car.png", 240, 560, 43, 45, 0.5f, 0.0015f, 0.1f, 0.05f, 1);
            map = new Map(whichMap, numberOfLaps);
        }


    }
}
