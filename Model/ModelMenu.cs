using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelMenu
    {
        public event DModel NeedRedraw = null;

        /// <summary>
        /// Элементы меню
        /// </summary>
        public Dictionary<int, MenuItem> Items;

        /// <summary>
        /// Сфокусированный элемент меню
        /// </summary>
        private int _focusedItemIndex;

        public ModelMenu()
        {
            Items = new Dictionary<int, MenuItem>();
            Items.Add((int)ItemCode.GAME, new MenuItem("Играть"));
            Items.Add((int)ItemCode.RECORDS, new MenuItem("Рекорды"));
            Items.Add((int)ItemCode.HELP, new MenuItem("Инструкция"));
            Items.Add((int)ItemCode.EXIT, new MenuItem("Выход"));
            Items[0].CurrentStatus = Status.FOCUSED;
            _focusedItemIndex = 0;
        }

        public void FocusNext()
        {
            int previousIndex = _focusedItemIndex;
            if (_focusedItemIndex == Items.Count - 1)
                _focusedItemIndex = 0;
            else
                _focusedItemIndex++;

            Items[_focusedItemIndex].CurrentStatus = Status.FOCUSED;
            Items[previousIndex].CurrentStatus = Status.NORMAL;

            NeedRedraw?.Invoke();
        }

        public void FocusPrevious()
        {
            int previousIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
                _focusedItemIndex = Items.Count - 1;
            else
                _focusedItemIndex--;

            Items[_focusedItemIndex].CurrentStatus = Status.FOCUSED;
            Items[previousIndex].CurrentStatus = Status.NORMAL;

            NeedRedraw?.Invoke();
        }

        public void SelectFocusedItem()
        {
            Items[_focusedItemIndex].CurrentStatus = Status.SELECTED;
        }
    }
}
