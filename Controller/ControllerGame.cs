using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
    /// <summary>
    /// Общий контроллер игры
    /// </summary>
    public abstract class ControllerGame : ControllerCommon
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        protected ModelGame _modelGame;
        /// <summary>
        /// объект view игры
        /// </summary>
        protected ViewGame _viewGame;

        public ControllerGame(ControllerMain parControllerMain, ModelGame parModelGame) : base(parControllerMain)
        {
            _modelGame = parModelGame;
        }
    }
}
