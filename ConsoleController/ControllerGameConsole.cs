using ConsoleView;
using Controller;
using Model;
using System;

namespace ConsoleController
{
    public class ControllerGameConsole : ControllerGame
    {
        public ControllerGameConsole(ControllerMain parControllerMain, ModelGame parModelGame) : base(parControllerMain, parModelGame)
        {
            _viewGame = new ViewGameConsole(_modelGame);
            _modelGame.GameOver += () => { _controller.ChangeOnControllerRecordAdder(_modelGame.NumberKilledZombies); };
        }

        public override void Start()
        {
            _modelGame.StartGame();
            _viewGame.ShowView();
            StartHandlerKeyDownGame();
        }

        public override void Stop()
        {
            _modelGame.StopGame();
            _viewGame.CloseView();
        }

        private void StartHandlerKeyDownGame()
        {
            bool isUp;
            bool isDown;
            bool isRight;
            bool isLeft;
            bool isShot;
            bool isHandleKeyDownMenu = true;
            do
            {
                isUp = false;
                isDown = false;
                isRight = false;
                isLeft = false;
                isShot = false;
                ConsoleKeyInfo keyInfo = System.Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    isLeft = true;
                }
                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    isRight = true;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    isUp = true;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    isDown = true;
                }
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    isShot = true;
                }
                _modelGame.MakePlayerAction(isUp, isDown, isRight, isLeft, isShot);

            } 
            while (isHandleKeyDownMenu);
        }
    }
}
