using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using View;
using WindowsView.GameObjects;

namespace WindowsView
{
    /// <summary>
    /// Делегат для отслеживания нажатия клавиши
    /// </summary>
    /// <param name="parE">Нажатая клавиша</param>
    public delegate void DKey(KeyEventArgs parE);
    public delegate void DViewClosing();

    public class ViewGameWindow : ViewGame
    {
        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public event DKey KeyDownGame;
        public event DKey KeyUpGame;
        public event DViewClosing ViewGameClosing;

        private Form _form;

        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        private ViewPlayerWindow _viewPlayerWindow;
        private ViewZombiesWindow _viewZombiesWindow;
        private ViewBulletsWindow _viewBulletsWindow;
        private ViewAmmoWindow _viewAmmoWindow;

        private Font _font;
        private Graphics _graphics;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGameWindow(ModelGame parModelGame) : base(parModelGame)
        {
            _form = ViewForm.GetInstance();
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            _font = new Font("Arial", 12);
            _graphics = _form.CreateGraphics();

            _modelGame.NeedRedraw += Redraw;
            _modelGame.GameOver += DrawGameOver;

            _viewPlayerWindow = new ViewPlayerWindow(_modelGame.Player, _bufferedGraphics, 75, 75);
            _viewZombiesWindow = new ViewZombiesWindow(ref _modelGame.GetRefArrayZombies(), _bufferedGraphics, 75, 75);
            _viewBulletsWindow = new ViewBulletsWindow(_modelGame.Bullets, _bufferedGraphics, 100, 105);
            _viewAmmoWindow = new ViewAmmoWindow(_modelGame.Ammo, _bufferedGraphics, 75, 75);
        }

        private void ViewGame_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownGame?.Invoke(e);
        }

        private void ViewGame_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUpGame?.Invoke(e);
        }

        public void ViewGameWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewGameClosing?.Invoke();
        }

        public override void ShowView()
        {
            _form.KeyDown += ViewGame_KeyDown;
            _form.KeyUp += ViewGame_KeyUp;
            _form.FormClosing += ViewGameWindows_FormClosing;
            if (Application.OpenForms.Count == 0)
            {
                Application.Run(_form);
            }
        }

        public override void CloseView()
        {
            _form.KeyDown -= ViewGame_KeyDown;
            _form.KeyUp -= ViewGame_KeyUp;
            _form.FormClosing -= ViewGameWindows_FormClosing;
        }

        private void Redraw()
        {
            _bufferedGraphics.Graphics.Clear(Color.White);
            _viewPlayerWindow.Draw();
            _viewZombiesWindow.Draw();
            _viewAmmoWindow.Draw();
            _viewBulletsWindow.Draw();
            DrawInformationBar();
            _bufferedGraphics.Render();
        }

        private void DrawInformationBar()
        {
            int health = _modelGame.Player.Health;
            _bufferedGraphics.Graphics.DrawString("Здоровье - " + health, _font, Brushes.Red, 100, 30);
            _bufferedGraphics.Graphics.DrawString("Патроны - " + _modelGame.NumberAmmo, _font, Brushes.Red, 250, 30);
            _bufferedGraphics.Graphics.DrawString("Количество очков - " + _modelGame.NumberKilledZombies, _font, Brushes.Red, 400, 30);
            if (health < 1)
            {
                _bufferedGraphics.Graphics.DrawString("Игра закончена!", _font, Brushes.Red, 600, 30);
                _bufferedGraphics.Graphics.DrawString("Нажмите любую клавишу", _font, Brushes.Red, 600, 50);
            }
        }

        private void DrawGameOver()
        {  
            _bufferedGraphics.Graphics.Clear(Color.White);
            _viewZombiesWindow.Draw();
            _viewPlayerWindow.DrawDeadPlayer();
            DrawInformationBar();
            _bufferedGraphics.Graphics.DrawString("Игра закончена", _font, Brushes.Red, 400, 50);
            _bufferedGraphics.Render();
        }
    }
}
