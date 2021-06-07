using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace View
{
    /// <summary>
    /// Общий класс вывода игры на экран
    /// </summary>
    public abstract class ViewGame : ViewCommon
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        protected ModelGame _modelGame;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parModelGame">Модель игры</param>
        public ViewGame(ModelGame parModelGame)
        {
            _modelGame = parModelGame;
        }
    }
}
