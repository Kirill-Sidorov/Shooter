using ConsoleView.GameObjects;
using Model;
using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace ConsoleView
{
    public class ViewGameConsole : ViewGame
    {
        private ViewPlayerConsole _viewPlayerConsole;
        private ViewZombiesConsole _viewZombiesConsole;
        private ViewBulletsConsole _viewBulletsConsole;
        private ViewAmmoConsole _viewAmmoConsole;

        private ConsoleColor _color;

        public ViewGameConsole(ModelGame parModelGame) : base(parModelGame)
        {
            _modelGame.NeedRedraw += Redraw;

            _viewPlayerConsole = new ViewPlayerConsole(_modelGame.Player, 8, 3);
            _viewZombiesConsole = new ViewZombiesConsole(ref _modelGame.GetRefArrayZombies(), 8, 3);
            _viewBulletsConsole = new ViewBulletsConsole(_modelGame.Bullets, 8, 3);
            _viewAmmoConsole = new ViewAmmoConsole(_modelGame.Ammo, 8, 3);

            _color = ConsoleColor.Red;
        }

        public override void ShowView()
        {
            System.Console.CursorVisible = false;
        }

        public override void CloseView()
        {
            ConsoleOutput.Clear();
        }

        private void Redraw()
        {
            ConsoleOutput.Clear();
            _viewPlayerConsole.Draw();
            _viewZombiesConsole.Draw();
            _viewAmmoConsole.Draw();
            _viewBulletsConsole.Draw();
            DrawInformationBar();
            ConsoleOutput.PrintOnConsole();
        }

        private void DrawInformationBar()
        {
            int health = _modelGame.Player.Health;
            ConsoleOutput.Write("Здоровье - " + health, 1, 1, _color);
            ConsoleOutput.Write("Патроны - " + _modelGame.NumberAmmo, 20, 1, _color);
            ConsoleOutput.Write("Количество очков - " + _modelGame.NumberKilledZombies, 40, 1, _color);
            if (health < 1)
            {
                ConsoleOutput.Write("Игра закончена!", 60, 1, _color);
                ConsoleOutput.Write("Нажмите любую клавишу", 60, 3, _color);
            }
        }
    }
}
