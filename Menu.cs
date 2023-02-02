using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace sf_c_sharp
{
    class Menu
    {
        public delegate void MethodMakeWorld(int whichMap, int numberOfLaps);
        public event MethodMakeWorld MakeWorld;

        public delegate Text MethodTakeText();
        public event MethodTakeText TakeText;

        public delegate int MethodTakeTime();
        public event MethodTakeTime TakeTime;

        private string file;
        private Image image;
        private Texture texture;
        private Sprite background;

        private Button[] buttons;
        private int buttonsQuantity;
        private int pressedButton;
        private Text text;

        private int whichMap;
        private int numberOfLapsOfMap;

        private readonly RenderWindow window;

        public bool IsOpen { get; set; }
        public bool IsMenuMaked { get; set; }
        public int MenuType { get; set; }

        public Menu(string F)
        {
            file = F;
            string path = Directory.GetCurrentDirectory();
            if (path.IndexOf("Release") == -1)
            {
                path = path.Remove(path.Length - 5);
            }
            else path = path.Remove(path.Length - 7);
            image = new Image(path + "Content\\Textures\\" + file);
            texture = new Texture(image);
            background = new Sprite(texture);
            IsOpen = true;
            whichMap = 1;
            numberOfLapsOfMap = 1;
            MenuType = 0;
            window = Source.Window;
        }

        public void MakeMenu()
        {
            if(!IsMenuMaked)
            {
                StartButton startButton;
                SaveButton saveButton;
                LoadButton loadButton;
                ChooseMapButton mapButton1;
                ChooseMapButton mapButton2;
                FAQButton faqButton;
                ExitButton exitButton;
                ResumeButton resumeButton;
                MainMenuButton mainMenuButton;
                ButtonMinus chooseLapsMinus;
                ButtonPlus chooseLapsPlus;
                ChooseLapsButton chooseLaps;

                Vector2f vectorTextPos;

                switch (MenuType)
                {
                    case 0:

                        text = TakeText();
                        text.Color = new Color(16, 93, 51);
                        text.CharacterSize = 40;
                        text.DisplayedString = "2D Racer";

                        buttonsQuantity = 10;
                        buttons = new Button[buttonsQuantity];

                        startButton = new StartButton("ButtonStart.png");
                        startButton.StartGame += StartGameMethod;
                        buttons[0] = startButton;

                        saveButton = new SaveButton("ButtonSave.png");
                        saveButton.SaveGame += SaveAll;
                        buttons[1] = saveButton;

                        loadButton = new LoadButton("ButtonLoad.png");
                        loadButton.LoadGame += LoadAll;
                        buttons[2] = loadButton;

                        mapButton1 = new ChooseMapButton("ButtonMap1.png", 0);
                        mapButton1.ChooseMap += ChoosingMap;
                        buttons[3] = mapButton1;

                        mapButton2 = new ChooseMapButton("ButtonMap2.png", 1);
                        mapButton2.ChooseMap += ChoosingMap;
                        buttons[4] = mapButton2;

                        chooseLapsMinus = new ButtonMinus("ButtonMinus.png");
                        chooseLapsMinus.MinusLap += MinusLap;
                        buttons[5] = chooseLapsMinus;

                        chooseLaps = new ChooseLapsButton("ButtonLap.png");
                        chooseLaps.ReturnNumberOfLapsOfMap += ReturnNumberOfLapsOfMap;
                        buttons[6] = chooseLaps;

                        chooseLapsPlus = new ButtonPlus("ButtonPlus.png");
                        chooseLapsPlus.PlusLap += PlusLap;
                        buttons[7] = chooseLapsPlus;

                        faqButton = new FAQButton("ButtonFAQ.png");
                        faqButton.OpenFAQ += OpenFAQ;
                        buttons[8] = faqButton;

                        exitButton = new ExitButton("ButtonExit.png");
                        exitButton.ExitGame += CloseAll;
                        buttons[9] = exitButton;

                        vectorTextPos = new Vector2f(buttons[0].X - 10, buttons[0].Y - 60);
                        text.Position = vectorTextPos;

                        break;

                    case 1:

                        text = TakeText();
                        text.Color = new Color(16, 93, 21);
                        text.CharacterSize = 40;
                        text.DisplayedString = "2D Racer";

                        buttonsQuantity = 6;
                        buttons = new Button[buttonsQuantity];

                        resumeButton = new ResumeButton("ButtonResume.png");
                        resumeButton.ResumeGame += CloseMenu;
                        buttons[0] = resumeButton;

                        saveButton = new SaveButton("ButtonSave.png");
                        saveButton.SaveGame += SaveAll;
                        buttons[1] = saveButton;
                        buttons[1].IsClickable = true;

                        loadButton = new LoadButton("ButtonLoad.png");
                        loadButton.LoadGame += LoadAll;
                        buttons[2] = loadButton;

                        mainMenuButton = new MainMenuButton("ButtonMain.png");
                        mainMenuButton.ToMainMenu += ToMainMenu;
                        buttons[3] = mainMenuButton;

                        faqButton = new FAQButton("ButtonFAQ.png");
                        faqButton.OpenFAQ += OpenFAQ;
                        buttons[4] = faqButton;

                        exitButton = new ExitButton("ButtonExit.png");
                        exitButton.ExitGame += CloseAll;
                        buttons[5] = exitButton;

                        vectorTextPos = new Vector2f(buttons[0].X - 10, buttons[0].Y - 60);
                        text.Position = vectorTextPos;

                        break;
                    case 2:
                        buttonsQuantity = 1;
                        buttons = new Button[buttonsQuantity];

                        text = TakeText();
                        int time = TakeTime();

                        mainMenuButton = new MainMenuButton("ButtonMain.png");
                        mainMenuButton.ToMainMenu += ToMainMenu;
                        buttons[0] = mainMenuButton;

                        text.Color = new Color(16, 93, 21);
                        text.CharacterSize = 40;
                        text.DisplayedString ="2D Racer\n" + "Time: " + time + "s";
                        vectorTextPos = new Vector2f(buttons[0].X, buttons[0].Y - 120);
                        text.Position = vectorTextPos;
                        break;
                    case 3:
                        buttonsQuantity = 1;
                        buttons = new Button[buttonsQuantity];

                        text = TakeText();
                        text.Color = new Color(0, 0, 0);
                        text.CharacterSize = 20;
                        mainMenuButton = new MainMenuButton("ButtonMain.png");
                        mainMenuButton.ToMainMenu += ToMainMenu;
                        buttons[0] = mainMenuButton;

                        text.DisplayedString =
                            "Правила игры: \n" +
                            "Для начала игры нужно выбрать трассы с помощью кнопок Map 1 и Map 2 \n" +
                            "и количество кругов от 1 до 5 с помощью кнопок + и - \n" +
                            "Нажать кнопку Start \n\n" +
                            "Для окночания игры нужно как можно быстрее проехать выбранное количество кругов \n" +
                            "По завершении игры на экран выведется время прохождения трассы и кнопка возврата в главное меню \n" +
                            "\n\n\n\n\n\n\n\n\n\n\n\n" +
                            "                                                                                                                                                         О программе: \n" +
                            "                                                                                                                                                         Автор - Васильев Сергей \n" +
                            "                                                                                                                                                         Все права защищены";
                        vectorTextPos = new Vector2f(buttons[0].X - 500, buttons[0].Y - 300);
                        text.Position = vectorTextPos;
                        break;


                }
                IsMenuMaked = true;
            }
        }

        public void Draw()
        {
            window.Draw(background);
            for (int i = 0; i < buttonsQuantity; i++)
                buttons[i].Draw();
            window.Draw(text);
            

        }

        public void Work()
        {
            for (int i = 0; i < buttonsQuantity; i++)
                if (Mouse.GetPosition().X > buttons[i].X + buttons[i].offsetX
                    && Mouse.GetPosition().X < buttons[i].X + buttons[i].offsetX + buttons[i].W
                    && Mouse.GetPosition().Y > buttons[i].Y + buttons[i].offsetY
                    && Mouse.GetPosition().Y < buttons[i].Y + buttons[i].offsetY + buttons[i].H
                    && Mouse.IsButtonPressed(Mouse.Button.Left) && buttons[i].IsClickable)
                {
                    pressedButton = i;
                    buttons[i].Work();
                }
        }
        public void SaveLoad(ref World world)
        {
            for (int i = 0; i < buttonsQuantity; i++)
                if (Mouse.GetPosition().X > buttons[i].X + buttons[i].offsetX
                    && Mouse.GetPosition().X < buttons[i].X + buttons[i].offsetX + buttons[i].W
                    && Mouse.GetPosition().Y > buttons[i].Y + buttons[i].offsetY
                    && Mouse.GetPosition().Y < buttons[i].Y + buttons[i].offsetY + buttons[i].H
                    && Mouse.IsButtonPressed(Mouse.Button.Left))
                    buttons[i].SaveLoad(ref world);
        }

        public void StartGameMethod()
        {
            IsOpen = false;
            IsMenuMaked = false;
            MakeWorld(whichMap, numberOfLapsOfMap);
        }
        public void CloseMenu()
        {
            IsMenuMaked = false;
            IsOpen = false;
        }

        public void ChoosingMap()
        {
            switch(pressedButton)
            {
                case 3:
                    buttons[3].IsClicked = true;
                    buttons[4].IsClicked = false;
                    whichMap = 1;
                    break;
                case 4:
                    buttons[4].IsClicked = true;
                    buttons[3].IsClicked = false;
                    whichMap = 2;
                    break;

            }
        }

        public void MinusLap()
        {
            if (numberOfLapsOfMap <= 2)
            {
                buttons[5].IsClickable = false;
                numberOfLapsOfMap--;
                buttons[7].IsClickable = true;
            }
            else
            {
                buttons[7].IsClickable = true;
                numberOfLapsOfMap--;
                Thread.Sleep(100);
                buttons[5].IsClickable = true;
            }
        }

        public void PlusLap()
        {
            if (numberOfLapsOfMap >= 4)
            {
                buttons[5].IsClickable = true;
                numberOfLapsOfMap++;
                buttons[7].IsClickable = false;
            }
            else
            {
                buttons[5].IsClickable = true;
                numberOfLapsOfMap++;
                Thread.Sleep(100);
                buttons[7].IsClickable = true;
            }    
        }

        public void CloseAll()
        {
            IsMenuMaked = false;
            IsOpen = false;
            window.Close();
        }

        public void ToMainMenu()
        {
            Thread.Sleep(100);
            IsMenuMaked = false;
            MenuType = 0;
        }

        public void OpenFAQ()
        {
            IsMenuMaked = false;
            MenuType = 3;
            MakeMenu();
        }

        public void SaveAll(ref World world)
        {
            FileStream stream = File.Create("SaveData.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, world);
            stream.Close();
        }

        public void LoadAll(ref World world)
        {
            FileStream stream = File.OpenRead("SaveData.dat");
            BinaryFormatter formatter = new BinaryFormatter();
            world = (World)formatter.Deserialize(stream);
            stream.Close();
            CloseMenu();
        }

        public int ReturnNumberOfLapsOfMap()
        {
            return numberOfLapsOfMap;
        }
    }
}
