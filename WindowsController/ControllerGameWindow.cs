using Controller;
using Model;
using System;
using System.Windows.Forms;
using View;
using WindowsView;
using WindowsView.GameObjects;

namespace WindowsController
{
    public class ControllerGameWindow : ControllerGame
    {
        private bool _isUp;
        private bool _isDown;
        private bool _isRight;
        private bool _isLeft;

        /// <summary>
        /// Конструктор контроллера игры
        /// </summary>
        public ControllerGameWindow(ControllerMain parControllerMain, ModelGame parModelGame) : base(parControllerMain, parModelGame)
        {
            _viewGame = new ViewGameWindow(_modelGame);
            ((ViewGameWindow)_viewGame).KeyDownGame += ControllerGameWindow_KeyDown;
            ((ViewGameWindow)_viewGame).KeyUpGame += ControllerGameWindow_KeyUp;
            ((ViewGameWindow)_viewGame).ViewGameClosing += _modelGame.StopGame;
            _modelGame.GameOver += () => { _controller.ChangeOnControllerRecordAdder(_modelGame.NumberKilledZombies); };
        }

        public override void Start()
        {
            _isUp = false;
            _isDown = false;
            _isRight = false;
            _isLeft = false;
            _viewGame.ShowView();
            _modelGame.StartGame();
        }

        public override void Stop()
        {
            _modelGame.StopGame();
            _viewGame.CloseView();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerGameWindow_KeyDown(KeyEventArgs parE)
        {
            bool isShot = false;
            if (parE.KeyCode == Keys.Left)
            {
                _isLeft = true;
            }
            if (parE.KeyCode == Keys.Right)
            {
                _isRight = true;
            }
            if (parE.KeyCode == Keys.Up)
            {
                _isUp = true;
            }
            if (parE.KeyCode == Keys.Down)
            {
                _isDown = true;
            }
            if (parE.KeyCode == Keys.Space)
            {
                isShot = true;
            }
            _modelGame.MakePlayerAction(_isUp, _isDown, _isRight, _isLeft, isShot);
        }

        private void ControllerGameWindow_KeyUp(KeyEventArgs parE)
        {
            if (parE.KeyCode == Keys.Left)
            {
                _isLeft = false;
            }
            if (parE.KeyCode == Keys.Right)
            {
                _isRight = false;
            }
            if (parE.KeyCode == Keys.Up)
            {
                _isUp = false;
            }
            if (parE.KeyCode == Keys.Down)
            {
                _isDown = false;
            }
            _modelGame.MakePlayerAction(_isUp, _isDown, _isRight, _isLeft, false);
        }
    }
}
